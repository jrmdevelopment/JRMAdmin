using JarvisAdmin.Web.Data.Jarvis;
using Microsoft.EntityFrameworkCore;

namespace JarvisAdmin.Web.Services;

public class DatabaseChecksService(JarvisDbContext db)
{
    public async Task<List<DatabaseCheckRow>> RunShiftChecksAsync()
    {
        var rows = new List<DatabaseCheckRow>();

        rows.AddRange(await RunShiftKeyBlankCheckAsync());
        rows.AddRange(await RunUnbalancedShiftsCheckAsync());
        rows.AddRange(await RunStaleOpenShiftsCheckAsync());
        rows.AddRange(await RunEndedNotBalancedShiftsCheckAsync());

        return rows;
    }

    // Pledges the old dbcheck_sponsor* procedures always excluded as known/accepted exceptions.
    // These are SponsorPledgeDetailKeys - converted pledges kept their old PaymentSponsorKey.
    private static readonly int[] ExcludedPledgeKeys = [3370, 3081];

    // All sponsor checks are limited to active organizations (Organization.Status = 'A').
    public async Task<List<SponsorCheckRow>> RunSponsorChecksAsync()
    {
        var rows = new List<SponsorCheckRow>();

        rows.AddRange(await RunDuplicateSponsorCheckAsync());
        rows.AddRange(await RunSponsorAmountMismatchCheckAsync());
        rows.AddRange(await RunUnpaidSponsorPledgeCheckAsync());

        return rows;
    }

    // Flags active sponsors that share a name (ignoring leading/trailing spaces) with another
    // active sponsor in the same organization. Every sponsor in the group is listed so each
    // SponsorKey can be compared; the pledge count helps pick which record to keep.
    private async Task<List<SponsorCheckRow>> RunDuplicateSponsorCheckAsync()
    {
        var results = await (
            from s in db.Sponsors
            join o in db.Organizations on s.OrganizationKey equals o.OrganizationKey
            where s.SponsorStatus == "A" && o.Status == "A" && s.OrganizationKey != 32
            let dupCount = db.Sponsors.Count(s2 => s2.OrganizationKey == s.OrganizationKey
                                                   && s2.SponsorStatus == "A"
                                                   && s2.SponsorName.Trim() == s.SponsorName.Trim())
            where dupCount > 1
            orderby o.OrganizationName, s.SponsorName, s.SponsorKey
            select new
            {
                o.OrganizationName,
                Sponsor = s,
                DupCount = dupCount,
                PledgeCount = s.SponsorPledgeDetails.Count()
            }
        ).ToListAsync();

        return results.Select(r => SponsorRow(
            "Duplicate sponsor",
            $"{r.DupCount} active sponsors with this name; this one has {r.PledgeCount} pledge(s)",
            r.OrganizationName, r.Sponsor)).ToList();
    }

    // Flags pledges paid MORE than they are worth (BalanceDue below zero). Since the multi-payment
    // redesign a partly paid pledge is normal (a balance still due is the unpaid check below), so
    // only an overpayment is a mismatch - same rule as dbcheck_sponsorpmtinvalid.
    private async Task<List<SponsorCheckRow>> RunSponsorAmountMismatchCheckAsync()
    {
        var results = (await PledgeQuery().Where(r => r.PaymentCount > 0).ToListAsync())
            .Where(r => r.BalanceDue < 0m)
            .ToList();

        return results.Select(r =>
        {
            var details = $"Paid {r.PledgePaid:C} (after convenience fees, refunds and NSF reversals) on a " +
                          $"{r.Pledge.SponsorAmount:C} pledge" + (r.NsfFee != 0m ? $" plus {r.NsfFee:C} NSF fee" : "") +
                          $" - overpaid by {-r.BalanceDue:C}";

            return PledgeRow("Sponsor amount <> payment", details, r);
        }).ToList();
    }

