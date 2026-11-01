using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Organization
{
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

    public int TimeZone { get; set; }

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

    /// <summary>
    /// Singe or Multiple
    /// </summary>
    public string? ShiftLocationType { get; set; }

    public bool UseMembershipSystem { get; set; }

    public bool UseSeasonPassSystem { get; set; }

    public bool OnlineReserveFacilities { get; set; }

    public bool MedicalReleaseScreen { get; set; }

    public bool RevenueCodeRequired { get; set; }

    public bool PayOnline { get; set; }

    public bool UseDocumentManager { get; set; }

    public bool OnlineApplications { get; set; }

    public bool RequireParticipantMiddleName { get; set; }

    /// <summary>
    /// Set for organizations that have online practice requests from their website and these requests need to be approved.
    /// </summary>
    public bool OnlinePracticeApproval { get; set; }

    /// <summary>
    /// This is set for organizations that have online facility reservations that do not first require approval, but they want to be aware of them and approve them after the reservation has been made and/or paid for.
    /// </summary>
    public bool OnlineFacilityApproval { get; set; }

    public bool ExternalTeamPractice { get; set; }

    public bool OnlineSeasonPass { get; set; }

    // No longer shown on the form and the column is being dropped. It stays mapped until then because it's
    // NOT NULL with no DEFAULT, so inserts must supply it (true - see CreateNewOrganization). Remove this property
    // when the column is dropped.
    public bool SeasonPassAccount { get; set; }

    public bool ValidateResidencyByAddr { get; set; }

    public bool ValidateResidencyByZip { get; set; }

    public bool AllowAmex { get; set; }

    public bool AllowDisc { get; set; }

    public string? PosscreenName { get; set; }

    public string StandingsType { get; set; } = null!;

    public string? BackgroundCheckUrl { get; set; }

    public string? TaxId { get; set; }

    public string? AfterhoursPhone { get; set; }

    public string? GlorRevenueCode { get; set; }

    public bool TylerFinanceSystem { get; set; }

    public bool CaselleFinanceSystem { get; set; }

    /// <summary>
    /// if you feed cash/checks and do not batch cash/checks, then payment is sent to Govt Portal to create import file to Tyler or Caselle
    /// </summary>
    public bool FeedCashChecks { get; set; }

    /// <summary>
    /// if you feed cash/checks and do not batch cash/checks, then payment is sent to Govt Portal to create import file to Tyler or Caselle
    /// </summary>
    public bool BatchCashChecks { get; set; }

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

    public decimal MonthlyBilledAmount { get; set; }

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

    public byte[]? MerchantSecretKey { get; set; }

    public string? JarvisComments { get; set; }

    public string? NameOfAcceptor { get; set; }

    public bool Older18 { get; set; }

    public bool AcceptAgreement { get; set; }

    public string? UserNameAcceptAgreement { get; set; }

    public string? PlayerTermsAndConditions { get; set; }

    public string? FacilityRentalAgreement { get; set; }

    public string? FacilityAlcoholAgreement { get; set; }

    public decimal PossalesTax { get; set; }

    public bool TextGameReminders { get; set; }

    public bool TextPracticeReminders { get; set; }

    public bool MilitaryDiscount { get; set; }

    public int? GameTimeTextNotificationMinutes { get; set; }

    public int? PracticeTimeTextNotificationMinutes { get; set; }

    public int? FacilityResvTextNotificationMinutes { get; set; }

    public int? FacilityResvNbrDaysInvoiceReminder { get; set; }

    public string? LastUpdatedBy { get; set; }

    public bool UseEmvterminal { get; set; }

    public byte[]? EmvappId { get; set; }

    public string? ReportEmail { get; set; }

    public string? ReportPhone { get; set; }

    public string? ReportLogo { get; set; }

    public bool ShiftAutoendMidnight { get; set; }

    public decimal? SeasonPassSalesTax { get; set; }

    public decimal? RegistrationSalesTax { get; set; }

    public string? AccountCreditRevenueCode { get; set; }

    public bool LockBirthdate { get; set; }

    public virtual ICollection<AccountAftercare> AccountAftercares { get; set; } = new List<AccountAftercare>();

    public virtual ICollection<AccountDonation> AccountDonations { get; set; } = new List<AccountDonation>();

    public virtual ICollection<AccountToDocument> AccountToDocuments { get; set; } = new List<AccountToDocument>();

    public virtual ICollection<ActivityCategory> ActivityCategories { get; set; } = new List<ActivityCategory>();

    public virtual ICollection<AdditionalCost> AdditionalCosts { get; set; } = new List<AdditionalCost>();

    public virtual ICollection<AspnetRole> AspnetRoles { get; set; } = new List<AspnetRole>();

    public virtual ICollection<AuthorizeNetBatch> AuthorizeNetBatches { get; set; } = new List<AuthorizeNetBatch>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<CustomQuestion> CustomQuestions { get; set; } = new List<CustomQuestion>();

    public virtual ICollection<District> Districts { get; set; } = new List<District>();

    public virtual ICollection<DonationConfigure> DonationConfigures { get; set; } = new List<DonationConfigure>();

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<EmailTemplate> EmailTemplates { get; set; } = new List<EmailTemplate>();

    public virtual ICollection<FacilityShareGroupMember> FacilityShareGroupMembers { get; set; } = new List<FacilityShareGroupMember>();

    public virtual ICollection<FacilityShare> FacilityShareMainOrganizationNavigations { get; set; } = new List<FacilityShare>();

    public virtual ICollection<FacilityShare> FacilityShareOrganizationKeyNavigations { get; set; } = new List<FacilityShare>();

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();

    public virtual ICollection<MembershipId> MembershipIds { get; set; } = new List<MembershipId>();

    public virtual ICollection<MembershipTypeDescription> MembershipTypeDescriptions { get; set; } = new List<MembershipTypeDescription>();

    public virtual ICollection<MembershipType> MembershipTypes { get; set; } = new List<MembershipType>();

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

    public virtual ICollection<OnlineSession> OnlineSessions { get; set; } = new List<OnlineSession>();

    public virtual ICollection<OrganizationAssociation> OrganizationAssociationAssociatedOrganizationNavigations { get; set; } = new List<OrganizationAssociation>();

    public virtual ICollection<OrganizationAssociation> OrganizationAssociationMainOrganizationNavigations { get; set; } = new List<OrganizationAssociation>();

    public virtual ICollection<Park> Parks { get; set; } = new List<Park>();

    public virtual ICollection<PaymentMerchandise> PaymentMerchandises { get; set; } = new List<PaymentMerchandise>();

    public virtual ICollection<PaymentSponsor> PaymentSponsors { get; set; } = new List<PaymentSponsor>();

    public virtual ICollection<SponsorPledgeDetail> SponsorPledgeDetails { get; set; } = new List<SponsorPledgeDetail>();

    public virtual ICollection<RevenueCode> RevenueCodes { get; set; } = new List<RevenueCode>();

    public virtual ICollection<School> Schools { get; set; } = new List<School>();

    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();

    public virtual ICollection<SpecialEventConfigure> SpecialEventConfigures { get; set; } = new List<SpecialEventConfigure>();

    public virtual ICollection<SpecialEvent> SpecialEvents { get; set; } = new List<SpecialEvent>();

    public virtual ICollection<SponsorPreference> SponsorPreferences { get; set; } = new List<SponsorPreference>();

    public virtual ICollection<SponsorProgram> SponsorPrograms { get; set; } = new List<SponsorProgram>();

    public virtual ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();

    public virtual ICollection<TeamRoster> TeamRosters { get; set; } = new List<TeamRoster>();

    public virtual ICollection<TextMessageOptIn> TextMessageOptIns { get; set; } = new List<TextMessageOptIn>();

    public virtual ICollection<TextMessageSentLogDetail> TextMessageSentLogDetails { get; set; } = new List<TextMessageSentLogDetail>();

    public virtual ICollection<TextMessageSentLog> TextMessageSentLogs { get; set; } = new List<TextMessageSentLog>();

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();

    public virtual ICollection<WebBoard> WebBoards { get; set; } = new List<WebBoard>();

    public virtual ICollection<WebFaq> WebFaqs { get; set; } = new List<WebFaq>();

    public virtual ICollection<WebForm> WebForms { get; set; } = new List<WebForm>();

    public virtual ICollection<WebHomePageContent> WebHomePageContents { get; set; } = new List<WebHomePageContent>();

    public virtual ICollection<WebNewsEvent> WebNewsEvents { get; set; } = new List<WebNewsEvent>();

    public virtual ICollection<WebPageAccess> WebPageAccesses { get; set; } = new List<WebPageAccess>();

    public virtual ICollection<WebWebtext> WebWebtexts { get; set; } = new List<WebWebtext>();

    public virtual ICollection<XFacilityOwnerShareToOrg> XFacilityOwnerShareToOrgs { get; set; } = new List<XFacilityOwnerShareToOrg>();

    public virtual ICollection<XFacilityOwnerShare> XFacilityOwnerShares { get; set; } = new List<XFacilityOwnerShare>();
}
