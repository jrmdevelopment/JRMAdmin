using JarvisAdmin.Web.Data.Jarvis;
using Microsoft.EntityFrameworkCore;

namespace JarvisAdmin.Web.Services;

public class MxReconciliationService(IDbContextFactory<JarvisDbContext> dbFactory)
{
    // Real value of Organization.GatewayUsed for orgs on the MX Merchant gateway (confirmed against live data).
    public const string MxGateway = "MXGateway";

    // Blazor Server shares one DI scope (and therefore one DbContext) for the whole circuit, so two
    // overlapping UI events - e.g. picking a date while the initial Batch Summary load is still
    // running - would hit the same context and throw "A second operation was started on this
    // context". Every public entry point instead runs through RunAsync, which gives it a fresh
    // short-lived context in `db` and serializes calls so `db` is only ever used by one operation
    // at a time. Private helpers keep reading the `db` field unchanged.
    private readonly SemaphoreSlim _gate = new(1, 1);
    private JarvisDbContext db = null!;

    private async Task<T> RunAsync<T>(Func<Task<T>> op)
    {
        await _gate.WaitAsync();
        var ctx = await dbFactory.CreateDbContextAsync();
        db = ctx;
        try { return await op(); }
        finally { await ctx.DisposeAsync(); _gate.Release(); }
    }

    private Task RunAsync(Func<Task> op) => RunAsync(async () => { await op(); return true; });

    // OrganizationKey 32 is a test organization - excluded everywhere on this page.
    // OrganizationKey 158 is "Kayak Eufaula" - it shares its MX merchant account with org 79
    // (see CombinedCreditCardOrgKeys) and org 79 already covers both, so it's excluded from
    // the dropdown to avoid a redundant/confusing entry.
    public Task<List<OrganizationOption>> GetQualifyingOrganizationsAsync() =>
        RunAsync(() => db.Organizations
            .Where(o => o.GatewayUsed == MxGateway && o.OrganizationKey != 32 && o.OrganizationKey != 158)
            .OrderBy(o => o.OrganizationName)
            .Select(o => new OrganizationOption(o.OrganizationKey, o.OrganizationName))
            .ToListAsync());

    public Task<List<BatchOption>> GetBatchOptionsAsync(IReadOnlyList<int> organizationKeys, DateOnly date)
        => RunAsync(async () =>
    {
        var batches = QualifyingBatches(organizationKeys, date, batchKey: null);

        return await (
            from b in batches
            join o in db.Organizations on b.OrganizationKey equals o.OrganizationKey
            orderby o.OrganizationName, b.BatchId
            select new BatchOption(b.MxmerchantBatchKey, b.OrganizationKey, o.OrganizationName, b.BatchId, b.BatchNumber, b.BatchOpenDate)
        ).ToListAsync();
    });

    public Task<List<BatchSummaryRow>> GetBatchSummaryAsync(MxReconciliationFilter filter)
        => RunAsync(async () =>
    {
        var batches = QualifyingBatches(filter.OrganizationKeys, filter.Date, filter.BatchKey);

        return await (
            from b in batches
            join o in db.Organizations on b.OrganizationKey equals o.OrganizationKey
            orderby o.OrganizationName, b.BatchOpenDate descending
            select new BatchSummaryRow(b.MxmerchantBatchKey, o.OrganizationKey, o.OrganizationName, b.BatchId, b.BatchNumber,
                b.BatchOpenDate, b.BatchCloseDate, b.MxmerchantAmount, b.JarvisAmount, b.DiscrepancyComments)
        ).ToListAsync();
    });

    // Organizations 79 and 158 are two Jarvis org records for the same physical business/merchant
    // account - the "Paid by Credit Card" report (and its batch comparison) treats them as one
    // combined entity, so selecting either org pulls transactions and batches for both.
    private static readonly Dictionary<int, int[]> CombinedCreditCardOrgKeys = new()
    {
        [79] = [79, 158],
        [158] = [79, 158],
    };

    private static IReadOnlyList<int> ResolveCreditCardOrgKeys(int organizationKey) =>
        CombinedCreditCardOrgKeys.TryGetValue(organizationKey, out var keys) ? keys : [organizationKey];

    public Task<List<PaidByCreditCardRow>> GetPaidByCreditCardAsync(int organizationKey, DateOnly date)
        => RunAsync(async () =>
    {
        var day = date.ToDateTime(TimeOnly.MinValue);
        var rows = new List<PaidByCreditCardRow>();

        foreach (var orgKey in ResolveCreditCardOrgKeys(organizationKey))
        {
            rows.AddRange(await db.Database
                .SqlQuery<PaidByCreditCardRow>($"EXEC rpt_paidbycreditcard @OrganizationKey = {orgKey}, @StartDate = {day}, @EndDate = {day}")
                .ToListAsync());
        }

        return rows;
    });

    // Batches open on the selected date only.
    public Task<List<BatchOption>> GetBatchOptionsForCreditCardAsync(int organizationKey, DateOnly date)
        => RunAsync(async () =>
    {
        var day = date.ToDateTime(TimeOnly.MinValue);
        var orgKeys = ResolveCreditCardOrgKeys(organizationKey);

        return await (
            from b in db.MxmerchantBatches
            join o in db.Organizations on b.OrganizationKey equals o.OrganizationKey
            where orgKeys.Contains(b.OrganizationKey) && b.BatchOpenDate != null
                  && b.BatchOpenDate.Value.Date == day
            orderby b.BatchOpenDate
            select new BatchOption(b.MxmerchantBatchKey, b.OrganizationKey, o.OrganizationName, b.BatchId, b.BatchNumber, b.BatchOpenDate)
        ).ToListAsync();
    });

