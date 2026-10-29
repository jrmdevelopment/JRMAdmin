using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AdditionalCostColor
{
    public int AdditionalCostColorKey { get; set; }

    public int AdditionalCostKey { get; set; }

    public string ItemColor { get; set; } = null!;

    public string? LastUpdatedBy { get; set; }

    public virtual AdditionalCost AdditionalCostKeyNavigation { get; set; } = null!;
}
