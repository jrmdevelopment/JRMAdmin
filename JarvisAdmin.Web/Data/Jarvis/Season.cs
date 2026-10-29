using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Season
{
    public int SeasonKey { get; set; }

    public int OrganizationKey { get; set; }

    public int ActivityCategoryKey { get; set; }

    public DateTime RegistrationStart { get; set; }

    public DateTime RegistrationEnd { get; set; }

    public DateTime? NonResidentRegistrationStart { get; set; }

    public string SeasonStatus { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public string SeasonContactName { get; set; } = null!;

    public string SeasonContactPhone { get; set; } = null!;

    public string SeasonContactEmail { get; set; } = null!;

    public string ProgramType { get; set; } = null!;

    /// <summary>
    /// (I)ndividual, (T)eam, (B)oth. Indicates how the person will register. Either as an individaul, as a team or registration can take place either individually or as a team.
    /// </summary>
    public string RegistrationType { get; set; } = null!;

    public string? OneOrMultipleSessions { get; set; }

    public string? ProgramYear { get; set; }

    public string? ProgramSeason { get; set; }

    public string ProgramName { get; set; } = null!;

    public string ProgramDescription { get; set; } = null!;

    public string GenderSpecific { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public bool BirthdateRequired { get; set; }

    public bool BirthCertificateRequired { get; set; }

    public bool MedicalReleaseRequired { get; set; }

    public string ResidentsOnly { get; set; } = null!;

    public bool GrantFunding { get; set; }

    public decimal? SiblingDiscount { get; set; }

    public bool RequirePmtWhenRegister { get; set; }

    public int? PreviousProgramRqmt { get; set; }

    public int? PreviousProgramDiscountKey { get; set; }

    public decimal? PreviousProgramDiscount { get; set; }

    public string? RegistrationReceipt { get; set; }

    public DateTime? ComputeAgeAsOf { get; set; }

    public DateTime? CoachApplicationStart { get; set; }

    public DateTime? CoachApplicationEnd { get; set; }

    public bool AllowTextingOptIn { get; set; }

    public bool AftercareProgram { get; set; }

    public string? DateInformation { get; set; }

    public string? CostInformation { get; set; }

    public string? AgeRequirementText { get; set; }

    public string? ProgramLocation { get; set; }

    public string? NotifyEmail { get; set; }

    public string? WaitlistEmail { get; set; }

    public bool ShowJerseySize { get; set; }

    public bool ShowSchoolAttending { get; set; }

    public bool ShowRequestedCoach { get; set; }

    public bool ShowWaiverCoach { get; set; }

    public bool ShowCanVolunteer { get; set; }

    public bool ShowCanSponsor { get; set; }

    public bool ShowCanCoach { get; set; }

    public bool ShowPantShortSize { get; set; }

    public bool ShowApproximateWeight { get; set; }

    public bool ShowDistrict { get; set; }

    public bool ShowSkillLevel { get; set; }

    public bool ShowFriend { get; set; }

    public bool ShowRequestedTeam { get; set; }

    public bool ShowTeamColor { get; set; }

    public bool ShowComments { get; set; }

    public bool ShowApproximateHeight { get; set; }

    public bool ChooseJerseyNumber { get; set; }

    public bool SelectTeam { get; set; }

    public bool ShowDonation { get; set; }

    public bool ShowDonationSpecific { get; set; }

    public string? DonationRevenueCode { get; set; }

    public bool PostRosters { get; set; }

    public bool PostGameSchedule { get; set; }

    public bool PostPracticeSchedule { get; set; }

    public int? RosterNumberMinimum { get; set; }

    public int? RosterNumberMaximum { get; set; }

    public bool? RosterFullContactInfo { get; set; }

    public bool LastRegistrationDayOnCalendar { get; set; }

    public bool SharedProgram { get; set; }

    public int? SharedScheduleProgramKey { get; set; }

    public bool PracticeReservationsOnly { get; set; }

    public decimal? UnreturnedEquipFee { get; set; }

    public string? LastUpdatedBy { get; set; }

    public decimal? MembershipDollarDiscount { get; set; }

    public decimal? SeasonPassDollarDiscount { get; set; }

    public int? DisplayOrder { get; set; }

    public TimeOnly? RegistrationStartTime { get; set; }

    public virtual ActivityCategory ActivityCategoryKeyNavigation { get; set; } = null!;

    public virtual ICollection<AdditionalCost> AdditionalCosts { get; set; } = new List<AdditionalCost>();

    public virtual ICollection<CoachApplication> CoachApplications { get; set; } = new List<CoachApplication>();

    public virtual ICollection<CustomQuestionProgram> CustomQuestionPrograms { get; set; } = new List<CustomQuestionProgram>();

    public virtual ICollection<JerseySize> JerseySizes { get; set; } = new List<JerseySize>();

    public virtual ICollection<League> Leagues { get; set; } = new List<League>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<PantShortSize> PantShortSizes { get; set; } = new List<PantShortSize>();

    public virtual ICollection<RegistrantAdditionalCost> RegistrantAdditionalCosts { get; set; } = new List<RegistrantAdditionalCost>();

    public virtual ICollection<RegistrantToLeague> RegistrantToLeagues { get; set; } = new List<RegistrantToLeague>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<SeasonSiblingDiscount> SeasonSiblingDiscounts { get; set; } = new List<SeasonSiblingDiscount>();

    public virtual ICollection<SkillLevel> SkillLevels { get; set; } = new List<SkillLevel>();

    public virtual ICollection<TermsAndCondition> TermsAndConditions { get; set; } = new List<TermsAndCondition>();

    public virtual ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();
}
