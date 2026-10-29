using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAccount
{
    public int AuditAccountKey { get; set; }

    public int? AccountKey { get; set; }

    public int? OrganizationKey { get; set; }

    public string? AccountType { get; set; }

    public string? Account1Last { get; set; }

    public string? Account1First { get; set; }

    public string? Account2Last { get; set; }

    public string? Account2First { get; set; }

    public string? BusinessName { get; set; }

    public string? LoginEmail { get; set; }

    public byte[]? EloginPassword { get; set; }

    public string? EmailAddr2 { get; set; }

    public string? PrimaryPhone { get; set; }

    public string? AlternatePhone1 { get; set; }

    public string? AccountAddress { get; set; }

    public string? AccountCity { get; set; }

    public string? AccountState { get; set; }

    public string? AccountZip { get; set; }

    public string? EmergencyContact { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? EnteredBy { get; set; }

    public DateTime? DateEntered { get; set; }

    public string? AccountStatus { get; set; }

    public bool? Nsfcheck { get; set; }

    public DateTime? ReceivableReminderSent { get; set; }

    public DateTime? LastVerifiedDate { get; set; }

    public bool? TextMessageTerms { get; set; }

    public bool? FrozenAccount { get; set; }

    public int? VerificationCode { get; set; }

    public DateTime? VerificationCodeDate { get; set; }

    public bool? AllowPayLater { get; set; }

    public DateTime? LinkRegistrantEmailSent { get; set; }

    public string? LinkRegistrantResponse { get; set; }

    public DateTime? LinkRegistrantResponseDate { get; set; }

    public DateTime? RequestLinkEmailSent { get; set; }

    public int? LinkRegistrantKey { get; set; }

    public int? LinkAccountKey { get; set; }

    public string? ResidencyStatus { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }

    public string? AuditUser { get; set; }

    public bool? ResidencyValidated { get; set; }

    public bool? BusinessNonprofit { get; set; }

    public decimal? FacilityPerHourCharge { get; set; }

    public int? AftercareCode { get; set; }
}
