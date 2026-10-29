using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAspnetRolesToScreen
{
    public int AuditAspnetRolesToScreens { get; set; }

    public Guid RoleId { get; set; }

    public string ScreenName { get; set; } = null!;

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
