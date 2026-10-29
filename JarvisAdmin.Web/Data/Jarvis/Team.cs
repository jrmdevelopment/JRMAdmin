using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Team
{
    public int TeamKey { get; set; }

    public int LeagueKey { get; set; }

    public int CityKey { get; set; }

    public string TeamName { get; set; } = null!;

    public decimal TotalInvoiceAmt { get; set; }

    public decimal TotalPaidAmt { get; set; }

    public decimal TeamRegistrationFee { get; set; }

    public decimal EarlyBirdDiscount { get; set; }

    public decimal LateRegistrationFee { get; set; }

    public decimal AdjustmentTotal { get; set; }

    public decimal ConvenienceFee { get; set; }

    public decimal TotalNsf { get; set; }

    public DateTime? RosterSentOn { get; set; }

    public bool PostOnWebsite { get; set; }

    public string TeamStatus { get; set; } = null!;

    public DateTime TeamAdded { get; set; }

    public string EnteredBy { get; set; } = null!;

    public string? TeamColors { get; set; }

    public string? Comments { get; set; }

    public bool RosterFrozen { get; set; }

    public int? StatementKey { get; set; }

    public int? RegistrantKey { get; set; }

    public string? RegistrationPassword { get; set; }

    public int? DisplayOrder { get; set; }

    public string? RevenueCode { get; set; }

    public bool ClearedForPracticeReservations { get; set; }

    public bool EquipmentReturned { get; set; }

    public DateTime? EquipReminderEmailSent { get; set; }

    public decimal? UnreturnedEquipCharge { get; set; }

    public virtual City CityKeyNavigation { get; set; } = null!;

    public virtual League LeagueKeyNavigation { get; set; } = null!;

    public virtual ICollection<PaymentTeam> PaymentTeams { get; set; } = new List<PaymentTeam>();

    public virtual ICollection<TeamAdjustment> TeamAdjustments { get; set; } = new List<TeamAdjustment>();

    public virtual ICollection<TeamRoster> TeamRosters { get; set; } = new List<TeamRoster>();

    public virtual ICollection<TeamStanding> TeamStandings { get; set; } = new List<TeamStanding>();

    public virtual ICollection<TeamToCoach> TeamToCoaches { get; set; } = new List<TeamToCoach>();

    public virtual ICollection<TextMessageOptInTeam> TextMessageOptInTeams { get; set; } = new List<TextMessageOptInTeam>();
}
