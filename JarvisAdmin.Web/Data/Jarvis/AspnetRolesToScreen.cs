using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AspnetRolesToScreen
{
    public Guid RoleId { get; set; }

    public string ScreenName { get; set; } = null!;

    public string? LastUpdatedBy { get; set; }

    public virtual AspnetRole Role { get; set; } = null!;
}
