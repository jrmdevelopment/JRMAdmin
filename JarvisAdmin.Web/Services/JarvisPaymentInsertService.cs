using JarvisAdmin.Web.Data.Jarvis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace JarvisAdmin.Web.Services;

// The Jarvis payment tables a payment found in MX can be added to (MX Reconciliation > MX Lookup >
// Add Payment in Jarvis), each with the parent record its rows hang off.
public enum JarvisPaymentTable
{
    Registration, // Payment, under a RegistrantToLeague
    Facility,     // PaymentFacility, under a FacilityReservation
    Pos,          // POSTransactionPayment, under a POSTransaction
}

// Every column the three payment tables share, plus the few only one of them has (noted per field), so one
// form can edit whichever table is chosen. CCLastFour/CCExpiration are left out: the main Jarvis app encrypts
// them before saving, so plain text entered here would not read back correctly.
public class NewJarvisPayment
{
    public int? ParentKey { get; set; }              // RegistrantToLeagueKey / FacilityReservationKey / POSTransactionKey
    public bool IsRefund { get; set; }               // amounts are stored negative (entered negative on the page)
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public decimal PaymentAmount { get; set; }
    public decimal ConvenienceFee { get; set; }
    public string PaymentType { get; set; } = "";
    public string? RegistrationNbr { get; set; }
    public string? ConfirmationNbr { get; set; }
    public string? CheckNbr { get; set; }
    public int? ShiftKey { get; set; }
    public string? Nsfcheck { get; set; }
    public decimal? Nsffee { get; set; }
    public string? Comments { get; set; }            // PaymentComments (Payment, PaymentFacility) / PaymentNotes (POS)
    public string PaymentPostedBy { get; set; } = "Jarvis Login";
    public string? PaymentId { get; set; }
    public string? PaymentToken { get; set; }
    public string? ValorTxnId { get; set; }
    public string? MerchantBatchId { get; set; }
    public long? MerchantBatchIdNum { get; set; }
    public int? GroupId { get; set; }                // Payment, PaymentFacility
    public DateTime? PaymentReleaseDate { get; set; } // Payment, PaymentFacility
    public string? RefundCheckName { get; set; }     // Payment only
    public string? RefundCheckAddress { get; set; }  // Payment only
    public string? RefundCheckCityStZip { get; set; } // Payment only
    public string? RevenueCode { get; set; }         // PaymentFacility only
    public bool SecurityDepositPayment { get; set; } // PaymentFacility only
    public bool SecurityDepositRefund { get; set; }  // PaymentFacility only
}

// What the chosen parent record is, so the user can confirm it's the right one before inserting.
public record JarvisPaymentParent(bool Found, string Description, IReadOnlyList<JarvisPaymentParentDetail> Details);

public record JarvisPaymentParentDetail(string Label, string Value);

public record JarvisShiftChoice(int ShiftKey, string Label);

public class JarvisPaymentInsertService(IDbContextFactory<JarvisDbContext> dbFactory)
{
    public static string TableName(JarvisPaymentTable table) => table switch
    {
        JarvisPaymentTable.Registration => "Payment",
        JarvisPaymentTable.Facility => "PaymentFacility",
        _ => "POSTransactionPayment",
    };

    public static string ParentKeyLabel(JarvisPaymentTable table) => table switch
    {
        JarvisPaymentTable.Registration => "RegistrantToLeagueKey",
        JarvisPaymentTable.Facility => "FacilityReservationKey",
        _ => "POSTransactionKey",
    };

