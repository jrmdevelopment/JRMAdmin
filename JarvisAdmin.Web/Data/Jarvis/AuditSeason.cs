using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditSeason
{
    public int AuditSeasonKey { get; set; }

    public int SeasonKey { get; set; }

    public int OrganizationKey { get; set; }

    public int ActivityCategoryKey { get; set; }

    public DateTime? RegistrationStart { get; set; }

    public DateTime? RegistrationEnd { get; set; }

    public string SeasonStatus { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public string SeasonContactName { get; set; } = null!;

    public string SeasonContactPhone { get; set; } = null!;

    public string SeasonContactEmail { get; set; } = null!;

    public string ProgramName { get; set; } = null!;

    public string ProgramDescription { get; set; } = null!;

    public string ProgramType { get; set; } = null!;

    public string GenderSpecific { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public bool BirthdateRequired { get; set; }

    public decimal? SiblingDiscount { get; set; }

    public int? PreviousProgramRqmt { get; set; }

    public int? PreviousProgramDiscountKey { get; set; }

    public decimal? PreviousProgramDiscount { get; set; }

    public string ResidentsOnly { get; set; } = null!;

    public bool GrantFunding { get; set; }

    public string? RegistrationReceipt { get; set; }

    public string RegistrationType { get; set; } = null!;

    public bool RequirePmtWhenRegister { get; set; }

    public DateTime? ComputeAgeAsOf { get; set; }

    public DateTime? CoachApplicationStart { get; set; }

    public DateTime? CoachApplicationEnd { get; set; }

    public bool AllowTextingOptIn { get; set; }

    public bool AftercareProgram { get; set; }

    public string? DateInformation { get; set; }

    public string? CostInformation { get; set; }

    public string? AgeRequirementText { get; set; }

    public string? OneOrMultipleSessions { get; set; }

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

    public bool ShowDonation { get; set; }

    public bool ShowDonationSpecific { get; set; }

    public string? DonationRevenueCode { get; set; }

    public bool ChooseJerseyNumber { get; set; }

    public bool ShowTeamColor { get; set; }

    public bool ShowComments { get; set; }

    public bool ShowApproximateHeight { get; set; }

    public bool PostRosters { get; set; }

    public bool PostGameSchedule { get; set; }

    public bool PostPracticeSchedule { get; set; }

    public int? RosterNumberMinimum { get; set; }

    public bool? RosterFullContactInfo { get; set; }

    public int? RosterNumberMaximum { get; set; }

    public bool BirthCertificateRequired { get; set; }

    public bool LastRegistrationDayOnCalendar { get; set; }

    public string? ProgramLocation { get; set; }

    public bool SelectTeam { get; set; }

    public bool? MedicalReleaseRequired { get; set; }

    public string? NotifyEmail { get; set; }

    public string? WaitlistEmail { get; set; }

    public bool SharedProgram { get; set; }

    public DateTime? NonResidentRegistrationStart { get; set; }

    public bool? PracticeReservationsOnly { get; set; }

    public decimal? UnreturnedEquipFee { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }

    public decimal? MembershipDollarDiscount { get; set; }

    public decimal? SeasonPassDollarDiscount { get; set; }
}
