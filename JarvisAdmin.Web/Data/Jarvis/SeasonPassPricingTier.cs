using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPassPricingTier
{
    public int SeasonPassPricingTiersKey { get; set; }

    public int SeasonPassSetupKey { get; set; }

    public int? MinQuantity { get; set; }

    public int? MaxQuantity { get; set; }

    public decimal? TierPrice { get; set; }

    public virtual SeasonPassSetup SeasonPassSetupKeyNavigation { get; set; } = null!;
}
