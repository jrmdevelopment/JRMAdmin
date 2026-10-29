using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class UserDetail
{
    public Guid UserId { get; set; }

    public int OrganizationKey { get; set; }

    public string UserName { get; set; } = null!;

    public string UserIdStatus { get; set; } = null!;

    public string? LastChangedBy { get; set; }

    public DateTime? LastAccess { get; set; }

    public string? InitialScreen { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual AspnetUser User { get; set; } = null!;
}
