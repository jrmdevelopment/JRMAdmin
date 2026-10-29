using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Account
{
    public int AccountKey { get; set; }

    public int OrganizationKey { get; set; }

    public string? AccountType { get; set; }

    public string Account1Last { get; set; } = null!;

    public string Account1First { get; set; } = null!;

    public string? Account2Last { get; set; }

    public string? Account2First { get; set; }

    public string? BusinessName { get; set; }

    public string? LoginEmail { get; set; }

    public byte[]? EloginPassword { get; set; }

    public string? EmailAddr2 { get; set; }

    public string PrimaryPhone { get; set; } = null!;

    public string? AlternatePhone1 { get; set; }

    public string AccountAddress { get; set; } = null!;

    public string AccountCity { get; set; } = null!;

    public string AccountState { get; set; } = null!;

    public string AccountZip { get; set; } = null!;

    public string EmergencyContact { get; set; } = null!;

    public string EmergencyContactPhone { get; set; } = null!;

    public string EnteredBy { get; set; } = null!;

    public DateTime DateEntered { get; set; }

    public string AccountStatus { get; set; } = null!;

    public bool Nsfcheck { get; set; }

    public DateTime? ReceivableReminderSent { get; set; }

    public DateTime? LastVerifiedDate { get; set; }

    public bool TextMessageTerms { get; set; }

    public bool? FrozenAccount { get; set; }

    public bool? Military { get; set; }

    public int? VerificationCode { get; set; }

    public DateTime? VerificationCodeDate { get; set; }

    public bool AllowPayLater { get; set; }

    public DateTime? LinkRegistrantEmailSent { get; set; }

    public string? LinkRegistrantResponse { get; set; }

    public DateTime? LinkRegistrantResponseDate { get; set; }

    public DateTime? RequestLinkEmailSent { get; set; }

    public int? LinkRegistrantKey { get; set; }

    public int? LinkAccountKey { get; set; }

    public string? ResidencyStatus { get; set; }

    public string? LastUpdatedBy { get; set; }

    public bool? ResidencyValidated { get; set; }

    public bool BusinessNonprofit { get; set; }

    public decimal? FacilityPerHourCharge { get; set; }

    public int? AftercareCode { get; set; }

    public string? TempbullochAftercare2025Status { get; set; }

    public virtual AccountAftercare? AccountAftercare { get; set; }

    public virtual ICollection<AccountCredit> AccountCredits { get; set; } = new List<AccountCredit>();

    public virtual ICollection<AccountDonationAward> AccountDonationAwards { get; set; } = new List<AccountDonationAward>();

    public virtual ICollection<AccountDonation> AccountDonations { get; set; } = new List<AccountDonation>();

    public virtual ICollection<AccountNote> AccountNotes { get; set; } = new List<AccountNote>();

    public virtual ICollection<AccountToDocument> AccountToDocuments { get; set; } = new List<AccountToDocument>();

    public virtual ICollection<CoachApplication> CoachApplications { get; set; } = new List<CoachApplication>();

    public virtual ICollection<Registrant> Registrants { get; set; } = new List<Registrant>();

    public virtual ICollection<TeamToCoach> TeamToCoaches { get; set; } = new List<TeamToCoach>();

    public virtual ICollection<TextMessageOptIn> TextMessageOptIns { get; set; } = new List<TextMessageOptIn>();

    public virtual ICollection<TextMessageSentLogDetail> TextMessageSentLogDetails { get; set; } = new List<TextMessageSentLogDetail>();
}
