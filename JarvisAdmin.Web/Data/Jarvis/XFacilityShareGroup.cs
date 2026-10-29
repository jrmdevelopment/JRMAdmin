using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XFacilityShareGroup
{
    public int FacilityShareGroupKey { get; set; }

    public string FacilityShareGroupName { get; set; } = null!;

    public virtual ICollection<FacilityShareGroupMember> FacilityShareGroupMembers { get; set; } = new List<FacilityShareGroupMember>();
}
