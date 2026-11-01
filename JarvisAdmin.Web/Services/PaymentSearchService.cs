using JarvisAdmin.Web.Data.Jarvis;
using Microsoft.EntityFrameworkCore;

namespace JarvisAdmin.Web.Services;

// One Jarvis payment row carrying a searched-for reference (registration) number.
public record PaymentSearchRow(
    string SourceTable,
    int RowKey,
    string ParentLabel,          // what the row hangs off, e.g. "RegistrantToLeagueKey"
    int? ParentKey,
    int? OrganizationKey,
    string? OrganizationName,
    DateTime? PaymentDate,
    decimal PaymentAmount,
    string? PaymentType,
    string? ConfirmationNbr,
    string? PostedBy,
    string? MerchantBatchId,
    long? MerchantBatchIdNum);

// Payment Search page: finds an organization's reference number in every Jarvis payment table - the same 18 tables
// MxReconciliationService.GetReferenceNbrDetailAsync checks - with enough about each row (its key, the record it
// belongs to) to go and find it in Jarvis.
public class PaymentSearchService(IDbContextFactory<JarvisDbContext> dbFactory)
{
    // Each table is searched by the reference number (indexed and very selective), and the handful of matches is
    // then narrowed to the organization - every table's rows can be tied to one, directly or through their parent.
    public async Task<List<PaymentSearchRow>> SearchByReferenceNbrAsync(int organizationKey, string referenceNbr)
    {
        var nbr = referenceNbr.Trim();
        await using var db = await dbFactory.CreateDbContextAsync();
        var rows = new List<PaymentSearchRow>();

        // Payment has no navigation to its registration, so its organization comes from a lookup on it.
        rows.AddRange(await db.Payments.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("Payment", x.PaymentKey, "RegistrantToLeagueKey", x.RegistrantToLeagueKey,
                db.RegistrantToLeagues.Where(r => r.RegistrantToLeagueKey == x.RegistrantToLeagueKey).Select(r => (int?)r.SeasonKeyNavigation.OrganizationKey).FirstOrDefault(),
                null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentMemberships.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentMembership", x.PaymentMembershipKey, "MembershipDetailKey", (int?)x.MembershipDetailKey,
                (int?)x.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentFacilities.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentFacility", x.PaymentFacilityKey, "FacilityReservationKey", x.FacilityReservationKey,
                (int?)x.FacilityReservationKeyNavigation.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentSeasonPasses.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentSeasonPass", x.PaymentSeasonPassKey, "SeasonPassKey", x.SeasonPassKey,
                (int?)x.SeasonPassKeyNavigation.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentSpecialEvents.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentSpecialEvent", x.PaymentSpecialEventKey, "SpecialEventKey", x.SpecialEventKey,
                (int?)x.SpecialEventKeyNavigation.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentLockerRentals.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentLockerRental", x.PaymentLockerRentalKey, "LockerRentalKey", (int?)x.LockerRentalKey,
                (int?)x.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        // Team has no organization column of its own; it gets it through its league's season.
        rows.AddRange(await db.PaymentTeams.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentTeam", x.PaymentTeamKey, "TeamKey", x.TeamKey,
                (int?)x.TeamKeyNavigation.LeagueKeyNavigation.SeasonKeyNavigation.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentTourRegistrations.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentTourRegistration", x.PaymentTourRegistrationKey, "TourRegistrationKey", x.TourRegistrationKey,
                (int?)x.TourRegistrationKeyNavigation.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentSponsors.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentSponsor", x.PaymentSponsorKey, "SponsorPledgeDetailKey", (int?)x.SponsorPledgeDetailKey,
                (int?)x.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentVendors.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentVendor", x.PaymentVendorKey, "VendorKey", x.VendorKey,
                (int?)x.OrganizationKey, null, x.PaymentDate, x.PaymentAmount ?? 0m, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PostransactionPayments.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PostransactionPayment", x.PostransactionPaymentKey, "POSTransactionKey", x.PostransactionKey,
                x.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.DailyBarcodeTickets.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("DailyBarcodeTicket", x.DailyBarcodeTicketKey, "POSTransactionKey", x.PostransactionKey,
                (int?)x.OrganizationKey, null, x.IssuedAt, x.PaymentAmount ?? 0m, x.PaymentType, x.ConfirmationNbr, null, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.Donations.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("Donation", x.DonationKey, "DonationItemKey", x.DonationItemKey,
                (int?)x.OrganizationKey, null, x.PaymentDate, x.PaymentAmount ?? 0m, x.PaymentType, x.ConfirmationNbr, x.DonationPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.AccountCredits.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("AccountCredit", x.AccountCreditKey, "AccountKey", x.AccountKey,
                (int?)x.AccountKeyNavigation.OrganizationKey, null, x.PaymentDate, x.CreditBalanceAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.AccountCreditManualSources.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("AccountCreditManualSource", x.AccountCreditManualSourceKey, "AccountKey", (int?)x.AccountKey,
                (int?)x.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        // No PaymentDate on this table - ReturnDate is when the credit was posted.
        rows.AddRange(await db.AccountCreditReturnSources.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("AccountCreditReturnSource", x.AccountCreditReturnSourceKey, "SourceTableKey", (int?)x.SourceTableKey,
                (int?)x.OrganizationKey, null, x.ReturnDate, x.ReturnAmount, x.PaymentType, x.ConfirmationNbr, x.PostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        // AccountDonation has no PaymentAmount field - DonationAmount is the amount actually charged.
        rows.AddRange(await db.AccountDonations.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("AccountDonation", x.AccountDonationKey, "AccountKey", (int?)x.AccountKey,
                (int?)x.OrganizationKey, null, x.PaymentDate, x.DonationAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        rows.AddRange(await db.PaymentMerchandises.AsNoTracking().Where(x => x.RegistrationNbr == nbr)
            .Select(x => new PaymentSearchRow("PaymentMerchandise", x.PaymentMerchandiseKey, "InventoryItemKey", (int?)x.InventoryItemKey,
                (int?)x.OrganizationKey, null, x.PaymentDate, x.PaymentAmount, x.PaymentType, x.ConfirmationNbr, x.PaymentPostedBy, x.MerchantBatchId, x.MerchantBatchIdNum))
            .ToListAsync());

        var organizationName = await db.Organizations.AsNoTracking()
            .Where(o => o.OrganizationKey == organizationKey)
            .Select(o => o.OrganizationName)
            .FirstOrDefaultAsync();

        return rows
            .Where(r => r.OrganizationKey == organizationKey)
            .Select(r => r with { OrganizationName = organizationName })
            .OrderByDescending(r => r.PaymentDate)
            .ToList();
    }
}
