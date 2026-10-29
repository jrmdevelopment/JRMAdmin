using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAdditionalCostSize
{
    public int AuditAdditionalCostSizeKey { get; set; }

    public int AdditionalCostSizeKey { get; set; }

    public int AdditionalCostKey { get; set; }

    public string ItemSize { get; set; } = null!;

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
