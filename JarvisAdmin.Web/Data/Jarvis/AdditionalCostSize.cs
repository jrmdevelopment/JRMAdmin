using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AdditionalCostSize
{
    public int AdditionalCostSizeKey { get; set; }

    public int AdditionalCostKey { get; set; }

    public string ItemSize { get; set; } = null!;

    public string? LastUpdatedBy { get; set; }

    public virtual AdditionalCost AdditionalCostKeyNavigation { get; set; } = null!;
}
