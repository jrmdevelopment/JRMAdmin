using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantAdditionalCostPending
{
    public int RegistrantAdditionalCostPendingKey { get; set; }

    public int RegistrantToLeaguePendingKey { get; set; }

    public int SeasonKey { get; set; }

    public int AdditionalCostKey { get; set; }

    public string? ItemSize { get; set; }

    public string? ItemColor { get; set; }

    public int NbrOfUnits { get; set; }

    public decimal PricePerUnit { get; set; }

    public string AdjustmentFor { get; set; } = null!;

    public int? RegistrantToLeagueKey { get; set; }

    public virtual RegistrantToLeaguePending RegistrantToLeaguePendingKeyNavigation { get; set; } = null!;
}
