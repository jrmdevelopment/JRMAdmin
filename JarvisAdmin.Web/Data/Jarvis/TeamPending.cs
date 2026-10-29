using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TeamPending
{
    public int TeamPendingKey { get; set; }

    public int AccountKey { get; set; }

    public int LeagueKey { get; set; }

    public int? RegistrantKey { get; set; }

    public int CityKey { get; set; }

    public string TeamName { get; set; } = null!;

    public string? CoachName { get; set; }

    public string? CoachEmailAddr { get; set; }

    public decimal TotalInvoiceAmt { get; set; }

    public decimal? TeamRegistrationFee { get; set; }

    public decimal? EarlyBirdDiscount { get; set; }

    public decimal? LateRegistrationFee { get; set; }

    public string TeamStatus { get; set; } = null!;

    public DateTime TeamAdded { get; set; }

    public string EnteredBy { get; set; } = null!;

    public string? Comments { get; set; }

    public string? RevenueCode { get; set; }

    public int? TeamKey { get; set; }

    public DateTime? ReminderEmailSent { get; set; }

    public string? TeamColors { get; set; }

    public decimal? MilitaryDiscount { get; set; }
}
