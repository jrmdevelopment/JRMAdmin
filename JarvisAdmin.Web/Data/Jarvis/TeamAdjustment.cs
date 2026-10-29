using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TeamAdjustment
{
    public int TeamAdjustmentKey { get; set; }

    public int TeamKey { get; set; }

    public DateTime? AdjustmentDate { get; set; }

    public decimal AdjustmentAmount { get; set; }

    public string AdjustmentReason { get; set; } = null!;

    public string? AdjustmentPostedBy { get; set; }

    public virtual Team TeamKeyNavigation { get; set; } = null!;
}
