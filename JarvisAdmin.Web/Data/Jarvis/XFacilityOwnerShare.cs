using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XFacilityOwnerShare
{
    public int FacilityOwnerShareKey { get; set; }

    public int OrganizationKey { get; set; }

    public string FacilityShareName { get; set; } = null!;

    public int FacilitySpaceKey { get; set; }

    public virtual FacilitySpace FacilitySpaceKeyNavigation { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<XFacilityOwnerShareToOrg> XFacilityOwnerShareToOrgs { get; set; } = new List<XFacilityOwnerShareToOrg>();
}
