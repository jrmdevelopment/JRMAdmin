using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityShare
{
    public int FacilityShareKey { get; set; }

    public int MainOrganization { get; set; }

    public int OrganizationKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public string ShareStatus { get; set; } = null!;

    public bool AllowPractices { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual FacilitySpace FacilitySpaceKeyNavigation { get; set; } = null!;

    public virtual Organization MainOrganizationNavigation { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
