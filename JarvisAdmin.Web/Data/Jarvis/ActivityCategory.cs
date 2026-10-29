using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ActivityCategory
{
    public int ActivityCategoryKey { get; set; }

    public int OrganizationKey { get; set; }

    public string ActivityCategory1 { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string ActivityType { get; set; } = null!;

    public bool TiedToWebsite { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual ICollection<FacilityToSport> FacilityToSports { get; set; } = new List<FacilityToSport>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();
}
