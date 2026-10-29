using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class School
{
    public int SchoolKey { get; set; }

    public int OrganizationKey { get; set; }

    public string SchoolName { get; set; } = null!;

    public string SchoolStatus { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
