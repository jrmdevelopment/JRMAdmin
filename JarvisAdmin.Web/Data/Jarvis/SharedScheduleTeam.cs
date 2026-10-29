using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SharedScheduleTeam
{
    public int SharedScheduleTeamKey { get; set; }

    public int SharedScheduleKey { get; set; }

    public int OrgTeamKey { get; set; }

    public int SharedTeamKey { get; set; }
}
