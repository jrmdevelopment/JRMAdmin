using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantToLeague
{
    public int RegistrantToLeagueKey { get; set; }

    public int RegistrantKey { get; set; }

    public int SeasonKey { get; set; }

    public int LeagueKey { get; set; }

    public int? MultipleRegistrationKey { get; set; }

    public DateTime RegistrationDate { get; set; }

    public string RegistrationStatus { get; set; } = null!;

    public decimal TotalPaidAmt { get; set; }

    public decimal TotalInvoiceAmt { get; set; }

    public decimal RegistrationFee { get; set; }

    public decimal LateRegistrationFee { get; set; }

    public decimal AddlCostItemTotal { get; set; }

    public decimal ConvenienceFee { get; set; }

    public decimal Nsftotal { get; set; }

    public decimal EarlyBirdDiscount { get; set; }

    public decimal SiblingDiscount { get; set; }

    public decimal PreviousSeasonDiscount { get; set; }

    public decimal AdjustmentTotal { get; set; }

    public bool Scholarship { get; set; }

    public int? TeamKey { get; set; }

    public int? JerseyNumber { get; set; }

    public int? RequestedTeamKey { get; set; }

    public string? Grade { get; set; }

    public string? JerseySize { get; set; }

    public string? SchoolAttending { get; set; }

    public string? RequestedCoach { get; set; }

    public string? WaiverCoach { get; set; }

    public bool CanSponsor { get; set; }

    public string? PantShortSize { get; set; }

    public int? ApproximateWeight { get; set; }

    public string? DistrictName { get; set; }

    public string? SkillLevel { get; set; }

    public string? RequestedFriend { get; set; }

    public string? RequestedTeam { get; set; }

    public int? JerseyChoice1 { get; set; }

    public int? JerseyChoice2 { get; set; }

    public int? JerseyChoice3 { get; set; }

    public string? Comments { get; set; }

    public string? ApproximateHeight { get; set; }

    public string? CoachName1 { get; set; }

    public string? CoachType1 { get; set; }

    public string? CoachName2 { get; set; }

    public string? CoachType2 { get; set; }

    public string? VolunteerCapacity { get; set; }

    public string? VolunteerCapacity2 { get; set; }

    public string? VolunteerName1 { get; set; }

    public string? VolunteerName2 { get; set; }

    public bool AcceptTc { get; set; }

    public string EnteredBy { get; set; } = null!;

    public int? StatementKey { get; set; }

    public string? RevenueCode { get; set; }

    public DateTime? RemovedFromWaitlistDate { get; set; }

    public DateTime? VolunteerInterestEmailReminder { get; set; }

    public bool HelmetCheckOut { get; set; }

    public bool HelmetCheckIn { get; set; }

    public bool PadsCheckIn { get; set; }

    public bool PadsCheckOut { get; set; }

    public int? RegisteredByAccountKey { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? EquipReminderEmailSent { get; set; }

    public virtual League LeagueKeyNavigation { get; set; } = null!;

    public virtual ICollection<RegistrantAdditionalCost> RegistrantAdditionalCosts { get; set; } = new List<RegistrantAdditionalCost>();

    public virtual Registrant RegistrantKeyNavigation { get; set; } = null!;

    public virtual ICollection<RegistrantToLeagueDay> RegistrantToLeagueDays { get; set; } = new List<RegistrantToLeagueDay>();

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
