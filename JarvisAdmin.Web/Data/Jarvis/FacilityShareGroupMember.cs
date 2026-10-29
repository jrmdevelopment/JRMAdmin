using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityShareGroupMember
{
    public int FacilityShareGroupMemberKey { get; set; }

    public int FacilityShareGroupKey { get; set; }

    public int OrganizationKey { get; set; }

    public virtual XFacilityShareGroup FacilityShareGroupKeyNavigation { get; set; } = null!;

    public virtual ICollection<FacilityShareGroupMemberCategory> FacilityShareGroupMemberCategories { get; set; } = new List<FacilityShareGroupMemberCategory>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
