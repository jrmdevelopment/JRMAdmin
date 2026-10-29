using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SharedSchedule
{
    public int SharedScheduleKey { get; set; }

    public int? OrganizationKey { get; set; }

    public int SharedOrganizationKey { get; set; }

    public int OrgSeasonKey { get; set; }

    public int SharedSeasonKey { get; set; }

    public int OrgLeagueKey { get; set; }

    public int SharedLeagueKey { get; set; }
}
