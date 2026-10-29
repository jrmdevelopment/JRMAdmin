using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class LeagueSchedulerTeamMatchup
{
    public int TeamMatchupKey { get; set; }

    public int? SeasonKey { get; set; }

    public int LeagueKey { get; set; }

    public int TeamNbr1 { get; set; }

    public int TeamNbr2 { get; set; }

    public string? TypeOfMatchup { get; set; }

    public bool? AssignedTeam { get; set; }

    public int? RoundNbr { get; set; }

    public int? NbrTimesUsed { get; set; }
}