    // Flags pledges with a balance still due - nothing paid yet, or partly paid - most recent
    // first. Same rule as dbcheck_sponsorpmtdue (BalanceDue = SponsorAmount + NSF fees - PledgePaid).
    private async Task<List<SponsorCheckRow>> RunUnpaidSponsorPledgeCheckAsync()
    {
        var today = DateTime.Today;

        var results = (await PledgeQuery().ToListAsync())
            .Where(r => r.BalanceDue > 0m)
            .OrderByDescending(r => r.Pledge.SponsorshipAdded)
            .ToList();

        return results.Select(r =>
        {
            var p = r.Pledge;
            var details = $"Pledged {p.SponsorshipAdded:MM/dd/yyyy} ({(today - p.SponsorshipAdded.Date).Days} days ago); " +
                          (r.PledgePaid == 0m ? $"nothing paid, {r.BalanceDue:C} due" : $"{r.PledgePaid:C} paid, {r.BalanceDue:C} still due");
            if (p.SponsorshipExpiration is { } exp)
                details += exp < today ? $"; sponsorship expired {exp:MM/dd/yyyy}" : $"; expires {exp:MM/dd/yyyy}";

            return PledgeRow("Unpaid sponsor pledge", details, r);
        }).ToList();
    }

    // One row per pledge with its payment totals. Declined attempts are left out; refunds and NSF
    // reversals are negative rows, so PledgePaid is net of them.
    private IQueryable<PledgeQueryResult> PledgeQuery() =>
        from d in db.SponsorPledgeDetails
        join s in db.Sponsors on d.SponsorKey equals s.SponsorKey
        join o in db.Organizations on d.OrganizationKey equals o.OrganizationKey
        join pt in db.SponsorPledgeTypes on d.SponsorPledgeTypeKey equals pt.SponsorPledgeTypeKey into ptj
        from pt in ptj.DefaultIfEmpty()
        where o.Status == "A" && d.OrganizationKey != 32 && !ExcludedPledgeKeys.Contains(d.SponsorPledgeDetailKey)
        let pays = d.PaymentSponsors.Where(p => p.ConfirmationNbr == null || p.ConfirmationNbr != "Declined")
        let last = pays.Where(p => p.PaymentAmount > 0m && (p.ConfirmationNbr == null || p.ConfirmationNbr != "REFUND"))
                       .OrderByDescending(p => p.PaymentDate).ThenByDescending(p => p.PaymentSponsorKey)
                       .FirstOrDefault()
        select new PledgeQueryResult
        {
            OrganizationName = o.OrganizationName,
            Sponsor = s,
            Pledge = d,
            PledgeType = pt == null ? null : (pt.SponsorPledgeType1 ?? pt.SponsorPledgeTypeDesc),
            PaymentCount = pays.Count(),
            TotalPaid = pays.Sum(p => (decimal?)p.PaymentAmount) ?? 0m,
            ConvenienceFee = pays.Sum(p => (decimal?)p.ConvenienceFee) ?? 0m,
            PledgePaid = pays.Sum(p => (decimal?)(p.PaymentAmount - p.ConvenienceFee)) ?? 0m,
            RefundAmount = pays.Where(p => p.ConfirmationNbr == "REFUND").Sum(p => (decimal?)p.PaymentAmount) ?? 0m,
            NsfFee = pays.Sum(p => p.Nsffee) ?? 0m,
            LastPaymentDate = last == null ? null : (DateTime?)last.PaymentDate,
            LastPaymentType = last == null ? null : last.PaymentType,
            LastConfirmationNbr = last == null ? null : last.ConfirmationNbr
        };

    private sealed class PledgeQueryResult
    {
        public string OrganizationName { get; init; } = null!;
        public Sponsor Sponsor { get; init; } = null!;
        public SponsorPledgeDetail Pledge { get; init; } = null!;
        public string? PledgeType { get; init; }
        public int PaymentCount { get; init; }
        public decimal TotalPaid { get; init; }
        public decimal ConvenienceFee { get; init; }
        public decimal PledgePaid { get; init; }
        public decimal RefundAmount { get; init; }
        public decimal NsfFee { get; init; }
        public DateTime? LastPaymentDate { get; init; }
        public string? LastPaymentType { get; init; }
        public string? LastConfirmationNbr { get; init; }

        // same as the Sponsor screens: SponsorAmount + NSF fees - PledgePaid
        public decimal BalanceDue => Pledge.SponsorAmount + NsfFee - PledgePaid;
    }

