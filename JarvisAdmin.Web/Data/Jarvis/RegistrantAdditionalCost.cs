using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantAdditionalCost
{
    public int RegistrantAdditionalCostKey { get; set; }

    public int RegistrantToLeagueKey { get; set; }

    public int SeasonKey { get; set; }

    public int AdditionalCostKey { get; set; }

    public string? ItemSize { get; set; }

    public string? ItemColor { get; set; }

    public int NbrOfUnits { get; set; }

    public decimal PricePerUnit { get; set; }

    public virtual AdditionalCost AdditionalCostKeyNavigation { get; set; } = null!;

    public virtual RegistrantToLeague RegistrantToLeagueKeyNavigation { get; set; } = null!;

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
