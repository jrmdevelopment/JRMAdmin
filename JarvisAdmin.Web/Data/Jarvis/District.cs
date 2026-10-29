using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class District
{
    public int DistrictKey { get; set; }

    public int OrganizationKey { get; set; }

    public string DistrictName { get; set; } = null!;

    public string DistrictStatus { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