    private static SponsorCheckRow SponsorRow(string problem, string details, string organizationName, Sponsor s) => new()
    {
        Problem = problem,
        Details = details,
        OrganizationName = organizationName,
        SponsorKey = s.SponsorKey,
        SponsorName = s.SponsorName,
        SponsorStatus = s.SponsorStatus,
        ContactName = s.ContactName,
        ContactPhoneNbr = s.ContactPhoneNbr,
        ContactEmail = s.ContactEmail
    };

    // PaymentSponsorKey on the row is the PLEDGE key (SponsorPledgeDetailKey); the payment columns
    // are the pledge's totals and its most recent payment.
    private static SponsorCheckRow PledgeRow(string problem, string details, PledgeQueryResult r)
    {
        var row = SponsorRow(problem, details, r.OrganizationName, r.Sponsor);
        row.PaymentSponsorKey = r.Pledge.SponsorPledgeDetailKey;
        row.PledgeType = r.PledgeType;
        row.SponsorAmount = r.Pledge.SponsorAmount;
        row.PaymentAmount = r.PaymentCount > 0 ? r.TotalPaid : null;
        row.ConvenienceFee = r.PaymentCount > 0 ? r.ConvenienceFee : null;
        row.RefundAmount = r.RefundAmount != 0m ? r.RefundAmount : null;
        row.SponsorshipAdded = r.Pledge.SponsorshipAdded;
        row.PaymentDate = r.LastPaymentDate;
        row.PaymentType = r.LastPaymentType;
        row.ConfirmationNbr = r.LastConfirmationNbr;
        return row;
    }

    // Flags active recurring-billing memberships (RecurringPaymentAddedDate set, not yet cancelled) at
    // MXGateway organizations that are missing the RecurringPaymentToken and/or MXVaultedCustomerId
    // they need for MX Merchant to actually process the recurring charge.
    public async Task<List<DatabaseCheckRow>> RunRecurringBillingChecksAsync() =>
        await (
            from m in db.Memberships
            join o in db.Organizations on m.OrganizationKey equals o.OrganizationKey
            where o.GatewayUsed == "MXGateway"
                  && o.OrganizationKey != 32
                  && m.RecurringPaymentAddedDate != null
                  && m.RecurringPaymentCancelDate == null
                  && (string.IsNullOrEmpty(m.RecurringPaymentToken) || m.MxVaultedCustomerId == null)
            select new DatabaseCheckRow
            {
                OrganizationName = o.OrganizationName,
                SystemArea = "Membership",
                DatabaseCheck = "Recurring billing missing MX token/vault customer ID",
                DatabaseKey = m.MembershipKey,
                Field1 = m.MemberFirstName,
                Field2 = m.MemberLastName
            }
        ).ToListAsync();

    // Flags shifts at MXGateway organizations using shifts that started more than 2 days ago
    // and were never ended - i.e. a shift that got left open. Shifts over 30 days old are
    // excluded along with every other Shift-area check.
    private async Task<List<DatabaseCheckRow>> RunStaleOpenShiftsCheckAsync()
    {
        var cutoff = DateTime.Now.AddDays(-2);
        var maxAge = DateTime.Now.AddDays(-30);

        return await (
            from s in db.Shifts
            join o in db.Organizations on s.OrganizationKey equals o.OrganizationKey
            where o.UseShifts && o.GatewayUsed == "MXGateway" && o.OrganizationKey != 32
                  && s.ShiftStartDate < cutoff
                  && s.ShiftStartDate >= maxAge
                  && s.ShiftEndDate == null
            select new DatabaseCheckRow
            {
                OrganizationName = o.OrganizationName,
                SystemArea = "Shift",
                DatabaseCheck = "Shift open more than 2 days",
                DatabaseKey = s.ShiftKey,
                Field1 = s.ShiftStartDate.ToString("MM/dd/yyyy"),
                Field2 = s.ShiftStartName
            }
        ).ToListAsync();
    }

