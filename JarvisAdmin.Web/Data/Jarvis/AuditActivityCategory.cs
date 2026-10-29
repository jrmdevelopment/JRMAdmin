using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditActivityCategory
{
    public int AuditActivityCategoryKey { get; set; }

    public int ActivityCategoryKey { get; set; }

    public int OrganizationKey { get; set; }

    public string ActivityCategory { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string ActivityType { get; set; } = null!;

    public bool TiedToWebsite { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
