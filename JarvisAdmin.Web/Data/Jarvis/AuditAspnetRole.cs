using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAspnetRole
{
    public int AuditUserDetailsRolesKey { get; set; }

    public Guid ApplicationId { get; set; }

    public Guid RoleId { get; set; }

    public int OrganizationKey { get; set; }

    public string RoleName { get; set; } = null!;

    public string LoweredRoleName { get; set; } = null!;

    public string? Description { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