    // The organization's shifts started on the payment's date, for the Shift dropdown - open or already ended,
    // since a payment being added after the fact usually belongs to a shift that has since closed.
    public async Task<List<JarvisShiftChoice>> GetShiftsForDateAsync(int organizationKey, DateTime paymentDate)
    {
        var dayStart = paymentDate.Date;
        var dayEnd = dayStart.AddDays(1);

        await using var db = await dbFactory.CreateDbContextAsync();
        var shifts = await db.Shifts.AsNoTracking()
            .Where(s => s.OrganizationKey == organizationKey && s.ShiftStartDate >= dayStart && s.ShiftStartDate < dayEnd)
            .OrderBy(s => s.ShiftStartDate)
            .Select(s => new { s.ShiftKey, s.ShiftStartName, s.ShiftStartDate, s.ShiftEndDate })
            .ToListAsync();

        return shifts
            .Select(s => new JarvisShiftChoice(s.ShiftKey,
                $"{s.ShiftStartName} - {s.ShiftStartDate:h:mm tt} to {(s.ShiftEndDate is { } end ? end.ToString("h:mm tt") : "(open)")} (shift {s.ShiftKey})"))
            .ToList();
    }

    // Looks up the parent record (Lookup button on the page) and checks it belongs to the organization the MX
    // payment is for, returning enough about it - who/what it is, its totals and the payments already on it - for
    // the user to be sure the payment is going on the right record.
    public async Task<JarvisPaymentParent> DescribeParentAsync(JarvisPaymentTable table, int parentKey, int organizationKey)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        switch (table)
        {
            case JarvisPaymentTable.Registration:
            {
                var rtl = await db.RegistrantToLeagues.AsNoTracking()
                    .Where(r => r.RegistrantToLeagueKey == parentKey)
                    .Select(r => new
                    {
                        r.SeasonKeyNavigation.OrganizationKey,
                        r.RegistrantKeyNavigation.FirstName,
                        r.RegistrantKeyNavigation.LastName,
                        r.LeagueKeyNavigation.LeagueName,
                        r.SeasonKeyNavigation.ProgramName,
                        r.RegistrationDate,
                        r.RegistrationStatus,
                        r.TotalInvoiceAmt,
                        r.TotalPaidAmt,
                        r.ConvenienceFee,
                    })
                    .FirstOrDefaultAsync();
                if (rtl is null)
                    return NotFound($"No registration (RegistrantToLeague) {parentKey} was found.");
                if (rtl.OrganizationKey != organizationKey)
                    return NotFound($"Registration {parentKey} belongs to organization {rtl.OrganizationKey}, not this payment's organization {organizationKey}.");

                var payments = await db.Payments.AsNoTracking().Where(p => p.RegistrantToLeagueKey == parentKey)
                    .GroupBy(_ => 1).Select(g => new { Count = g.Count(), Total = g.Sum(p => p.PaymentAmount) }).FirstOrDefaultAsync();
                return new(true, $"{rtl.FirstName} {rtl.LastName} - {rtl.LeagueName}",
                [
                    new("Participant", $"{rtl.FirstName} {rtl.LastName}"),
                    new("Program", rtl.ProgramName),
                    new("League", rtl.LeagueName),
                    new("Registered", rtl.RegistrationDate.ToString("MM/dd/yyyy h:mm tt")),
                    new("Status", rtl.RegistrationStatus),
                    new("Total Invoiced", rtl.TotalInvoiceAmt.ToString("C")),
                    new("Total Paid", rtl.TotalPaidAmt.ToString("C")),
                    new("Balance", (rtl.TotalInvoiceAmt - rtl.TotalPaidAmt).ToString("C")),
                    new("Convenience Fee", rtl.ConvenienceFee.ToString("C")),
                    new("Existing Payments", PaymentsSummary(payments?.Count ?? 0, payments?.Total ?? 0m)),
                ]);
            }
            case JarvisPaymentTable.Facility:
            {
                var fr = await db.FacilityReservations.AsNoTracking()
                    .Where(f => f.FacilityReservationKey == parentKey)
                    .Select(f => new
                    {
                        f.OrganizationKey,
                        f.ApplicantName,
                        f.FacilitySpaceKeyNavigation.FacilityName,
                        f.DateOfReservation,
                        f.StartTimeOfEvent,
                        f.ReservationStatus,
                        f.TotalDue,
                        f.TotalPaid,
                        f.ConvenienceFee,
                    })
                    .FirstOrDefaultAsync();
                if (fr is null)
                    return NotFound($"No facility reservation {parentKey} was found.");
                if (fr.OrganizationKey != organizationKey)
                    return NotFound($"Facility reservation {parentKey} belongs to organization {fr.OrganizationKey}, not this payment's organization {organizationKey}.");

                var payments = await db.PaymentFacilities.AsNoTracking().Where(p => p.FacilityReservationKey == parentKey)
                    .GroupBy(_ => 1).Select(g => new { Count = g.Count(), Total = g.Sum(p => p.PaymentAmount) }).FirstOrDefaultAsync();
                return new(true, $"{fr.ApplicantName} - {fr.FacilityName ?? "facility"} on {fr.StartTimeOfEvent:MM/dd/yyyy}",
                [
                    new("Applicant", fr.ApplicantName),
                    new("Facility", fr.FacilityName ?? "-"),
                    new("Reserved On", fr.DateOfReservation.ToString("MM/dd/yyyy")),
                    new("Event Start", fr.StartTimeOfEvent.ToString("MM/dd/yyyy h:mm tt")),
                    new("Status", fr.ReservationStatus),
                    new("Total Due", fr.TotalDue.ToString("C")),
                    new("Total Paid", fr.TotalPaid.ToString("C")),
                    new("Balance", (fr.TotalDue - fr.TotalPaid).ToString("C")),
                    new("Convenience Fee", fr.ConvenienceFee.ToString("C")),
                    new("Existing Payments", PaymentsSummary(payments?.Count ?? 0, payments?.Total ?? 0m)),
                ]);
            }
            default:
            {
                var pos = await db.Postransactions.AsNoTracking()
                    .Where(p => p.PostransactionKey == parentKey)
                    .Select(p => new
                    {
                        p.OrganizationKey,
                        p.DateTimeEntered,
                        p.EnteredByUser,
                        p.TransactionStatus,
                        p.SubtotalAmount,
                        p.TotalTaxAmount,
                        p.TotalDue,
                        p.TotalPaid,
                        p.ConvenienceFee,
                    })
                    .FirstOrDefaultAsync();
                if (pos is null)
                    return NotFound($"No POS transaction {parentKey} was found.");
                if (pos.OrganizationKey != organizationKey)
                    return NotFound($"POS transaction {parentKey} belongs to organization {pos.OrganizationKey}, not this payment's organization {organizationKey}.");

                var payments = await db.PostransactionPayments.AsNoTracking().Where(p => p.PostransactionKey == parentKey)
                    .GroupBy(_ => 1).Select(g => new { Count = g.Count(), Total = g.Sum(p => p.PaymentAmount) }).FirstOrDefaultAsync();
                return new(true, $"POS sale entered {pos.DateTimeEntered:MM/dd/yyyy h:mm tt} by {pos.EnteredByUser}",
                [
                    new("Entered", pos.DateTimeEntered.ToString("MM/dd/yyyy h:mm tt")),
                    new("Entered By", pos.EnteredByUser),
                    new("Status", pos.TransactionStatus),
                    new("Subtotal", pos.SubtotalAmount.ToString("C")),
                    new("Tax", pos.TotalTaxAmount.ToString("C")),
                    new("Total Due", pos.TotalDue.ToString("C")),
                    new("Total Paid", pos.TotalPaid.ToString("C")),
                    new("Balance", (pos.TotalDue - pos.TotalPaid).ToString("C")),
                    new("Convenience Fee", pos.ConvenienceFee.ToString("C")),
                    new("Existing Payments", PaymentsSummary(payments?.Count ?? 0, payments?.Total ?? 0m)),
                ]);
            }
        }

