using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XLeagueSchedulerDh
{
    public int LeagueSchedulerDhkey { get; set; }

    public int LeagueKey { get; set; }

    public int? TeamNbr1 { get; set; }

    public int? TeamNbr2 { get; set; }

    public DateTime? GameStartTime { get; set; }

    public DateTime? GameEndTime { get; set; }

    public int? ScheduleKey { get; set; }

    public int? TimesPerWeek { get; set; }

    public DateTime? NewGameStartTime { get; set; }

    public DateTime? NewGameEndTime { get; set; }
}
