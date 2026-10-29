using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityShareGroupMemberCategory
{
    public int FacilityShareGroupMemberCategoryKey { get; set; }

    public int FacilityShareGroupMemberKey { get; set; }

    public string ActivityCategory { get; set; } = null!;

    public int OrgSharingFacilities { get; set; }

    public virtual FacilityShareGroupMember FacilityShareGroupMemberKeyNavigation { get; set; } = null!;
}