    // Compares the already-loaded "Paid by Credit Card" rows for an org/date against the MX
    // transactions in the selected batch(es), matching on ReferenceNbr/RegistrationNbr - the same
    // MX-only / Jarvis-only / mismatched breakdown as GetBatchVarianceDetailAsync, but against this
    // report's rows instead of a fresh 16-table Jarvis lookup, and across however many batches were
    // selected instead of just one.
    public Task<CreditCardBatchComparison> CompareCreditCardToBatchesAsync(
        int organizationKey, List<int> mxmerchantBatchKeys, List<PaidByCreditCardRow> creditCardRows)
        => RunAsync(async () =>
    {
        var orgKeys = ResolveCreditCardOrgKeys(organizationKey);

        var batchNumbers = await db.MxmerchantBatches
            .Where(b => mxmerchantBatchKeys.Contains(b.MxmerchantBatchKey))
            .Select(b => b.BatchNumber)
            .ToListAsync();

        // MxmerchantBatchTxn is populated once per org that shares the underlying MX merchant
        // account, so orgs 79 and 158 each carry an identical row (same ReferenceNbr/Amount/BatchId)
        // for every real-world transaction - only org 79 gets an actual MxmerchantBatch header,
        // though, so org 158's copy is pure duplication. Distinct() collapses those mirrored pairs
        // back down to one row per real transaction before anything gets summed.
        var mxRaw = await db.MxmerchantBatchTxns
            .Where(t => orgKeys.Contains(t.OrganizationKey) && t.ReferenceNbr != null && batchNumbers.Contains((long?)t.BatchId))
            .Select(t => new { t.ReferenceNbr, t.Amount })
            .Distinct()
            .ToListAsync();

        // rpt_paidbycreditcard labels every POS refund line with its transaction's ORIGINAL
        // RegistrationNbr, not the refund's own - but MX Merchant processes each refund as its own
        // transaction with a unique ReferenceNbr. Re-key any MX reference nbr that turns out to be a
        // POS refund back to its transaction's primary RegistrationNbr before matching, or every
        // refund shows as a false "MX Only" entry even though the amount is fully accounted for.
        var primaryRegistrationNbrByReferenceNbr = await GetPosPrimaryRegistrationNbrMapAsync(
            mxRaw.Where(t => t.ReferenceNbr != null).Select(t => t.ReferenceNbr!).Distinct().ToList());

        var mxByRef = mxRaw
            .GroupBy(t => primaryRegistrationNbrByReferenceNbr.GetValueOrDefault(t.ReferenceNbr!, t.ReferenceNbr!))
            .ToDictionary(g => g.Key, g => g.Sum(t => t.Amount));

        var jarvisRowsWithRegistrationNbr = creditCardRows.Where(r => r.RegistrationNbr != null).ToList();

        var jarvisByRef = jarvisRowsWithRegistrationNbr
            .GroupBy(r => r.RegistrationNbr!)
            .ToDictionary(g => g.Key, g => g.Sum(r => r.PaymentAmount + (r.ConvenienceFee ?? 0m)));
        var jarvisPrincipalByRef = jarvisRowsWithRegistrationNbr
            .GroupBy(r => r.RegistrationNbr!)
            .ToDictionary(g => g.Key, g => g.Sum(r => r.PaymentAmount));
        var jarvisFeeByRef = jarvisRowsWithRegistrationNbr
            .GroupBy(r => r.RegistrationNbr!)
            .ToDictionary(g => g.Key, g => g.Sum(r => r.ConvenienceFee ?? 0m));

        // Orgs with no MerchantPctToRegistrant (0 or unset) don't charge a convenience fee at all -
        // for them, MX's Amount already equals principal with nothing to back out. Applying the 3%
        // split anyway would fabricate a fee that doesn't exist and flag every transaction as a
        // false split-mismatch, so skip the principal/fee comparison entirely for these orgs.
        var merchantFeePct = await db.Organizations
            .Where(o => orgKeys.Contains(o.OrganizationKey))
            .OrderByDescending(o => o.MerchantPctToRegistrant)
            .Select(o => o.MerchantPctToRegistrant)
            .FirstOrDefaultAsync();
        var chargesConvenienceFee = merchantFeePct is > 0;

        // MxmerchantBatchTxn has no separate convenience-fee column - Amount is the total actually
        // moved (principal + fee). For a charge, MX applies a flat 3% surcharge on top of
        // principal, so Amount = Principal * 1.03 - a fixed, known charge-time rule, safe to back
        // out. A refund has no such rule: whether the convenience fee is returned along with the
        // principal is a per-refund choice (it can go either way), and MX's Amount is a single lump
        // withdrawal with nothing to independently split. Jarvis's own PaymentAmount/ConvenienceFee
        // for that reference nbr (POSTransactionRefundLine.ConvenienceFeeRefunded, ultimately) is
        // the only real record of what was actually chosen, so refunds borrow Jarvis's split
        // instead of guessing at 3%.
        const decimal convenienceFeeRate = 1.03m;
        const decimal splitTolerance = 0.01m;

        (decimal principal, decimal fee) SplitMxAmount(string refNbr, decimal mxAmount)
        {
            if (!chargesConvenienceFee)
                return (mxAmount, 0m);

            if (mxAmount > 0)
            {
                var principal = mxAmount / convenienceFeeRate;
                return (principal, mxAmount - principal);
            }

            return (jarvisPrincipalByRef.GetValueOrDefault(refNbr, mxAmount), jarvisFeeByRef.GetValueOrDefault(refNbr, 0m));
        }

        var mxOnly = new List<VarianceRow>();
        var jarvisOnly = new List<VarianceRow>();
        var mismatched = new List<VarianceRow>();
        var splitMismatched = new List<SplitVarianceRow>();

        foreach (var refNbr in mxByRef.Keys.Union(jarvisByRef.Keys).OrderBy(r => r))
        {
            var hasMx = mxByRef.TryGetValue(refNbr, out var mxAmount);
            var hasJarvis = jarvisByRef.TryGetValue(refNbr, out var jarvisAmount);

            if (hasMx && hasJarvis)
            {
                if (mxAmount != jarvisAmount)
                {
                    mismatched.Add(new VarianceRow(refNbr, mxAmount, jarvisAmount));
                }
                else if (chargesConvenienceFee && mxAmount > 0)
                {
                    // Totals agree, so this transaction never shows up as a discrepancy anywhere
                    // else - but the principal/fee split underneath it can still be wrong. Only
                    // meaningful for charges - refunds borrow Jarvis's own split (see SplitMxAmount),
                    // so they'd never disagree with themselves here.
                    var (mxPrincipal, mxFee) = SplitMxAmount(refNbr, mxAmount);
                    var jarvisPrincipal = jarvisPrincipalByRef.GetValueOrDefault(refNbr, 0m);
                    var jarvisFee = jarvisFeeByRef.GetValueOrDefault(refNbr, 0m);

                    if (Math.Abs(mxPrincipal - jarvisPrincipal) > splitTolerance || Math.Abs(mxFee - jarvisFee) > splitTolerance)
                        splitMismatched.Add(new SplitVarianceRow(refNbr, mxPrincipal, mxFee, jarvisPrincipal, jarvisFee));
                }
            }
            else if (hasMx)
                mxOnly.Add(new VarianceRow(refNbr, mxAmount, null));
            else
                jarvisOnly.Add(new VarianceRow(refNbr, null, jarvisAmount));
        }

        var mxTotal = mxByRef.Values.Sum();
        var mxPrincipalTotal = mxByRef.Sum(kv => SplitMxAmount(kv.Key, kv.Value).principal);
        var mxFeeTotal = mxByRef.Sum(kv => SplitMxAmount(kv.Key, kv.Value).fee);

        var jarvisTotal = jarvisByRef.Values.Sum();
        var jarvisPrincipalTotal = jarvisRowsWithRegistrationNbr.Sum(r => r.PaymentAmount);
        var jarvisFeeTotal = jarvisRowsWithRegistrationNbr.Sum(r => r.ConvenienceFee ?? 0m);

        return new CreditCardBatchComparison(
            mxTotal, jarvisTotal, mxPrincipalTotal, mxFeeTotal, jarvisPrincipalTotal, jarvisFeeTotal,
            mxOnly, jarvisOnly, mismatched, splitMismatched);
    });

