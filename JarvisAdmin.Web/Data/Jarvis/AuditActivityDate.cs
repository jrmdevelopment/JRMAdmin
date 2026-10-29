using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditActivityDate
{
    public int AuditActivityDateKey { get; set; }

    public int ActivityDateKey { get; set; }

    public int OrganizationKey { get; set; }

    public int LeagueKey { get; set; }

    public DateTime ActivityStartTime { get; set; }

    public DateTime? ActivityEndTime { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }

    public int? ConflictKey { get; set; }
}
