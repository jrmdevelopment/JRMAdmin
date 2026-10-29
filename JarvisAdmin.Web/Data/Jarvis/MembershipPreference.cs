using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipPreference
{
    public int MembershipPreferencesKey { get; set; }

    public int OrganizationKey { get; set; }

    public bool OfferRecurringBilling { get; set; }

    /// <summary>
    /// Jarvis-Assigned the MembershipKey by Jarvis, Manual-entered manually, Pool-obtain from pool of numbers
    /// </summary>
    public string MembershipId { get; set; } = null!;

    public int? MembershipCategoryKey { get; set; }

    public decimal? LostCardCharge { get; set; }

    public int? MinimumMembershipAge { get; set; }

    public decimal? FacilityReservationDiscountPct { get; set; }

    public bool BankDraftOption { get; set; }

    public bool RenewalTypes { get; set; }

    public bool RecurringTypes { get; set; }

    public bool OnlineMembershipCheckin { get; set; }

    public bool? GenerateBarcodedCard { get; set; }

    /// <summary>
    /// Jarvis or ThirdParty
    /// </summary>
    public string? BarcodedCardCreation { get; set; }

    public string? MembershipIdAssignment { get; set; }

    public decimal? MembershipSalesTax { get; set; }
}
