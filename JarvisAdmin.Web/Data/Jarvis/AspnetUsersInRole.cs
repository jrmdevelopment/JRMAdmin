using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AspnetUsersInRole
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual AspnetRole Role { get; set; } = null!;

    public virtual AspnetUser User { get; set; } = null!;
}
