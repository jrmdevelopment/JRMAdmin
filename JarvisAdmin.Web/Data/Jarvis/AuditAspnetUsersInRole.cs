using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAspnetUsersInRole
{
    public int AuditAspnetUsersInRolesKey { get; set; }

    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
