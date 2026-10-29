using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditUserDetail
{
    public int AuditUserDetailsKey { get; set; }

    public Guid UserId { get; set; }

    public int OrganizationKey { get; set; }

    public string UserName { get; set; } = null!;

    public string? UserIdStatus { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }

    public string? AuditUser { get; set; }
}