    // Flags shifts at MXGateway organizations that were ended but never balanced.
    // Shifts started within the last 2 days are given a grace period and excluded,
    // since staff may not have gotten around to balancing them yet.
    private async Task<List<DatabaseCheckRow>> RunEndedNotBalancedShiftsCheckAsync()
    {
        var cutoff = DateTime.Now.AddDays(-2);
        var maxAge = DateTime.Now.AddDays(-30);

        return await (
            from s in db.Shifts
            join o in db.Organizations on s.OrganizationKey equals o.OrganizationKey
            where o.UseShifts && o.GatewayUsed == "MXGateway" && o.OrganizationKey != 32
                  && s.ShiftStartDate >= maxAge
                  && s.ShiftStartDate < cutoff
                  && s.ShiftEndDate != null
                  && s.BalancedOn == null
            select new DatabaseCheckRow
            {
                OrganizationName = o.OrganizationName,
                SystemArea = "Shift",
                DatabaseCheck = "Shift ended but not balanced",
                DatabaseKey = s.ShiftKey,
                Field1 = s.ShiftStartDate.ToString("MM/dd/yyyy"),
                Field2 = s.ShiftStartName
            }
        ).ToListAsync();
    }

    private async Task<List<DatabaseCheckRow>> RunShiftKeyBlankCheckAsync() =>
        await db.Database.SqlQuery<DatabaseCheckRow>($"EXEC dbcheck_shiftkeyblank").ToListAsync();

    // Ported from the old admin tool's CheckUnbalancedShifts VB function - dbcheck_shiftendbalance
    // was never a real stored procedure, it was this application-code check. Re-checks every
    // already-balanced shift from the last 30 days (excluding the most recent 4 days, which may
    // still be actively worked) against shift_bypaymenttype's live payment totals, flagging any
    // shift whose drawer totals no longer match - i.e. a payment was added/changed/removed after
    // the shift was balanced.
    private async Task<List<DatabaseCheckRow>> RunUnbalancedShiftsCheckAsync()
    {
        var startDate = DateTime.Now.AddDays(-30);
        var endDate = DateTime.Now.AddDays(-4);

        var candidateShifts = await (
            from s in db.Shifts
            join o in db.Organizations on s.OrganizationKey equals o.OrganizationKey
            where o.UseShifts && o.OrganizationKey != 32
                  && s.ShiftStartDate >= startDate && s.ShiftStartDate <= endDate
                  && s.BalancedOn != null
            select new
            {
                s.ShiftKey,
                s.OrganizationKey,
                o.OrganizationName,
                s.ShiftStartDate,
                s.ShiftStartName,
                DrawerCash = s.DrawerTotalCash ?? 0m,
                DrawerChecks = s.DrawerTotalChecks ?? 0m,
                DrawerCreditCard = s.DrawerTotalCreditCard ?? 0m
            }
        ).ToListAsync();

        var rows = new List<DatabaseCheckRow>();

        foreach (var shift in candidateShifts)
        {
            var paymentTotals = await db.Database
                .SqlQuery<PaymentTypeTotal>($"EXEC shift_bypaymenttype @OrganizationKey = {shift.OrganizationKey}, @ShiftKey = {shift.ShiftKey}")
                .ToListAsync();

            var totalCash = 0m;
            var totalChecks = 0m;
            var totalCreditCards = 0m;

            foreach (var pt in paymentTotals)
            {
                var received = pt.TotalReceived ?? 0m;
                switch (pt.PaymentType)
                {
                    case "Cash":
                        totalCash += received;
                        break;
                    case "Check":
                        totalChecks += received;
                        break;
                    case "Credit Card":
                    case "CC Swipe":
                        totalCreditCards += received;
                        break;
                }
            }

            if (totalCash != shift.DrawerCash || totalChecks != shift.DrawerChecks || totalCreditCards != shift.DrawerCreditCard)
            {
                rows.Add(new DatabaseCheckRow
                {
                    OrganizationName = shift.OrganizationName,
                    SystemArea = "Shift",
                    DatabaseCheck = "Balanced shift no longer balanced",
                    DatabaseKey = shift.ShiftKey,
                    Field1 = shift.ShiftStartDate.ToString("MM/dd/yyyy"),
                    Field2 = shift.ShiftStartName
                });
            }
        }

        return rows;
    }
}
