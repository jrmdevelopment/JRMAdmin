using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantToLeagueAdjustmentPending
{
    public int RegistrantToLeagueAdjustmentPendingKey { get; set; }

    public int RegistrantToLeaguePendingKey { get; set; }

    public DateTime? AdjustmentDate { get; set; }

    public decimal AdjustmentAmount { get; set; }

    public string? AdjustmentReason { get; set; }

    public string? AdjustmentPostedBy { get; set; }

    public int? DiscountCodeKey { get; set; }
}
