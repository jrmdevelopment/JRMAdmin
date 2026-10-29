using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Schedule
{
    public int ScheduleKey { get; set; }

    public int SeasonKey { get; set; }

    public int LeagueKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public int HomeTeam { get; set; }

    public int VisitingTeam { get; set; }

    public DateTime GameStartTime { get; set; }

    public DateTime? GameEndTime { get; set; }

    public int? WeekNbr { get; set; }

    public string GameType { get; set; } = null!;

    public string CoinFlip { get; set; } = null!;

    public string? CalendarSubject { get; set; }

    public string? GameStatus { get; set; }

    public bool? TextSent { get; set; }

    public int? HomeTeamScore { get; set; }

    public int? VisitingTeamScore { get; set; }

    public int? HomeTeamTemp { get; set; }

    public int? VisitingTeamTemp { get; set; }

    public DateTime? XGameDateTime { get; set; }

    public int? XScheduleForTeam { get; set; }

    public bool? XSlotVerified { get; set; }

    public DateTime? XGameDate { get; set; }

    public bool? XHomeTeamForfeit { get; set; }

    public bool? XVisitingTeamForfeit { get; set; }

    public int? XSharedGameKey { get; set; }

    public virtual League LeagueKeyNavigation { get; set; } = null!;

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