    // Mirrors rpt_paidbycreditcard's own POS consolidation: for every POSTransactionKey any of these
    // reference nbrs belongs to, finds the "primary" payment row (highest PaymentAmount, excluding
    // ConfirmationNbr IN ('REFUND','VOID') - same ROW_NUMBER/rn=1 tiebreak the SP uses) and maps
    // every row for that transaction, including refund rows, to the primary row's RegistrationNbr.
    // Reference nbrs that aren't POS payments at all are simply absent from the returned map.
    private async Task<Dictionary<string, string>> GetPosPrimaryRegistrationNbrMapAsync(List<string> referenceNbrs)
    {
        var map = new Dictionary<string, string>();
        if (referenceNbrs.Count == 0)
            return map;

        var posTransactionKeys = await db.PostransactionPayments
            .Where(x => x.RegistrationNbr != null && referenceNbrs.Contains(x.RegistrationNbr))
            .Select(x => x.PostransactionKey)
            .Distinct()
            .ToListAsync();

        if (posTransactionKeys.Count == 0)
            return map;

        var allRows = await db.PostransactionPayments
            .Where(x => posTransactionKeys.Contains(x.PostransactionKey) && x.RegistrationNbr != null)
            .Select(x => new { x.PostransactionKey, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PostransactionPaymentKey, x.ConfirmationNbr })
            .ToListAsync();

        foreach (var group in allRows.GroupBy(x => x.PostransactionKey))
        {
            var primary = group
                .Where(x => !string.Equals(x.ConfirmationNbr, "REFUND", StringComparison.OrdinalIgnoreCase)
                            && !string.Equals(x.ConfirmationNbr, "VOID", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(x => x.PaymentAmount)
                .ThenByDescending(x => x.PaymentDate)
                .ThenByDescending(x => x.PostransactionPaymentKey)
                .FirstOrDefault();

            if (primary is null)
                continue;

            foreach (var row in group)
                map[row.RegistrationNbr!] = primary.RegistrationNbr!;
        }

        return map;
    }

    // Breaks a batch's variance down by reference/registration nbr: present on the MX side only,
    // present on the Jarvis side only, or present on both with a differing summed amount. Nbrs
    // present on both sides with matching amounts aren't discrepancies and are left out entirely.
    public Task<BatchVarianceDetail> GetBatchVarianceDetailAsync(int mxmerchantBatchKey)
        => RunAsync(async () =>
    {
        var batch = await db.MxmerchantBatches.SingleAsync(b => b.MxmerchantBatchKey == mxmerchantBatchKey);

        await MatchSplitJarvisRecordsAsync(batch);

        var mxByRef = await db.MxmerchantBatchTxns
            .Where(t => t.OrganizationKey == batch.OrganizationKey && (long?)t.BatchId == batch.BatchNumber && t.ReferenceNbr != null)
            .GroupBy(t => t.ReferenceNbr!)
            .Select(g => new { ReferenceNbr = g.Key, Amount = g.Sum(t => t.Amount) })
            .ToDictionaryAsync(x => x.ReferenceNbr, x => x.Amount);

        var jarvisByRef = await GetJarvisAmountsByBatchNumberAsync(batch.BatchNumber);

        var mxOnly = new List<VarianceRow>();
        var jarvisOnly = new List<VarianceRow>();
        var mismatched = new List<VarianceRow>();

        foreach (var refNbr in mxByRef.Keys.Union(jarvisByRef.Keys).OrderBy(r => r))
        {
            var hasMx = mxByRef.TryGetValue(refNbr, out var mxAmount);
            var hasJarvis = jarvisByRef.TryGetValue(refNbr, out var jarvisAmount);

            if (hasMx && hasJarvis)
            {
                if (mxAmount != jarvisAmount)
                    mismatched.Add(new VarianceRow(refNbr, mxAmount, jarvisAmount));
            }
            else if (hasMx)
                mxOnly.Add(new VarianceRow(refNbr, mxAmount, null));
            else
                jarvisOnly.Add(new VarianceRow(refNbr, null, jarvisAmount));
        }

        return new BatchVarianceDetail(mxOnly, jarvisOnly, mismatched);
    });

    public Task UpdateJarvisAmountAsync(int mxmerchantBatchKey, decimal jarvisAmount)
        => RunAsync(async () =>
    {
        var batch = await db.MxmerchantBatches.SingleAsync(b => b.MxmerchantBatchKey == mxmerchantBatchKey);
        batch.JarvisAmount = jarvisAmount;
        await db.SaveChangesAsync();
    });

    // Sum of every Jarvis row (across all 16 payment tables) stamped with this batch's BatchNumber -
    // the Jarvis-side total to compare against the batch's own MxmerchantAmount.
    public Task<decimal> GetJarvisTotalByBatchNumberAsync(int mxmerchantBatchKey)
        => RunAsync(async () =>
    {
        var batch = await db.MxmerchantBatches.SingleAsync(b => b.MxmerchantBatchKey == mxmerchantBatchKey);
        await MatchSplitJarvisRecordsAsync(batch);
        var jarvisByRef = await GetJarvisAmountsByBatchNumberAsync(batch.BatchNumber);
        return jarvisByRef.Values.Sum();
    });

    // A single MX charge sometimes corresponds to several Jarvis rows for the same RegistrationNbr
    // (e.g. a split payment), so the legacy per-row equality match never stamps
    // MerchantBatchId/MerchantBatchIdNum on any of them and they sit as permanent "MX Only" variance.
    // Runs automatically whenever this batch's totals are compared: sums still-unstamped rows per
    // RegistrationNbr (per table) and, where that sum equals the MX total for the same reference
    // nbr, stamps all of those rows with this batch's id. DailyBarcodeTicket, Payment,
    // PaymentFacility, POSTransactionPayment, PaymentLockerRental, PaymentSeasonPass,
    // PaymentSpecialEvent, PaymentTourRegistration, PaymentMembership, PaymentSponsor,
    // AccountCreditManualSource and AccountCreditReturnSource are covered so far - extend with
    // another StampMatching*Async call below if another table needs it.
    private async Task MatchSplitJarvisRecordsAsync(MxmerchantBatch batch)
    {
        if (batch.BatchNumber is null)
            return;

        var mxByRef = await db.MxmerchantBatchTxns
            .Where(t => t.OrganizationKey == batch.OrganizationKey && t.BatchId == batch.BatchNumber && t.ReferenceNbr != null)
            .GroupBy(t => t.ReferenceNbr!)
            .Select(g => new { ReferenceNbr = g.Key, Amount = g.Sum(t => t.Amount) })
            .ToDictionaryAsync(x => x.ReferenceNbr, x => x.Amount);

        if (mxByRef.Count == 0)
            return;

        var referenceNbrs = mxByRef.Keys.ToList();

        var changed = false;
        changed |= await StampMatchingDailyBarcodeTicketsAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPaymentsAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPostransactionPaymentsAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPaymentFacilitiesAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPaymentLockerRentalsAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPaymentSeasonPassesAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPaymentSpecialEventsAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPaymentTourRegistrationsAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPaymentMembershipsAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingPaymentSponsorsAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingAccountCreditManualSourcesAsync(batch, mxByRef, referenceNbrs);
        changed |= await StampMatchingAccountCreditReturnSourcesAsync(batch, mxByRef, referenceNbrs);

        if (changed)
            await db.SaveChangesAsync();
    }

    // Groups unstamped rows by RegistrationNbr and stamps every row in a group whose summed amount
    // equals the MX total for that reference nbr. Caller is responsible for calling SaveChangesAsync.
    private static bool StampMatchingGroups<T>(IEnumerable<T> unstampedRows, Func<T, string> registrationNbr,
        Func<T, decimal> amount, Action<T> stamp, IReadOnlyDictionary<string, decimal> mxByRef)
    {
        var changed = false;

        foreach (var group in unstampedRows.GroupBy(registrationNbr))
        {
            if (!mxByRef.TryGetValue(group.Key, out var mxTotal) || group.Sum(amount) != mxTotal)
                continue;

            foreach (var row in group)
                stamp(row);

            changed = true;
        }

        return changed;
    }

    private async Task<bool> StampMatchingDailyBarcodeTicketsAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await db.DailyBarcodeTickets
            .Where(t => t.OrganizationKey == batch.OrganizationKey && t.RegistrationNbr != null
                && referenceNbrs.Contains(t.RegistrationNbr) && t.MerchantBatchIdNum == null && t.PostransactionKey == null && t.PaymentType != "CREDIT")
            .ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount ?? 0m,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // Payment has no OrganizationKey column directly - it's reached through
    // RegistrantToLeague -> League -> Season, same join chain GetBlankMerchantIdTransactionsAsync uses.
    private async Task<bool> StampMatchingPaymentsAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await (
            from x in db.Payments
            join rtl in db.RegistrantToLeagues on x.RegistrantToLeagueKey equals rtl.RegistrantToLeagueKey
            join lg in db.Leagues on rtl.LeagueKey equals lg.LeagueKey
            join se in db.Seasons on lg.SeasonKey equals se.SeasonKey
            where se.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr))))
            select x
        ).ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // PaymentFacility has no OrganizationKey column directly - it's reached through
    // FacilityReservation, same join chain GetBlankMerchantIdTransactionsAsync uses. A RegistrationNbr
    // can span several rows here (e.g. a security deposit payment plus the reservation payment), so
    // this needs the same group-and-sum matching as Payment, not the single-row match used for
    // POSTransactionPayment.
    private async Task<bool> StampMatchingPaymentFacilitiesAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await (
            from x in db.PaymentFacilities
            join fr in db.FacilityReservations on x.FacilityReservationKey equals fr.FacilityReservationKey
            where fr.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr))))
            select x
        ).ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // Unlike DailyBarcodeTicket/Payment, a RegistrationNbr is never split across multiple
    // POSTransactionPayment rows - each reference nbr on this table already lines up with exactly
    // one payment row, so there's nothing to group and sum. Match each unstamped row's own
    // PaymentAmount directly against the MX total for its reference nbr.
    private async Task<bool> StampMatchingPostransactionPaymentsAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await db.PostransactionPayments
            .Where(x => x.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && x.PaymentType != "CREDIT")
            .ToListAsync();

        var changed = false;

        foreach (var row in unstampedRows)
        {
            if (!mxByRef.TryGetValue(row.RegistrationNbr!, out var mxTotal) || row.PaymentAmount != mxTotal)
                continue;

            row.MerchantBatchId = batch.BatchId;
            row.MerchantBatchIdNum = batch.BatchNumber;
            changed = true;
        }

        return changed;
    }

    // PaymentSeasonPass has no OrganizationKey column directly - it's reached through SeasonPass,
    // same join chain GetBlankMerchantIdTransactionsAsync uses. A RegistrationNbr can span several
    // rows here, so this needs the same group-and-sum matching as Payment/PaymentFacility.
    private async Task<bool> StampMatchingPaymentSeasonPassesAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await (
            from x in db.PaymentSeasonPasses
            join sp in db.SeasonPasses on x.SeasonPassKey equals sp.SeasonPassKey
            where sp.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr))))
            select x
        ).ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // PaymentSpecialEvent has no OrganizationKey column directly - it's reached through SpecialEvent,
    // same join chain GetBlankMerchantIdTransactionsAsync uses. A RegistrationNbr can span several
    // rows here, so this needs the same group-and-sum matching as Payment/PaymentFacility.
    private async Task<bool> StampMatchingPaymentSpecialEventsAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await (
            from x in db.PaymentSpecialEvents
            join sev in db.SpecialEvents on x.SpecialEventKey equals sev.SpecialEventKey
            where sev.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr))))
            select x
        ).ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // PaymentTourRegistration has no OrganizationKey column directly - it's reached through
    // TourRegistration, same join chain GetBlankMerchantIdTransactionsAsync uses. A RegistrationNbr
    // can span several rows here, so this needs the same group-and-sum matching as Payment/PaymentFacility.
    private async Task<bool> StampMatchingPaymentTourRegistrationsAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await (
            from x in db.PaymentTourRegistrations
            join tr in db.TourRegistrations on x.TourRegistrationKey equals tr.TourRegistrationKey
            where tr.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr))))
            select x
        ).ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // A RegistrationNbr can span several rows here, so this needs the same group-and-sum matching
    // as Payment/PaymentFacility.
    private async Task<bool> StampMatchingPaymentMembershipsAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await db.PaymentMemberships
            .Where(x => x.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && x.PaymentType != "CREDIT")
            .ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // A RegistrationNbr can span several rows here, so this needs the same group-and-sum matching
    // as Payment/PaymentFacility. PaymentAmount is nullable on this table - default to 0m like the
    // other Jarvis-total queries do.
    private async Task<bool> StampMatchingPaymentSponsorsAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await db.PaymentSponsors
            .Where(x => x.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && (x.PaymentType != "CREDIT" && !((x.PaymentNotes ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .ToListAsync();

        // LastUpdatedBy names this job in the Audit_PaymentSponsor row the update writes
        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; t.LastUpdatedBy = "MX Reconcile"; }, mxByRef);
    }

    // A RegistrationNbr can span several rows here, so this needs the same group-and-sum matching
    // as Payment/PaymentFacility.
    private async Task<bool> StampMatchingAccountCreditManualSourcesAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await db.AccountCreditManualSources
            .Where(x => x.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.PaymentAmount,
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // A RegistrationNbr can span several rows here, so this needs the same group-and-sum matching
    // as Payment/PaymentFacility. ReturnAmount is net of the convenience fee (ConvenienceFee is
    // tracked separately, same split as Payment.PaymentAmount/ConvenienceFee) while mxByRef is MX's
    // gross Amount - without adding ConvenienceFee back in, a full credit on a fee-charging org's
    // registration never sums to the MX total and this never gets a chance to stamp. Rows with no
    // real AccountCreditLedgerHeader (see GetJarvisAmountsByBatchNumberAsync) never moved money and
    // are skipped so they don't get a batch stamp they have no business having.
    private async Task<bool> StampMatchingAccountCreditReturnSourcesAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await db.AccountCreditReturnSources
            .Where(x => x.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && x.PaymentType != "CREDIT"
                && db.AccountCreditLedgerHeaders.Any(h => h.AccountCreditLedgerHeaderKey == x.AccountCreditLedgerHeaderKey))
            .ToListAsync();

        return StampMatchingGroups(unstampedRows, t => t.RegistrationNbr!, t => t.ReturnAmount + (t.ConvenienceFee ?? 0m),
            t => { t.MerchantBatchId = batch.BatchId; t.MerchantBatchIdNum = batch.BatchNumber; }, mxByRef);
    }

    // Like POSTransactionPayment, a RegistrationNbr is never split across multiple
    // PaymentLockerRental rows - match each unstamped row's own PaymentAmount directly against the
    // MX total for its reference nbr, no group-and-sum needed.
    private async Task<bool> StampMatchingPaymentLockerRentalsAsync(MxmerchantBatch batch,
        IReadOnlyDictionary<string, decimal> mxByRef, List<string> referenceNbrs)
    {
        var unstampedRows = await db.PaymentLockerRentals
            .Where(x => x.OrganizationKey == batch.OrganizationKey && x.RegistrationNbr != null
                && referenceNbrs.Contains(x.RegistrationNbr) && x.MerchantBatchIdNum == null && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .ToListAsync();

        var changed = false;

        foreach (var row in unstampedRows)
        {
            if (!mxByRef.TryGetValue(row.RegistrationNbr!, out var mxTotal) || row.PaymentAmount != mxTotal)
                continue;

            row.MerchantBatchId = batch.BatchId;
            row.MerchantBatchIdNum = batch.BatchNumber;
            changed = true;
        }

        return changed;
    }

    // A RegistrationNbr's charge can be split across any of these 16 live payment tables (confirmed
    // with the business owner). PaymentPo/PaymentPos and CoachApplication are deprecated and excluded.
    // Filtered to rows stamped with this exact batch number rather than by reference nbr - "Jarvis
    // only" rows have no corresponding MX transaction to look their reference nbr up from.
    private async Task<Dictionary<string, decimal>> GetJarvisAmountsByBatchNumberAsync(long? batchNumber)
    {
        var result = new Dictionary<string, decimal>();
        if (batchNumber == null)
            return result;

        var rows = new List<RegistrationNbrAmountRow>();

        rows.AddRange(await db.Payments
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentMemberships
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && x.PaymentType != "CREDIT")
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentFacilities
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentSeasonPasses
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentSpecialEvents
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentLockerRentals
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentTeams
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentTourRegistrations
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentSponsors
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentNotes ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentVendors
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && x.PaymentType != "CREDIT")
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount ?? 0m, null))
            .ToListAsync());

        rows.AddRange(await db.PostransactionPayments
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && x.PaymentType != "CREDIT")
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        rows.AddRange(await db.DailyBarcodeTickets
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && x.PaymentType != "CREDIT")
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount ?? 0m, null))
            .ToListAsync());

        rows.AddRange(await db.Donations
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount ?? 0m, null))
            .ToListAsync());

        rows.AddRange(await db.AccountCredits
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.CreditBalanceAmount, null))
            .ToListAsync());

        rows.AddRange(await db.AccountCreditManualSources
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        // AccountCreditReturnSource is a refund-to-credit of an earlier card payment (from Payment,
        // PaymentFacility, or PaymentMembership - SourceTable/SourceTableKey say which). Its own
        // MerchantBatchIdNum is frequently stamped to the batch of the credit-generation date, not
        // the batch where the original card money settled - so prefer attributing ReturnAmount to
        // the ORIGIN row's batch instead.
        //
        // ConvenienceFee is always added back, whether or not the origin row survived. ReturnAmount
        // is principal only - the prorated fee is split out into ConvenienceFee the same way Payment
        // splits PaymentAmount/ConvenienceFee - and a partial credit reduces the origin row's
        // PaymentAmount by the fee-INCLUSIVE amount returned, not by ReturnAmount alone. So the
        // invariant is:
        //     residual origin PaymentAmount + ReturnAmount + ConvenienceFee == original MX gross
        // and leaving the fee out here leaves the batch short by exactly the sum of the returns'
        // fees. A FULL credit deletes the origin row entirely - that's the reason this table exists
        // at all - and then ReturnAmount + ConvenienceFee reconstructs the whole gross on its own,
        // so the same expression covers both cases. When the origin row is gone (or SourceTable is
        // some other/unrecognized value this join doesn't know about), fall back to the return
        // source's own MerchantBatchIdNum, which StampMatchingAccountCreditReturnSourcesAsync
        // stamps directly onto it for exactly that case.
        //
        // A handful of rows point at an AccountCreditLedgerHeaderKey that doesn't actually exist in
        // AccountCreditLedgerHeader (a failed/retried credit operation left the return-source row
        // behind without ever creating the ledger entry that makes the credit real) - those never
        // moved any money and must be excluded, or they inflate the total for nothing.
        rows.AddRange(await (
            from x in db.AccountCreditReturnSources
            join p in db.Payments on x.SourceTableKey equals p.PaymentKey into pj
            from p in pj.DefaultIfEmpty()
            join pf in db.PaymentFacilities on x.SourceTableKey equals pf.PaymentFacilityKey into pfj
            from pf in pfj.DefaultIfEmpty()
            join pm in db.PaymentMemberships on x.SourceTableKey equals pm.PaymentMembershipKey into pmj
            from pm in pmj.DefaultIfEmpty()
            where x.RegistrationNbr != null && x.PaymentType != "CREDIT"
                  && db.AccountCreditLedgerHeaders.Any(h => h.AccountCreditLedgerHeaderKey == x.AccountCreditLedgerHeaderKey)
                  && (
                      (x.SourceTable == "Payment" ? (p != null ? p.MerchantBatchIdNum : x.MerchantBatchIdNum)
                       : x.SourceTable == "PaymentFacility" ? (pf != null ? pf.MerchantBatchIdNum : x.MerchantBatchIdNum)
                       : x.SourceTable == "PaymentMembership" ? (pm != null ? pm.MerchantBatchIdNum : x.MerchantBatchIdNum)
                       : x.MerchantBatchIdNum) == batchNumber
                  )
            select new RegistrationNbrAmountRow(x.RegistrationNbr!,
                x.ReturnAmount + (x.ConvenienceFee ?? 0m),
                null)
        ).ToListAsync());

        // AccountDonation has no PaymentAmount field - DonationAmount is the amount actually charged.
        rows.AddRange(await db.AccountDonations
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber && x.PaymentType != "CREDIT")
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.DonationAmount, null))
            .ToListAsync());

        rows.AddRange(await db.PaymentMerchandises
            .Where(x => x.RegistrationNbr != null && x.MerchantBatchIdNum == batchNumber &&(x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))))
            .Select(x => new RegistrationNbrAmountRow(x.RegistrationNbr!, x.PaymentAmount, null))
            .ToListAsync());

        foreach (var group in rows.GroupBy(r => r.RegistrationNbr))
            result[group.Key] = group.Sum(r => r.Amount);

        return result;
    }

    // Every Jarvis row (across all 16 payment tables) carrying this exact reference/registration
    // nbr, regardless of organization or batch - lets a user drill into a single Reference Nbr from
    // the Transaction Detail tab and see everywhere it was found plus its batch-stamping state.
    public Task<List<ReferenceNbrDetailRow>> GetReferenceNbrDetailAsync(string referenceNbr)
        => RunAsync(async () =>
    {
        var rows = new List<ReferenceNbrDetailRow>();

        rows.AddRange(await db.Payments
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("Payment", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentMemberships
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentMembership", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentFacilities
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentFacility", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentSeasonPasses
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentSeasonPass", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentSpecialEvents
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentSpecialEvent", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentLockerRentals
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentLockerRental", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentTeams
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentTeam", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentTourRegistrations
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentTourRegistration", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentSponsors
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentSponsor", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentVendors
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentVendor", x.PaymentAmount ?? 0m, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PostransactionPayments
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PostransactionPayment", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.DailyBarcodeTickets
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("DailyBarcodeTicket", x.PaymentAmount ?? 0m, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.IssuedAt))
            .ToListAsync());

        rows.AddRange(await db.Donations
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("Donation", x.PaymentAmount ?? 0m, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.AccountCredits
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("AccountCredit", x.CreditBalanceAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.AccountCreditManualSources
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("AccountCreditManualSource", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        // No PaymentDate on this table - ReturnDate is when the credit was posted.
        rows.AddRange(await db.AccountCreditReturnSources
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("AccountCreditReturnSource", x.ReturnAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.ReturnDate))
            .ToListAsync());

        // AccountDonation has no PaymentAmount field - DonationAmount is the amount actually charged.
        rows.AddRange(await db.AccountDonations
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("AccountDonation", x.DonationAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        rows.AddRange(await db.PaymentMerchandises
            .Where(x => x.RegistrationNbr == referenceNbr)
            .Select(x => new ReferenceNbrDetailRow("PaymentMerchandise", x.PaymentAmount, x.ConfirmationNbr, x.MerchantBatchId, x.MerchantBatchIdNum, x.PaymentDate))
            .ToListAsync());

        return rows.OrderByDescending(r => r.PaymentDate).ToList();
    });

    // Per-organization cutoff dates before which Jarvis history shouldn't be checked here - either
    // because the org converted to MX Merchant from a different card processor (pre-conversion
    // history predates MX Merchant entirely and would never have gotten a MerchantBatchId(Num)
    // stamp, showing up as a false-positive discrepancy) or another org-specific reason to exclude
    // older records. Add an entry (with the cutoff date) for each org as needed.
    private static readonly Dictionary<int, DateTime> GatewayGoLiveDates = new()
    {
        [128] = new DateTime(2026, 5, 16),
        [34] = new DateTime(2026, 7, 10),
        [103] = new DateTime(2026, 7, 22),
        [132] = new DateTime(2026, 8, 5),
        [81] = new DateTime(2026, 8, 5),
        [79] = new DateTime(2026, 9, 2),
        [158] = new DateTime(2026, 9, 2),
    };

    // Jarvis-side card/EMV payment rows that were never fully stamped by the nightly reconciliation
    // job - flagged if EITHER MerchantBatchId (string) or MerchantBatchIdNum (long) is null, so a
    // half-stamped row counts as blank too. Across all history except today and yesterday (today's
    // batch hasn't run yet, and yesterday's may still be settling, so blanks there are expected,
    // not a discrepancy). Scoped to MX-gateway organizations - several of the 16 payment tables
    // don't carry OrganizationKey directly and need a join chain through their parent entity
    // (or through League/Season, for Payment and PaymentTeam) to reach it.
    // Voided transactions never get a batch id, so both the VOID reversal row and the original
    // row it reverses (same RegistrationNbr) are excluded per table.
    public Task<List<BlankMerchantIdRow>> GetBlankMerchantIdTransactionsAsync(IReadOnlyList<int> organizationKeys)
        => RunAsync(async () =>
    {
        var cutoff = DateTime.Today.AddDays(-1);
        GatewayGoLiveDates.TryGetValue(128, out var org128GoLive);
        GatewayGoLiveDates.TryGetValue(34, out var org34ExcludeBefore);
        GatewayGoLiveDates.TryGetValue(103, out var org103ExcludeBefore);
        GatewayGoLiveDates.TryGetValue(132, out var org132ExcludeBefore);
        GatewayGoLiveDates.TryGetValue(81, out var org81ExcludeBefore);
        GatewayGoLiveDates.TryGetValue(79, out var org79ExcludeBefore);
        GatewayGoLiveDates.TryGetValue(158, out var org158ExcludeBefore);

        // OrganizationKey 32 is a test organization - excluded from every check on this page.
        var qualifyingOrgs = db.Organizations
            .Where(o => o.GatewayUsed == MxGateway && o.OrganizationKey != 32
                        && (organizationKeys.Count == 0 || organizationKeys.Contains(o.OrganizationKey)));

        var rows = new List<BlankMerchantIdRow>();

        rows.AddRange(await (
            from x in db.Payments
            join rtl in db.RegistrantToLeagues on x.RegistrantToLeagueKey equals rtl.RegistrantToLeagueKey
            join lg in db.Leagues on rtl.LeagueKey equals lg.LeagueKey
            join se in db.Seasons on lg.SeasonKey equals se.SeasonKey
            join o in qualifyingOrgs on se.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.Payments.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"Payment:{x.PaymentKey}", "Payment", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentTeams
            join tm in db.Teams on x.TeamKey equals tm.TeamKey
            join lg in db.Leagues on tm.LeagueKey equals lg.LeagueKey
            join se in db.Seasons on lg.SeasonKey equals se.SeasonKey
            join o in qualifyingOrgs on se.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentTeams.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentTeam:{x.PaymentTeamKey}", "PaymentTeam", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentFacilities
            join fr in db.FacilityReservations on x.FacilityReservationKey equals fr.FacilityReservationKey
            join o in qualifyingOrgs on fr.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentFacilities.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentFacility:{x.PaymentFacilityKey}", "PaymentFacility", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentSeasonPasses
            join sp in db.SeasonPasses on x.SeasonPassKey equals sp.SeasonPassKey
            join o in qualifyingOrgs on sp.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentSeasonPasses.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentSeasonPass:{x.PaymentSeasonPassKey}", "PaymentSeasonPass", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentSpecialEvents
            join sev in db.SpecialEvents on x.SpecialEventKey equals sev.SpecialEventKey
            join o in qualifyingOrgs on sev.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentSpecialEvents.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentSpecialEvent:{x.PaymentSpecialEventKey}", "PaymentSpecialEvent", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentTourRegistrations
            join tr in db.TourRegistrations on x.TourRegistrationKey equals tr.TourRegistrationKey
            join o in qualifyingOrgs on tr.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentTourRegistrations.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentTourRegistration:{x.PaymentTourRegistrationKey}", "PaymentTourRegistration", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.AccountCredits
            join a in db.Accounts on x.AccountKey equals a.AccountKey
            join o in qualifyingOrgs on a.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.CreditBalanceAmount > 0
                  && (x.PaymentDate == null || x.PaymentDate.Value.Date < cutoff)
                  && (o.OrganizationKey != 128 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org158ExcludeBefore)
                  && !db.AccountCredits.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"AccountCredit:{x.AccountCreditKey}", "AccountCredit", o.OrganizationName, x.RegistrationNbr, x.CreditBalanceAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.AccountCreditManualSources
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr))))
                  && (x.PaymentDate == null || x.PaymentDate.Value.Date < cutoff)
                  && (o.OrganizationKey != 128 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org158ExcludeBefore)
                  && !db.AccountCreditManualSources.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"AccountCreditManualSource:{x.AccountCreditManualSourceKey}", "AccountCreditManualSource", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        // No PaymentDate on this table - ReturnDate (when the credit was posted) is the equivalent.
        rows.AddRange(await (
            from x in db.AccountCreditReturnSources
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && x.PaymentType != "CREDIT" && x.ReturnDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.ReturnDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.ReturnDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.ReturnDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.ReturnDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.ReturnDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.ReturnDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.ReturnDate.Date >= org158ExcludeBefore)
                  && !db.AccountCreditReturnSources.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"AccountCreditReturnSource:{x.AccountCreditReturnSourceKey}", "AccountCreditReturnSource", o.OrganizationName, x.RegistrationNbr, x.ReturnAmount, x.ReturnDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentMemberships
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && x.PaymentType != "CREDIT" && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentMemberships.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentMembership:{x.PaymentMembershipKey}", "PaymentMembership", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentLockerRentals
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentLockerRentals.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentLockerRental:{x.PaymentLockerRentalKey}", "PaymentLockerRental", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentSponsors
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentNotes ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr))))
                  && (x.PaymentDate.Date < cutoff)
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentSponsors.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentSponsor:{x.PaymentSponsorKey}", "PaymentSponsor", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentVendors
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && x.PaymentType != "CREDIT"
                  && (x.PaymentDate == null || x.PaymentDate.Value.Date < cutoff)
                  && (o.OrganizationKey != 128 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org158ExcludeBefore)
                  && !db.PaymentVendors.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentVendor:{x.PaymentVendorKey}", "PaymentVendor", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount ?? 0m, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.DailyBarcodeTickets
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && x.PaymentType != "CREDIT" && x.IssuedAt.Date < cutoff
                  && (o.OrganizationKey != 128 || x.IssuedAt.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.IssuedAt.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.IssuedAt.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.IssuedAt.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.IssuedAt.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.IssuedAt.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.IssuedAt.Date >= org158ExcludeBefore)
                  && !db.DailyBarcodeTickets.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"DailyBarcodeTicket:{x.DailyBarcodeTicketKey}", "DailyBarcodeTicket", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount ?? 0m, x.IssuedAt, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.Donations
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr))))
                  && (x.PaymentDate == null || x.PaymentDate.Value.Date < cutoff)
                  && (o.OrganizationKey != 128 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org158ExcludeBefore)
                  && !db.Donations.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"Donation:{x.DonationKey}", "Donation", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount ?? 0m, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.AccountDonations
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && x.PaymentType != "CREDIT"
                  && (x.PaymentDate == null || x.PaymentDate.Value.Date < cutoff)
                  && (o.OrganizationKey != 128 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate == null || x.PaymentDate.Value.Date >= org158ExcludeBefore)
                  && !db.AccountDonations.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"AccountDonation:{x.AccountDonationKey}", "AccountDonation", o.OrganizationName, x.RegistrationNbr, x.DonationAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PostransactionPayments
            join o in qualifyingOrgs on x.OrganizationKey equals (int?)o.OrganizationKey
            join pt in db.Postransactions on x.PostransactionKey equals pt.PostransactionKey
            where x.RegistrationNbr != null && (x.MerchantBatchIdNum == null || x.MerchantBatchId == null) && x.PaymentType != "SCH" && x.PaymentType != "CHK" && x.PaymentType != "CREDIT" && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && pt.TransactionStatus != "PENDING"
                  && !db.PostransactionPayments.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PostransactionPayment:{x.PostransactionPaymentKey}", "PostransactionPayment", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        rows.AddRange(await (
            from x in db.PaymentMerchandises
            join o in qualifyingOrgs on x.OrganizationKey equals o.OrganizationKey
            where x.RegistrationNbr != null && (x.MerchantBatchId == null || x.MerchantBatchIdNum == null) &&x.PaymentType != "SCH" && x.PaymentType != "CHK" && (x.PaymentType != "CREDIT" && !((x.PaymentComments ?? "").StartsWith("Used Credit from:") && (db.AccountCreditReturnSources.Any(csr => csr.RegistrationNbr == x.RegistrationNbr) || db.AccountCreditManualSources.Any(csm => csm.RegistrationNbr == x.RegistrationNbr)))) && x.PaymentDate.Date < cutoff
                  && (o.OrganizationKey != 128 || x.PaymentDate.Date >= org128GoLive)
                  && (o.OrganizationKey != 34 || x.PaymentDate.Date >= org34ExcludeBefore)
                  && (o.OrganizationKey != 103 || x.PaymentDate.Date >= org103ExcludeBefore)
                  && (o.OrganizationKey != 132 || x.PaymentDate.Date >= org132ExcludeBefore)
                  && (o.OrganizationKey != 81 || x.PaymentDate.Date >= org81ExcludeBefore)
                  && (o.OrganizationKey != 79 || x.PaymentDate.Date >= org79ExcludeBefore)
                  && (o.OrganizationKey != 158 || x.PaymentDate.Date >= org158ExcludeBefore)
                  && !db.PaymentMerchandises.Any(v => v.ConfirmationNbr == "VOID" && v.RegistrationNbr == x.RegistrationNbr)
            select new BlankMerchantIdRow($"PaymentMerchandise:{x.PaymentMerchandiseKey}", "PaymentMerchandise", o.OrganizationName, x.RegistrationNbr, x.PaymentAmount, x.PaymentDate, x.PaymentType)
        ).ToListAsync());

        return rows.OrderByDescending(r => r.TransactionDate).ToList();
    });

    private IQueryable<MxmerchantBatch> QualifyingBatches(IReadOnlyList<int> organizationKeys, DateOnly? date, int? batchKey)
    {
        var query = db.MxmerchantBatches
            .Where(b => db.Organizations.Any(o => o.OrganizationKey == b.OrganizationKey && o.GatewayUsed == MxGateway && o.OrganizationKey != 32));

        if (batchKey.HasValue)
            return query.Where(b => b.MxmerchantBatchKey == batchKey.Value);

        if (organizationKeys.Count > 0)
            query = query.Where(b => organizationKeys.Contains(b.OrganizationKey));

        if (date.HasValue)
        {
            var day = date.Value.ToDateTime(TimeOnly.MinValue);
            query = query.Where(b => b.BatchOpenDate != null && b.BatchOpenDate.Value.Date == day);
        }

        return query;
    }

    // POSTransaction + POSTransactionItem (+ any POSTransactionPayment) rows for one register sale
    // (EMV Logs tab "Check Pending Sale") - shows whether the sale behind an unrecorded EMV payment
    // was left pending or finalized. Null when no POSTransaction row has that key.
    public Task<PosTransactionDetail?> GetPosTransactionDetailAsync(int postransactionKey)
        => RunAsync(async () =>
    {
        var items = await db.PostransactionItems
            .Where(i => i.PostransactionKey == postransactionKey)
            .OrderBy(i => i.TransactionItemId)
            .Select(i => new PosTransactionItemRow(
                i.TransactionItemId, i.ItemDescription, i.CustomerName, i.PositemKey, i.PosproductKey,
                i.UnitPrice, i.Quantity, i.SubtotalAmount, i.ConvenienceFeeAmount, i.TaxAmount, i.TotalDue,
                i.RevenueCode, i.DateTimeAdded))
            .ToListAsync();

        var payments = await db.PostransactionPayments
            .Where(p => p.PostransactionKey == postransactionKey)
            .OrderBy(p => p.PostransactionPaymentKey)
            .Select(p => new PosTransactionPaymentRow(
                p.PostransactionPaymentKey, p.PaymentDate, p.PaymentAmount, p.ConvenienceFee, p.PaymentType,
                p.RegistrationNbr, p.ConfirmationNbr, p.ShiftKey, p.PaymentPostedBy, p.PaymentNotes))
            .ToListAsync();

        var header = await db.Postransactions
            .Where(t => t.PostransactionKey == postransactionKey)
            .Select(t => new PosTransactionDetail(
                t.PostransactionKey,
                t.OrganizationKey,
                db.Organizations.Where(o => o.OrganizationKey == t.OrganizationKey).Select(o => o.OrganizationName).FirstOrDefault(),
                t.PoslocationKey,
                db.Poslocations.Where(l => l.PoslocationKey == t.PoslocationKey).Select(l => l.LocationName).FirstOrDefault(),
                t.TransactionStatus, t.DateTimeEntered, t.EnteredByUser, t.SubtotalAmount, t.DiscountAmount, t.DiscountCodeKey,
                t.TotalTaxAmount, t.ConvenienceFee, t.TotalDue, t.TotalPaid, t.RefundReason, t.XOriginalTransactionId,
                new List<PosTransactionItemRow>(),
                new List<PosTransactionPaymentRow>(),
                db.Organizations.Where(o => o.OrganizationKey == t.OrganizationKey).Select(o => o.MerchantPctToRegistrant).FirstOrDefault()))
            .FirstOrDefaultAsync();

        return header is null ? null : header with { Items = items, Payments = payments };
    });

    public Task<List<MxBatchTxnRow>> GetMxBatchTxnsForReferenceAsync(int organizationKey, string referenceNbr)
        => RunAsync(() => db.MxmerchantBatchTxns
            .Where(t => t.OrganizationKey == organizationKey && t.ReferenceNbr == referenceNbr)
            .OrderBy(t => t.DateAdded)
            .Select(t => new MxBatchTxnRow(t.Amount, t.Authcode, t.PaymentId, t.DateAdded, t.BatchId, t.TransactionStatus,
                db.MxmerchantBatches.Where(b => b.OrganizationKey == t.OrganizationKey && b.BatchNumber == t.BatchId).Select(b => b.BatchId).FirstOrDefault(),
                db.MxmerchantBatches.Where(b => b.OrganizationKey == t.OrganizationKey && b.BatchNumber == t.BatchId).Select(b => b.BatchNumber).FirstOrDefault()))
            .ToListAsync());

    // The register shift the POS sale belongs to: the organization's shift(s) started on the sale's
    // date by the sale's EnteredByUser (Shift.ShiftStartName = POSTransaction.EnteredByUser).
    public Task<List<ShiftOption>> GetShiftsForPosTransactionAsync(int organizationKey, string enteredByUser, DateTime saleDate)
        => RunAsync(() =>
    {
        var dayStart = saleDate.Date;
        var dayEnd = dayStart.AddDays(1);
        return db.Shifts
            .Where(s => s.OrganizationKey == organizationKey && s.ShiftStartName == enteredByUser
                && s.ShiftStartDate >= dayStart && s.ShiftStartDate < dayEnd)
            .OrderBy(s => s.ShiftStartDate)
            .Select(s => new ShiftOption(s.ShiftKey, s.ShiftStartDate, s.ShiftEndDate, s.ShiftStartName))
            .ToListAsync();
    });

    // Records an EMV payment that MX has but Jarvis never recorded: inserts the POSTransactionPayment
    // row for exactly this POS transaction and sets the POSTransaction to COMPLETED with TotalPaid and
    // ConvenienceFee - the same changes the Jarvis app's acctrecv_emvpayment ('PaymentPOS') makes,
    // written directly so OrganizationKey and ConvenienceFee land on the payment row as well.
    // Refuses when the POS transaction is missing or the RegistrationNbr is already on any POS
    // payment - re-checked inside the same transaction as the insert, not just on screen.
    // Note: this does not run the register's CompletePOSTransactionAfterEmv steps (inventory
    // deduction, barcode tickets).
    public Task<int> InsertPosPaymentAsync(PosPaymentInsert payment)
        // EnableRetryOnFailure only allows an explicit transaction inside its execution strategy; a
        // retry re-runs the whole block, checks included.
        => RunAsync(() => db.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
    {
        db.ChangeTracker.Clear();
        await using var tx = await db.Database.BeginTransactionAsync();

        var transaction = await db.Postransactions.SingleOrDefaultAsync(t => t.PostransactionKey == payment.PostransactionKey)
            ?? throw new InvalidOperationException($"POSTransaction {payment.PostransactionKey} does not exist.");

        // An organization with no MerchantPctToRegistrant (null or 0) charges no convenience fee.
        var merchantPct = await db.Organizations
            .Where(o => o.OrganizationKey == transaction.OrganizationKey)
            .Select(o => o.MerchantPctToRegistrant)
            .FirstOrDefaultAsync();
        if (merchantPct is not > 0 && payment.ConvenienceFee != 0)
            throw new InvalidOperationException($"Organization {transaction.OrganizationKey} charges no convenience fee (MerchantPctToRegistrant is {(merchantPct?.ToString() ?? "null")}), so the convenience fee must be 0.");

        var existing = await db.PostransactionPayments
            .Where(p => p.RegistrationNbr == payment.RegistrationNbr)
            .Select(p => p.PostransactionKey)
            .FirstOrDefaultAsync();
        if (existing != 0)
            throw new InvalidOperationException($"RegistrationNbr {payment.RegistrationNbr} is already recorded on POS transaction {existing}.");

        var row = new PostransactionPayment
        {
            PostransactionKey = transaction.PostransactionKey,
            OrganizationKey = payment.OrganizationKey,
            PaymentDate = payment.PaymentDate,
            PaymentAmount = payment.PaymentAmount,
            ConvenienceFee = payment.ConvenienceFee,
            PaymentType = "EMV",
            RegistrationNbr = payment.RegistrationNbr,
            ConfirmationNbr = payment.ConfirmationNbr,
            ShiftKey = payment.ShiftKey,
            PaymentNotes = payment.PaymentNotes,
            PaymentPostedBy = payment.PostedBy,
            MerchantBatchId = payment.MerchantBatchId,
            MerchantBatchIdNum = payment.MerchantBatchIdNum,
        };
        db.PostransactionPayments.Add(row);

        transaction.TransactionStatus = "COMPLETED";
        transaction.TotalPaid = payment.PaymentAmount;
        transaction.ConvenienceFee = payment.ConvenienceFee;

        await db.SaveChangesAsync();

        // Read both rows back from the database before committing - anything other than exactly what
        // was intended rolls the whole insert back.
        var saved = await db.PostransactionPayments.AsNoTracking()
            .Where(p => p.PostransactionPaymentKey == row.PostransactionPaymentKey)
            .Select(p => new { p.PostransactionKey, p.OrganizationKey, p.PaymentAmount, p.ConvenienceFee, p.ShiftKey, p.PaymentPostedBy, p.MerchantBatchId, p.MerchantBatchIdNum })
            .SingleAsync();
        var savedTransaction = await db.Postransactions.AsNoTracking()
            .Where(t => t.PostransactionKey == payment.PostransactionKey)
            .Select(t => new { t.TransactionStatus, t.TotalPaid, t.ConvenienceFee })
            .SingleAsync();
        if (saved.PostransactionKey != payment.PostransactionKey || saved.OrganizationKey != payment.OrganizationKey
            || saved.PaymentAmount != payment.PaymentAmount || saved.ConvenienceFee != payment.ConvenienceFee
            || saved.ShiftKey != payment.ShiftKey || saved.PaymentPostedBy != payment.PostedBy
            || saved.MerchantBatchId != payment.MerchantBatchId || saved.MerchantBatchIdNum != payment.MerchantBatchIdNum
            || savedTransaction.TransactionStatus != "COMPLETED" || savedTransaction.TotalPaid != payment.PaymentAmount
            || savedTransaction.ConvenienceFee != payment.ConvenienceFee)
            throw new InvalidOperationException("The saved payment/transaction did not match what was entered - the insert was rolled back.");

        await tx.CommitAsync();
        return row.PostransactionPaymentKey;
    }));
}
