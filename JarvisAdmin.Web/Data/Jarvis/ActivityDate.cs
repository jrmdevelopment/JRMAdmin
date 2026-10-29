using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ActivityDate
{
    public int ActivityDateKey { get; set; }

    public int OrganizationKey { get; set; }

    public int LeagueKey { get; set; }

    public DateTime ActivityStartTime { get; set; }

    public DateTime? ActivityEndTime { get; set; }

    public int? ConflictKey { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual League LeagueKeyNavigation { get; set; } = null!;
}
