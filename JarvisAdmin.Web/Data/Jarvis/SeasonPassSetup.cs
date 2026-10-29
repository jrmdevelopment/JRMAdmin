using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPassSetup
{
    public int SeasonPassSetupKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime DateAdded { get; set; }

    public int DisplayOrder { get; set; }

    public string SeasonPassStatus { get; set; } = null!;

    public string SeasonPassDescription { get; set; } = null!;

    public decimal SeasonPassPrice { get; set; }

    public string? RevenueCode { get; set; }

    public int NbrAllowedOnPass { get; set; }

    public decimal AddlPersonPrice { get; set; }

    public string AllowAddlPersons { get; set; } = null!;

    public bool OnlineOrdering { get; set; }

    public bool? TieredPricing { get; set; }

    public DateTime? PassSellStartDate { get; set; }

    public DateTime? PassSellEndDate { get; set; }

    public int? SeasonPassYear { get; set; }

    public string? SeasonPassReceipt { get; set; }

    /// <summary>
    /// Valid scan locations: comma-separated ShiftLocation LocationName or SubLocationName values; empty = valid everywhere
    /// </summary>
    public string? LocationName { get; set; }

    public string? BarcodePreface { get; set; }

    public virtual ICollection<SeasonPassPricingTier> SeasonPassPricingTiers { get; set; } = new List<SeasonPassPricingTier>();

    public virtual ICollection<SeasonPass> SeasonPasses { get; set; } = new List<SeasonPass>();
}
