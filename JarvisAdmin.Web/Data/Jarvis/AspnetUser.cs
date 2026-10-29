using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AspnetUser
{
    public Guid ApplicationId { get; set; }

    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string LoweredUserName { get; set; } = null!;

    public string? MobileAlias { get; set; }

    public bool IsAnonymous { get; set; }

    public DateTime LastActivityDate { get; set; }

    public virtual AspnetApplication Application { get; set; } = null!;

    public virtual AspnetMembership? AspnetMembership { get; set; }

    public virtual AspnetProfile? AspnetProfile { get; set; }

    public virtual ICollection<AspnetUsersInRole> AspnetUsersInRoles { get; set; } = new List<AspnetUsersInRole>();

    public virtual UserDetail? UserDetail { get; set; }
}
