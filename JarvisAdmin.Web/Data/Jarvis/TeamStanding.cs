using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TeamStanding
{
    public int TeamStandingsKey { get; set; }

    public int LeagueKey { get; set; }

    public string TeamName { get; set; } = null!;

    public int TeamKey { get; set; }

    public decimal? NbrWon { get; set; }

    public decimal? NbrLost { get; set; }

    public int? PointsFor { get; set; }

    public int? PointsAgainst { get; set; }

    public decimal? Wlpercent { get; set; }

    public int? NbrOfPointsSoccer { get; set; }

    public int? HeadToHead { get; set; }

    public virtual League LeagueKeyNavigation { get; set; } = null!;

    public virtual Team TeamKeyNavigation { get; set; } = null!;
}
