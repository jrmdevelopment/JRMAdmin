using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class LeagueSchedulerDateException
{
    public int LeagueSchedulerDateExceptionKey { get; set; }

    public int LeagueKey { get; set; }

    public DateTime GameDateException { get; set; }
}
