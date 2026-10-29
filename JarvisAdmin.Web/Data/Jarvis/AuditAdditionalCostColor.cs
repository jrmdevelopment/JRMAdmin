using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAdditionalCostColor
{
    public int AuditAdditionalCostColorKey { get; set; }

    public int AdditionalCostColorKey { get; set; }

    public int AdditionalCostKey { get; set; }

    public string ItemColor { get; set; } = null!;

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
