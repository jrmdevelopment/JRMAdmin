using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class LeagueSchedulerParm
{
    public int LeagueSchedulerParmsKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SeasonKey { get; set; }

    public int LeagueKey { get; set; }

    public DateTime StartDateOfSchedule { get; set; }

    public DateTime EndDateOfSchedule { get; set; }

    public int GamesPerSeason { get; set; }

    public int MinutesPerGame { get; set; }

    public int MaxGamesPerWeek { get; set; }

    public int MaxGamesPerDay { get; set; }

    public bool DoubleHeaders { get; set; }

    public bool GameInbetween { get; set; }
}
