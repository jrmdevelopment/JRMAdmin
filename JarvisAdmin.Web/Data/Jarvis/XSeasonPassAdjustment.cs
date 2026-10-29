using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XSeasonPassAdjustment
{
    public int SeasonPassAdjustmentKey { get; set; }

    public int SeasonPassKey { get; set; }

    public decimal AdjustmentAmount { get; set; }

    public string AdjustmentReason { get; set; } = null!;

    public DateTime AdjustmentDate { get; set; }

    public string AdjustedBy { get; set; } = null!;

    public virtual SeasonPass SeasonPassKeyNavigation { get; set; } = null!;
}
