using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SharedScheduleFacility
{
    public int SharedScheduleFacilityKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SharedFacilitySpaceKey { get; set; }

    public int OrgFacilitySpaceKey { get; set; }
}
