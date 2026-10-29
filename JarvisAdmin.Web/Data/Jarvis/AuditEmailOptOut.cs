using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditEmailOptOut
{
    public int AuditEmailOptOutKey { get; set; }

    public int EmailOptOutKey { get; set; }

    public int OrganizationKey { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateTime OptOutDate { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
