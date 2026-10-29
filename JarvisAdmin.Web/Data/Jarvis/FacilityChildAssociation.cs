using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityChildAssociation
{
    public int FacilityChildAssociationKey { get; set; }

    public int? OrganizationKey { get; set; }

    public int? FacilitySpaceKeyParent { get; set; }

    public int? FacilitySpaceKeyChild { get; set; }
}
