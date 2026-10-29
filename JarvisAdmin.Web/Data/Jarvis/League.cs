using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class League
{
    public int LeagueKey { get; set; }

    public int SeasonKey { get; set; }

    public string LeagueName { get; set; } = null!;

    public string? ActivityDateTimeInfo { get; set; }

    public DateTime? RegistrationSessionStart { get; set; }

    public DateTime? RegistrationSessionEnd { get; set; }

    public decimal? PlayerFee { get; set; }

    public decimal? MemberFee { get; set; }

    public decimal? NonmemberFee { get; set; }

    public decimal? TeamFee { get; set; }

    public decimal? MinimumDeposit { get; set; }

    public decimal? MinimumDepositPct { get; set; }

    public decimal? MilitaryDiscount { get; set; }

    public DateTime? EarlyBirdDate { get; set; }

    public decimal? EarlyBirdAmount { get; set; }

    public string? EarlyBirdBasedOn { get; set; }

    public DateTime? LateRegStart { get; set; }

    public decimal? LateRegAmount { get; set; }

    public string? LateRegistrationBasedOn { get; set; }

    public int? ClassSize { get; set; }

    public string ValidateEligibility { get; set; } = null!;

    public int? GradeLow { get; set; }

    public int? GradeHigh { get; set; }

    public DateTime? BirthDateLow { get; set; }

    public DateTime? BirthDateHigh { get; set; }

    public int? PlayUpYears { get; set; }

    public string? GenderRestriction { get; set; }

    public bool RegistrationClosed { get; set; }

    public bool CoachPostScores { get; set; }

    public int? GamesPerSeason { get; set; }

    public int? MinutesPerGame { get; set; }

    public bool KeepStandings { get; set; }

    public int DisplayOrder { get; set; }

    public string? LocationInformation { get; set; }

    public int? FacilitySpaceKey { get; set; }

    public int? InstructorKey { get; set; }

    public string LeagueStatus { get; set; } = null!;

    public bool SharedLeague { get; set; }

    public string? LastUpdatedBy { get; set; }

    public bool? AllowDaySelection { get; set; }

    public virtual ICollection<ActivityDate> ActivityDates { get; set; } = new List<ActivityDate>();

    public virtual ICollection<CoachApplication> CoachApplications { get; set; } = new List<CoachApplication>();

    public virtual Instructor? InstructorKeyNavigation { get; set; }

    public virtual ICollection<RegistrantToLeague> RegistrantToLeagues { get; set; } = new List<RegistrantToLeague>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual Season SeasonKeyNavigation { get; set; } = null!;

    public virtual ICollection<TeamStanding> TeamStandings { get; set; } = new List<TeamStanding>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
