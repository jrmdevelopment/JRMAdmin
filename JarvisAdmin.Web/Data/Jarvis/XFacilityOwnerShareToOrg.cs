using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XFacilityOwnerShareToOrg
{
    public int FacilityOwnerShareToOrgKey { get; set; }

    public int FacilityOwnerShareKey { get; set; }

    public int SharedToOrg { get; set; }

    public string ShareToOrgStatus { get; set; } = null!;

    public virtual XFacilityOwnerShare FacilityOwnerShareKeyNavigation { get; set; } = null!;

    public virtual Organization SharedToOrgNavigation { get; set; } = null!;
}
