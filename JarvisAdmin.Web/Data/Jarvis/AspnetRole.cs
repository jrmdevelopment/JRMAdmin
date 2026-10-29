using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AspnetRole
{
    public Guid ApplicationId { get; set; }

    public Guid RoleId { get; set; }

    public int OrganizationKey { get; set; }

    public string RoleName { get; set; } = null!;

    public string LoweredRoleName { get; set; } = null!;

    public string? Description { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual AspnetApplication Application { get; set; } = null!;

    public virtual ICollection<AspnetRolesToScreen> AspnetRolesToScreens { get; set; } = new List<AspnetRolesToScreen>();

    public virtual ICollection<AspnetUsersInRole> AspnetUsersInRoles { get; set; } = new List<AspnetUsersInRole>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
