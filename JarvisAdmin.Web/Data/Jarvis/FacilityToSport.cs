using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityToSport
{
    public int FacilityToSportKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? FacilitySpaceKey { get; set; }

    public int ActivityCategoryKey { get; set; }

    public virtual ActivityCategory ActivityCategoryKeyNavigation { get; set; } = null!;

    public virtual FacilitySpace? FacilitySpaceKeyNavigation { get; set; }
}
