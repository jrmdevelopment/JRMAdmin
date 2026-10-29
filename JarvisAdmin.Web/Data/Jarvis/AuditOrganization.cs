using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditOrganization
{
    public int AuditOrganizationKey { get; set; }

    public int OrganizationKey { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public string OrganizationName { get; set; } = null!;

    public string OrganizationAddr { get; set; } = null!;

    public string OrganizationCity { get; set; } = null!;

    public string OrganizationSt { get; set; } = null!;

    public string OrganizationZip { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public string ContactEmailAddr { get; set; } = null!;

    public int? TimeZone { get; set; }

    public string FeeStructure { get; set; } = null!;

    public bool RequirePaymentWhenRegistering { get; set; }

    public bool RestrictUnpaidRegistrants { get; set; }

    public bool HaveAftercarePrograms { get; set; }

    public bool TeamRegPmtReqd { get; set; }

    public bool CoachApplications { get; set; }

    public bool VolunteerApplications { get; set; }

    public bool UseGrantFunding { get; set; }

    public bool SwipeMachine { get; set; }

    public bool OfferScholarships { get; set; }

    public bool RequirePhysicalAddr { get; set; }

    public bool UseShifts { get; set; }

    public bool AutoReopenFields { get; set; }

    public bool UseMembershipSystem { get; set; }

    public bool? UseSeasonPassSystem { get; set; }

    public bool OnlineReserveFacilities { get; set; }

    public bool TextGameReminders { get; set; }

    public bool? MedicalReleaseScreen { get; set; }

    public bool? RevenueCodeRequired { get; set; }

    public bool? PayOnline { get; set; }

    public bool? UseDocumentManager { get; set; }

    public bool? OnlineApplications { get; set; }

    public bool? RequireParticipantMiddleName { get; set; }

    public bool OnlinePracticeApproval { get; set; }

    public bool OnlineFacilityApproval { get; set; }

    public bool? ExternalTeamPractice { get; set; }

    public bool? OnlineSeasonPass { get; set; }

    public bool? SeasonPassAccount { get; set; }

    public bool? ValidateResidencyByAddr { get; set; }

    public bool ValidateResidencyByZip { get; set; }

    public bool AllowAmex { get; set; }

    public bool? AllowDisc { get; set; }

    public string? PosscreenName { get; set; }

    public string? StandingsType { get; set; }

    public string? BackgroundCheckUrl { get; set; }

    public string? TaxId { get; set; }

    public string? AfterhoursPhone { get; set; }

    public string? GlorRevenueCode { get; set; }

    public bool? TylerFinanceSystem { get; set; }

    public bool? CaselleFinanceSystem { get; set; }

    public bool? FeedCashChecks { get; set; }

    public bool? BatchCashChecks { get; set; }

    public string? FeeScheduleFile { get; set; }

    public string? PaymentFile { get; set; }

    public string? ServiceAgreementFile { get; set; }

    public string? EditorCssfile { get; set; }

    public string? ImageEditorPath { get; set; }

    public string? DocumentPath { get; set; }

    public string? FromEmailAddress { get; set; }

    public string? FromEmailPw { get; set; }

    public string? DomainName { get; set; }

    public string? NameForLookup { get; set; }

    public decimal? MonthlyBilledAmount { get; set; }

    public decimal LeagueMgmtPrice { get; set; }

    public decimal ActivityPrice { get; set; }

    public decimal TeamPrice { get; set; }

    public decimal? FacilitySalesTax { get; set; }

    public string GatewayUsed { get; set; } = null!;

    public decimal? MerchantPctToRegistrant { get; set; }

    public decimal? SwipePctToRegistrant { get; set; }

    public decimal? MinimumConvenienceFee { get; set; }

    public string? MembershipFlatOrPercent { get; set; }

    public decimal? MembershipFlatRate { get; set; }

    public decimal? DailyPercentage { get; set; }

    public decimal? MembershipPctRate { get; set; }

    public byte[]? MerchantAcctKey { get; set; }

    public byte[]? MerchantAcctNbr { get; set; }

    public string? JarvisComments { get; set; }

    public string? NameOfAcceptor { get; set; }

    public bool Older18 { get; set; }

    public bool AcceptAgreement { get; set; }

    public string? UserNameAcceptAgreement { get; set; }

    public string? PlayerTermsAndConditions { get; set; }

    public string? FacilityRentalAgreement { get; set; }

    public string? FacilityAlcoholAgreement { get; set; }

    public decimal? PossalesTax { get; set; }

    public bool? TextPracticeReminders { get; set; }

    public int? GameTimeTextNotificationMinutes { get; set; }

    public int? PracticeTimeTextNotificationMinutes { get; set; }

    public int? FacilityResvTextNotificationMinutes { get; set; }

    public int? FacilityResvNbrDaysInvoiceReminder { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
