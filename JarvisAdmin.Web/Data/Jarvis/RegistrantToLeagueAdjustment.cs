using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantToLeagueAdjustment
{
    public int RegistrantToLeagueAdjustmentKey { get; set; }

    public int RegistrantToLeagueKey { get; set; }

    public DateTime? AdjustmentDate { get; set; }

    public decimal AdjustmentAmount { get; set; }

    public string? AdjustmentReason { get; set; }

    public int? DiscountCodeKey { get; set; }

    public string? AdjustmentPostedBy { get; set; }
}