        static JarvisPaymentParent NotFound(string message) => new(false, message, []);

        static string PaymentsSummary(int count, decimal total) => count == 0 ? "None" : $"{count} totaling {total:C}";
    }

    // Inserts the payment row and adds it to its parent's TotalPaid and ConvenienceFee totals the way the main
    // app's acctrecv_creditcardpayment does (or, for a refund, takes it off them the way its refund procs do), in
    // one transaction. PaymentAmount is the full amount charged/refunded, fee included. The parent's status is
    // not changed. The parent is re-checked at insert time, not just on screen.
    // A Payment/PaymentFacility row with no Group Id gets the organization's next one, which is left on p so the
    // next part of a split payment shares it (POSTransactionPayment has no GroupId). Returns the new payment key.
    public async Task<int> InsertAsync(JarvisPaymentTable table, int organizationKey, NewJarvisPayment p)
    {
        if (p.ParentKey is not { } parentKey)
            throw new InvalidOperationException($"Enter the {ParentKeyLabel(table)}.");

        var assignGroupId = table != JarvisPaymentTable.Pos && p.GroupId is null;
        await using var strategyDb = await dbFactory.CreateDbContextAsync();
        try
        {
            return await InsertInTransactionAsync();
        }
        catch
        {
            // The insert was rolled back, so the Group Id it took was never used - give it back.
            if (assignGroupId)
                p.GroupId = null;
            throw;
        }

        // EnableRetryOnFailure only allows an explicit transaction inside its execution strategy; a retry re-runs
        // the whole block, checks included.
        Task<int> InsertInTransactionAsync() => strategyDb.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
        {
            await using var db = await dbFactory.CreateDbContextAsync();
            await using var tx = await db.Database.BeginTransactionAsync();

            // Taken inside the insert's transaction (not when the page opened) so two people can't get the same one.
            if (assignGroupId)
                p.GroupId = await GetNextGroupIdAsync(db, organizationKey);

            var parent = await DescribeParentAsync(table, parentKey, organizationKey);
            if (!parent.Found)
                throw new InvalidOperationException(parent.Description);

            // No RegistrationNbr uniqueness check: one MX charge split across several registrations/reservations
            // is recorded as several payment rows with the same reference number.

            // A refund is stored negative, as the main app's refund procs do (forced here whichever sign it came in).
            var amount = p.IsRefund ? -Math.Abs(p.PaymentAmount) : p.PaymentAmount;
            var fee = p.IsRefund ? -Math.Abs(p.ConvenienceFee) : p.ConvenienceFee;

            int newKey;
            switch (table)
            {
                case JarvisPaymentTable.Registration:
                {
                    var row = new Payment
                    {
                        RegistrantToLeagueKey = parentKey,
                        PaymentDate = p.PaymentDate,
                        PaymentAmount = amount,
                        ConvenienceFee = fee,
                        PaymentType = p.PaymentType,
                        RegistrationNbr = Clean(p.RegistrationNbr),
                        ConfirmationNbr = Clean(p.ConfirmationNbr),
                        CheckNbr = Clean(p.CheckNbr),
                        ShiftKey = p.ShiftKey,
                        Nsfcheck = Clean(p.Nsfcheck),
                        Nsffee = p.Nsffee,
                        PaymentComments = Clean(p.Comments),
                        PaymentPostedBy = p.PaymentPostedBy.Trim(),
                        PaymentId = Clean(p.PaymentId),
                        PaymentToken = Clean(p.PaymentToken),
                        ValorTxnId = Clean(p.ValorTxnId),
                        MerchantBatchId = Clean(p.MerchantBatchId),
                        MerchantBatchIdNum = p.MerchantBatchIdNum,
                        GroupId = p.GroupId,
                        PaymentReleaseDate = p.PaymentReleaseDate,
                        RefundCheckName = Clean(p.RefundCheckName),
                        RefundCheckAddress = Clean(p.RefundCheckAddress),
                        RefundCheckCityStZip = Clean(p.RefundCheckCityStZip),
                    };
                    db.Payments.Add(row);
                    await db.SaveChangesAsync();
                    newKey = row.PaymentKey;

                    // As acctrecv_creditcardpayment's 'Payment' branch, the convenience fee is part of the invoice: a
                    // payment adds its fee to TotalInvoiceAmt (so the balance only drops by the principal), and a
                    // refund's negative fee takes the returned fee back off it along with ConvenienceFee.
                    await EnsureOneRowUpdatedAsync(db.RegistrantToLeagues
                        .Where(r => r.RegistrantToLeagueKey == parentKey)
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(r => r.TotalPaidAmt, r => r.TotalPaidAmt + amount)
                            .SetProperty(r => r.ConvenienceFee, r => r.ConvenienceFee + fee)
                            .SetProperty(r => r.TotalInvoiceAmt, r => r.TotalInvoiceAmt + fee)), "RegistrantToLeague");
                    if (p.IsRefund)
                    {
                        // payment_issuerefund_returnkey finishes by resetting TotalPaidAmt to the sum of the
                        // registration's payment rows (refund included), so it can't drift from them.
                        var paidTotal = await db.Payments.Where(x => x.RegistrantToLeagueKey == parentKey).SumAsync(x => x.PaymentAmount);
                        await EnsureOneRowUpdatedAsync(db.RegistrantToLeagues
                            .Where(r => r.RegistrantToLeagueKey == parentKey)
                            .ExecuteUpdateAsync(s => s.SetProperty(r => r.TotalPaidAmt, paidTotal)), "RegistrantToLeague");
                    }
                    break;
                }
                case JarvisPaymentTable.Facility:
                {
                    var row = new PaymentFacility
                    {
                        FacilityReservationKey = parentKey,
                        PaymentDate = p.PaymentDate,
                        PaymentAmount = amount,
                        ConvenienceFee = fee,
                        PaymentType = p.PaymentType,
                        RegistrationNbr = Clean(p.RegistrationNbr),
                        ConfirmationNbr = Clean(p.ConfirmationNbr),
                        CheckNbr = Clean(p.CheckNbr),
                        ShiftKey = p.ShiftKey,
                        RevenueCode = Clean(p.RevenueCode),
                        Nsfcheck = Clean(p.Nsfcheck),
                        Nsffee = p.Nsffee,
                        PaymentComments = Clean(p.Comments),
                        PaymentPostedBy = p.PaymentPostedBy.Trim(),
                        PaymentId = Clean(p.PaymentId),
                        PaymentToken = Clean(p.PaymentToken),
                        ValorTxnId = Clean(p.ValorTxnId),
                        GroupId = p.GroupId,
                        SecurityDepositPayment = p.SecurityDepositPayment,
                        SecurityDepositRefund = p.SecurityDepositRefund,
                        PaymentReleaseDate = p.PaymentReleaseDate,
                        MerchantBatchId = Clean(p.MerchantBatchId),
                        MerchantBatchIdNum = p.MerchantBatchIdNum,
                    };
                    db.PaymentFacilities.Add(row);
                    await db.SaveChangesAsync();
                    newKey = row.PaymentFacilityKey;

                    // Payment: as acctrecv_creditcardpayment's 'PaymentFacility' branch, including marking the
                    // reservation's security deposit paid when this is the deposit payment.
                    // Refund: as facilityreservation_addrefund - paid and fee go down, and so does TotalDue by the
                    // refunded principal (amount - fee, both negative here).
                    var dueChange = p.IsRefund ? amount - fee : 0m;
                    await EnsureOneRowUpdatedAsync(db.FacilityReservations
                        .Where(f => f.FacilityReservationKey == parentKey)
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(f => f.TotalPaid, f => f.TotalPaid + amount)
                            .SetProperty(f => f.ConvenienceFee, f => f.ConvenienceFee + fee)
                            .SetProperty(f => f.TotalDue, f => f.TotalDue + dueChange)), "FacilityReservation");
                    if (!p.IsRefund && p.SecurityDepositPayment)
                    {
                        await EnsureOneRowUpdatedAsync(db.FacilityReservations
                            .Where(f => f.FacilityReservationKey == parentKey)
                            .ExecuteUpdateAsync(s => s.SetProperty(f => f.SecurityDepositPaid, true)), "FacilityReservation");
                    }
                    break;
                }
                default:
                {
                    var row = new PostransactionPayment
                    {
                        PostransactionKey = parentKey,
                        OrganizationKey = organizationKey,
                        PaymentDate = p.PaymentDate,
                        PaymentAmount = amount,
                        ConvenienceFee = fee,
                        PaymentType = p.PaymentType,
                        RegistrationNbr = Clean(p.RegistrationNbr),
                        ConfirmationNbr = Clean(p.ConfirmationNbr),
                        ValorTxnId = Clean(p.ValorTxnId),
                        CheckNbr = Clean(p.CheckNbr),
                        ShiftKey = p.ShiftKey,
                        Nsfcheck = Clean(p.Nsfcheck),
                        Nsffee = p.Nsffee,
                        PaymentNotes = Clean(p.Comments),
                        PaymentPostedBy = p.PaymentPostedBy.Trim(),
                        PaymentToken = Clean(p.PaymentToken),
                        PaymentId = Clean(p.PaymentId),
                        MerchantBatchId = Clean(p.MerchantBatchId),
                        MerchantBatchIdNum = p.MerchantBatchIdNum,
                    };
                    db.PostransactionPayments.Add(row);
                    await db.SaveChangesAsync();
                    newKey = row.PostransactionPaymentKey;

                    await EnsureOneRowUpdatedAsync(db.Postransactions
                        .Where(t => t.PostransactionKey == parentKey)
                        .ExecuteUpdateAsync(s => s
                            .SetProperty(t => t.TotalPaid, t => t.TotalPaid + amount)
                            .SetProperty(t => t.ConvenienceFee, t => t.ConvenienceFee + fee)), "POSTransaction");
                    break;
                }
            }

            await tx.CommitAsync();
            return newKey;
        });
    }

    // The parent row not being updated rolls the whole insert back. (Only "none" is checked: the reported count
    // can include rows an audit trigger on the parent table writes, so it isn't reliably exactly 1.)
    private static async Task EnsureOneRowUpdatedAsync(Task<int> update, string tableName)
    {
        var rows = await update;
        if (rows < 1)
            throw new InvalidOperationException($"The {tableName} totals could not be updated - the insert was rolled back.");
    }

    // The organization's next payment Group Id: the main app's acctrecv_getmaxgroupid (highest Group Id in use) + 1.
    private static async Task<int> GetNextGroupIdAsync(JarvisDbContext db, int organizationKey)
    {
        await using var command = db.Database.GetDbConnection().CreateCommand();
        command.Transaction = db.Database.CurrentTransaction?.GetDbTransaction();
        command.CommandText = "EXEC acctrecv_getmaxgroupid @OrganizationKey";
        var parameter = command.CreateParameter();
        parameter.ParameterName = "@OrganizationKey";
        parameter.Value = organizationKey;
        command.Parameters.Add(parameter);

        var maxGroupId = await command.ExecuteScalarAsync();
        return (maxGroupId is null or DBNull ? 0 : Convert.ToInt32(maxGroupId)) + 1;
    }

    // The Group Id already used by payments recorded under this reference number (the parts of a split payment
    // share one), so the next part can carry the same one. POSTransactionPayment has no GroupId column.
    public async Task<int?> GetGroupIdForReferenceAsync(string registrationNbr)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.Payments.AsNoTracking().Where(x => x.RegistrationNbr == registrationNbr && x.GroupId != null).Select(x => x.GroupId).FirstOrDefaultAsync()
            ?? await db.PaymentFacilities.AsNoTracking().Where(x => x.RegistrationNbr == registrationNbr && x.GroupId != null).Select(x => x.GroupId).FirstOrDefaultAsync();
    }

    private static string? Clean(string? value) => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}
