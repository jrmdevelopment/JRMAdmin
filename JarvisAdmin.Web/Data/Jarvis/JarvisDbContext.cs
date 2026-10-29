using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class JarvisDbContext : DbContext
{
    public JarvisDbContext(DbContextOptions<JarvisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountAftercare> AccountAftercares { get; set; }

    public virtual DbSet<AccountCredit> AccountCredits { get; set; }

    public virtual DbSet<AccountCreditLedgerHeader> AccountCreditLedgerHeaders { get; set; }

    public virtual DbSet<AccountCreditManualSource> AccountCreditManualSources { get; set; }

    public virtual DbSet<AccountCreditReturnSource> AccountCreditReturnSources { get; set; }

    public virtual DbSet<AccountDonation> AccountDonations { get; set; }

    public virtual DbSet<AccountDonationAward> AccountDonationAwards { get; set; }

    public virtual DbSet<AccountDonationPending> AccountDonationPendings { get; set; }

    public virtual DbSet<AccountNote> AccountNotes { get; set; }

    public virtual DbSet<AccountRegistrantLink> AccountRegistrantLinks { get; set; }

    public virtual DbSet<AccountToDocument> AccountToDocuments { get; set; }

    public virtual DbSet<ActivityCalendar> ActivityCalendars { get; set; }

    public virtual DbSet<ActivityCategory> ActivityCategories { get; set; }

    public virtual DbSet<ActivityDate> ActivityDates { get; set; }

    public virtual DbSet<AdditionalCost> AdditionalCosts { get; set; }

    public virtual DbSet<AdditionalCostColor> AdditionalCostColors { get; set; }

    public virtual DbSet<AdditionalCostSize> AdditionalCostSizes { get; set; }

    public virtual DbSet<ApplicationError> ApplicationErrors { get; set; }

    public virtual DbSet<ApplicationPreference> ApplicationPreferences { get; set; }

    public virtual DbSet<AspnetApplication> AspnetApplications { get; set; }

    public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; }

    public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }

    public virtual DbSet<AspnetRole> AspnetRoles { get; set; }

    public virtual DbSet<AspnetRolesToScreen> AspnetRolesToScreens { get; set; }

    public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

    public virtual DbSet<AspnetUser> AspnetUsers { get; set; }

    public virtual DbSet<AspnetUsersInRole> AspnetUsersInRoles { get; set; }

    public virtual DbSet<AuditAccount> AuditAccounts { get; set; }

    public virtual DbSet<AuditAccountAftercare> AuditAccountAftercares { get; set; }

    public virtual DbSet<AuditAccountCredit> AuditAccountCredits { get; set; }

    public virtual DbSet<AuditActivityCategory> AuditActivityCategories { get; set; }

    public virtual DbSet<AuditActivityDate> AuditActivityDates { get; set; }

    public virtual DbSet<AuditAdditionalCost> AuditAdditionalCosts { get; set; }

    public virtual DbSet<AuditAdditionalCostColor> AuditAdditionalCostColors { get; set; }

    public virtual DbSet<AuditAdditionalCostSize> AuditAdditionalCostSizes { get; set; }

    public virtual DbSet<AuditAspnetRole> AuditAspnetRoles { get; set; }

    public virtual DbSet<AuditAspnetRolesToScreen> AuditAspnetRolesToScreens { get; set; }

    public virtual DbSet<AuditAspnetUsersInRole> AuditAspnetUsersInRoles { get; set; }

    public virtual DbSet<AuditCoachApplication> AuditCoachApplications { get; set; }

    public virtual DbSet<AuditCustomQuestion> AuditCustomQuestions { get; set; }

    public virtual DbSet<AuditCustomQuestionDd> AuditCustomQuestionDds { get; set; }

    public virtual DbSet<AuditCustomQuestionProgram> AuditCustomQuestionPrograms { get; set; }

    public virtual DbSet<AuditCustomQuestionProgramDd> AuditCustomQuestionProgramDds { get; set; }

    public virtual DbSet<AuditEmailOptOut> AuditEmailOptOuts { get; set; }

    public virtual DbSet<AuditFacilityAvailableHour> AuditFacilityAvailableHours { get; set; }

    public virtual DbSet<AuditFacilityOtherFee> AuditFacilityOtherFees { get; set; }

    public virtual DbSet<AuditFacilityRate> AuditFacilityRates { get; set; }

    public virtual DbSet<AuditFacilityReservation> AuditFacilityReservations { get; set; }

    public virtual DbSet<AuditFacilityReservationOtherFee> AuditFacilityReservationOtherFees { get; set; }

    public virtual DbSet<AuditFacilitySpace> AuditFacilitySpaces { get; set; }

    public virtual DbSet<AuditFacilityTieredRate> AuditFacilityTieredRates { get; set; }

    public virtual DbSet<AuditFacilityToCustomQuestion> AuditFacilityToCustomQuestions { get; set; }

    public virtual DbSet<AuditLeague> AuditLeagues { get; set; }

    public virtual DbSet<AuditMembership> AuditMemberships { get; set; }

    public virtual DbSet<AuditMembershipDetail> AuditMembershipDetails { get; set; }

    public virtual DbSet<AuditMembershipId> AuditMembershipIds { get; set; }

    public virtual DbSet<AuditOnlineSession> AuditOnlineSessions { get; set; }

    public virtual DbSet<AuditOrganization> AuditOrganizations { get; set; }

    public virtual DbSet<AuditPayment> AuditPayments { get; set; }

    public virtual DbSet<AuditPaymentFacility> AuditPaymentFacilities { get; set; }

    public virtual DbSet<AuditPaymentMembership> AuditPaymentMemberships { get; set; }

    public virtual DbSet<AuditPaymentPo> AuditPaymentPos { get; set; }

    public virtual DbSet<AuditPaymentSpecialEvent> AuditPaymentSpecialEvents { get; set; }

    public virtual DbSet<AuditPaymentSponsor> AuditPaymentSponsors { get; set; }

    public virtual DbSet<AuditRegistrant> AuditRegistrants { get; set; }

    public virtual DbSet<AuditRegistrantToLeague> AuditRegistrantToLeagues { get; set; }

    public virtual DbSet<AuditSeason> AuditSeasons { get; set; }

    public virtual DbSet<AuditSeasonSiblingDiscount> AuditSeasonSiblingDiscounts { get; set; }

    public virtual DbSet<AuditUserDetail> AuditUserDetails { get; set; }

    public virtual DbSet<AuthorizeNetBatch> AuthorizeNetBatches { get; set; }

    public virtual DbSet<Batch20250217> Batch20250217s { get; set; }

    public virtual DbSet<BillingProgramsToExclude> BillingProgramsToExcludes { get; set; }

    public virtual DbSet<BullochAftercare2025> BullochAftercare2025s { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<ClassAttendance> ClassAttendances { get; set; }

    public virtual DbSet<CoachApplication> CoachApplications { get; set; }

    public virtual DbSet<CoachToCustomQuestion> CoachToCustomQuestions { get; set; }

    public virtual DbSet<CreditCardPost> CreditCardPosts { get; set; }

    public virtual DbSet<CustomQuestion> CustomQuestions { get; set; }

    public virtual DbSet<CustomQuestionDd> CustomQuestionDds { get; set; }

    public virtual DbSet<CustomQuestionFacility> CustomQuestionFacilities { get; set; }

    public virtual DbSet<CustomQuestionFacilityDd> CustomQuestionFacilityDds { get; set; }

    public virtual DbSet<CustomQuestionProgram> CustomQuestionPrograms { get; set; }

    public virtual DbSet<CustomQuestionProgramDd> CustomQuestionProgramDds { get; set; }

    public virtual DbSet<CustomReportTemplate> CustomReportTemplates { get; set; }

    public virtual DbSet<DailyBarcodeTicket> DailyBarcodeTickets { get; set; }

    public virtual DbSet<DiscountCode> DiscountCodes { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<DonationConfigure> DonationConfigures { get; set; }

    public virtual DbSet<DonationItem> DonationItems { get; set; }

    public virtual DbSet<DonationItemDropdown> DonationItemDropdowns { get; set; }

    public virtual DbSet<EmailBounceLog> EmailBounceLogs { get; set; }

    public virtual DbSet<EmailDistributionList> EmailDistributionLists { get; set; }

    public virtual DbSet<EmailDistributionListDetail> EmailDistributionListDetails { get; set; }

    public virtual DbSet<EmailOptOut> EmailOptOuts { get; set; }

    public virtual DbSet<EmailSentLog> EmailSentLogs { get; set; }

    public virtual DbSet<EmailSentLogDetail> EmailSentLogDetails { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

    public virtual DbSet<ErrorException> ErrorExceptions { get; set; }

    public virtual DbSet<ErrorExceptionDetail> ErrorExceptionDetails { get; set; }

    public virtual DbSet<ErrorExceptionDetailNew> ErrorExceptionDetailNews { get; set; }

    public virtual DbSet<ErrorExceptionNew> ErrorExceptionNews { get; set; }

    public virtual DbSet<ErrorFeedback> ErrorFeedbacks { get; set; }

    public virtual DbSet<FacilityAvailableHour> FacilityAvailableHours { get; set; }

    public virtual DbSet<FacilityCategory> FacilityCategories { get; set; }

    public virtual DbSet<FacilityChildAssociation> FacilityChildAssociations { get; set; }

    public virtual DbSet<FacilityComplex> FacilityComplexes { get; set; }

    public virtual DbSet<FacilityOtherFee> FacilityOtherFees { get; set; }

    public virtual DbSet<FacilityRate> FacilityRates { get; set; }

    public virtual DbSet<FacilityRatesFlat> FacilityRatesFlats { get; set; }

    public virtual DbSet<FacilityReservation> FacilityReservations { get; set; }

    public virtual DbSet<FacilityReservationOtherFee> FacilityReservationOtherFees { get; set; }

    public virtual DbSet<FacilityShare> FacilityShares { get; set; }

    public virtual DbSet<FacilityShareGroupMember> FacilityShareGroupMembers { get; set; }

    public virtual DbSet<FacilityShareGroupMemberCategory> FacilityShareGroupMemberCategories { get; set; }

    public virtual DbSet<FacilitySpace> FacilitySpaces { get; set; }

    public virtual DbSet<FacilityTieredRate> FacilityTieredRates { get; set; }

    public virtual DbSet<FacilityToCustomQuestion> FacilityToCustomQuestions { get; set; }

    public virtual DbSet<FacilityToSport> FacilityToSports { get; set; }

    public virtual DbSet<GrantFunding> GrantFundings { get; set; }

    public virtual DbSet<GrantFundingPending> GrantFundingPendings { get; set; }

    public virtual DbSet<Holiday> Holidays { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<InvalidCredentialsLog> InvalidCredentialsLogs { get; set; }

    public virtual DbSet<InventoryItem> InventoryItems { get; set; }

    public virtual DbSet<InventoryItemSize> InventoryItemSizes { get; set; }

    public virtual DbSet<InvoiceHistory> InvoiceHistories { get; set; }

    public virtual DbSet<JarvisAdminUser> JarvisAdminUsers { get; set; }

    public virtual DbSet<JerseySize> JerseySizes { get; set; }

    public virtual DbSet<League> Leagues { get; set; }

    public virtual DbSet<LeagueSchedulerDateException> LeagueSchedulerDateExceptions { get; set; }

    public virtual DbSet<LeagueSchedulerFacility> LeagueSchedulerFacilities { get; set; }

    public virtual DbSet<LeagueSchedulerParm> LeagueSchedulerParms { get; set; }

    public virtual DbSet<LeagueSchedulerTeamMatchup> LeagueSchedulerTeamMatchups { get; set; }

    public virtual DbSet<Locker> Lockers { get; set; }

    public virtual DbSet<LockerRange> LockerRanges { get; set; }

    public virtual DbSet<LockerRental> LockerRentals { get; set; }

    public virtual DbSet<LockerType> LockerTypes { get; set; }

    public virtual DbSet<MedicalRelease> MedicalReleases { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<MembershipAddlPerson> MembershipAddlPeople { get; set; }

    public virtual DbSet<MembershipCategory> MembershipCategories { get; set; }

    public virtual DbSet<MembershipCheckin> MembershipCheckins { get; set; }

    public virtual DbSet<MembershipDetail> MembershipDetails { get; set; }

    public virtual DbSet<MembershipId> MembershipIds { get; set; }

    public virtual DbSet<MembershipImport> MembershipImports { get; set; }

    public virtual DbSet<MembershipNote> MembershipNotes { get; set; }

    public virtual DbSet<MembershipPreference> MembershipPreferences { get; set; }

    public virtual DbSet<MembershipScanErrorLog> MembershipScanErrorLogs { get; set; }

    public virtual DbSet<MembershipScanLog> MembershipScanLogs { get; set; }

    public virtual DbSet<MembershipType> MembershipTypes { get; set; }

    public virtual DbSet<MembershipTypeDescription> MembershipTypeDescriptions { get; set; }

    public virtual DbSet<MembershipVisit> MembershipVisits { get; set; }

    public virtual DbSet<MxmerchantBatch> MxmerchantBatches { get; set; }

    public virtual DbSet<MxmerchantBatchTxn> MxmerchantBatchTxns { get; set; }

    public virtual DbSet<OnlineSession> OnlineSessions { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<OrganizationAssociation> OrganizationAssociations { get; set; }

    public virtual DbSet<OrganizationHoliday> OrganizationHolidays { get; set; }

    public virtual DbSet<PantShortSize> PantShortSizes { get; set; }

    public virtual DbSet<Park> Parks { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentFacility> PaymentFacilities { get; set; }

    public virtual DbSet<PaymentInstructor> PaymentInstructors { get; set; }

    public virtual DbSet<PaymentLockerRental> PaymentLockerRentals { get; set; }

    public virtual DbSet<PaymentLockerRentalRefundAllocation> PaymentLockerRentalRefundAllocations { get; set; }

    public virtual DbSet<PaymentMembership> PaymentMemberships { get; set; }

    public virtual DbSet<PaymentMembershipRefundAllocation> PaymentMembershipRefundAllocations { get; set; }

    public virtual DbSet<PaymentMerchandise> PaymentMerchandises { get; set; }

    public virtual DbSet<PaymentPo> PaymentPos { get; set; }

    public virtual DbSet<PaymentRefundAllocation> PaymentRefundAllocations { get; set; }

    public virtual DbSet<PaymentSeasonPass> PaymentSeasonPasses { get; set; }

    public virtual DbSet<PaymentSeasonPassRefundAllocation> PaymentSeasonPassRefundAllocations { get; set; }

    public virtual DbSet<PaymentSpecialEvent> PaymentSpecialEvents { get; set; }

    public virtual DbSet<PaymentSponsor> PaymentSponsors { get; set; }

    public virtual DbSet<PaymentTeam> PaymentTeams { get; set; }

    public virtual DbSet<PaymentTourRefundAllocation> PaymentTourRefundAllocations { get; set; }

    public virtual DbSet<PaymentTourRegistration> PaymentTourRegistrations { get; set; }

    public virtual DbSet<PaymentVendor> PaymentVendors { get; set; }

    public virtual DbSet<Po> Pos { get; set; }

    public virtual DbSet<Poscategory> Poscategories { get; set; }

    public virtual DbSet<Posinventory> Posinventories { get; set; }

    public virtual DbSet<PosinventoryTransaction> PosinventoryTransactions { get; set; }

    public virtual DbSet<Positem> Positems { get; set; }

    public virtual DbSet<Poslocation> Poslocations { get; set; }

    public virtual DbSet<PoslocationType> PoslocationTypes { get; set; }

    public virtual DbSet<Pospreference> Pospreferences { get; set; }

    public virtual DbSet<Posproduct> Posproducts { get; set; }

    public virtual DbSet<PosproductCategory> PosproductCategories { get; set; }

    public virtual DbSet<Postransaction> Postransactions { get; set; }

    public virtual DbSet<PostransactionItem> PostransactionItems { get; set; }

    public virtual DbSet<PostransactionPayment> PostransactionPayments { get; set; }

    public virtual DbSet<PostransactionRefundLine> PostransactionRefundLines { get; set; }

    public virtual DbSet<PostransactionWaiver> PostransactionWaivers { get; set; }

    public virtual DbSet<RecurringDebitAudit> RecurringDebitAudits { get; set; }

    public virtual DbSet<Registrant> Registrants { get; set; }

    public virtual DbSet<RegistrantAdditionalCost> RegistrantAdditionalCosts { get; set; }

    public virtual DbSet<RegistrantAdditionalCostPending> RegistrantAdditionalCostPendings { get; set; }

    public virtual DbSet<RegistrantCustomQuestion> RegistrantCustomQuestions { get; set; }

    public virtual DbSet<RegistrantCustomQuestionPending> RegistrantCustomQuestionPendings { get; set; }

    public virtual DbSet<RegistrantToLeague> RegistrantToLeagues { get; set; }

    public virtual DbSet<RegistrantToLeagueAdjustment> RegistrantToLeagueAdjustments { get; set; }

    public virtual DbSet<RegistrantToLeagueAdjustmentPending> RegistrantToLeagueAdjustmentPendings { get; set; }

    public virtual DbSet<RegistrantToLeagueDay> RegistrantToLeagueDays { get; set; }

    public virtual DbSet<RegistrantToLeagueDayPending> RegistrantToLeagueDayPendings { get; set; }

    public virtual DbSet<RegistrantToLeaguePending> RegistrantToLeaguePendings { get; set; }

    public virtual DbSet<ResidentAddress> ResidentAddresses { get; set; }

    public virtual DbSet<ResidentZipCode> ResidentZipCodes { get; set; }

    public virtual DbSet<RevenueCode> RevenueCodes { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<SeasonPass> SeasonPasses { get; set; }

    public virtual DbSet<SeasonPassAccessType> SeasonPassAccessTypes { get; set; }

    public virtual DbSet<SeasonPassAddOn> SeasonPassAddOns { get; set; }

    public virtual DbSet<SeasonPassAddlPerson> SeasonPassAddlPeople { get; set; }

    public virtual DbSet<SeasonPassCheckin> SeasonPassCheckins { get; set; }

    public virtual DbSet<SeasonPassId> SeasonPassIds { get; set; }

    public virtual DbSet<SeasonPassPreference> SeasonPassPreferences { get; set; }

    public virtual DbSet<SeasonPassPricingTier> SeasonPassPricingTiers { get; set; }

    public virtual DbSet<SeasonPassSetup> SeasonPassSetups { get; set; }

    public virtual DbSet<SeasonSiblingDiscount> SeasonSiblingDiscounts { get; set; }

    public virtual DbSet<SharedProgramLeague> SharedProgramLeagues { get; set; }

    public virtual DbSet<SharedSchedule> SharedSchedules { get; set; }

    public virtual DbSet<SharedScheduleFacility> SharedScheduleFacilities { get; set; }

    public virtual DbSet<SharedScheduleTeam> SharedScheduleTeams { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftLocation> ShiftLocations { get; set; }

    public virtual DbSet<SilverSneakersImportcsv> SilverSneakersImportcsvs { get; set; }

    public virtual DbSet<SkillLevel> SkillLevels { get; set; }

    public virtual DbSet<SpecialEvent> SpecialEvents { get; set; }

    public virtual DbSet<SpecialEventConfigure> SpecialEventConfigures { get; set; }

    public virtual DbSet<SpecialEventItem> SpecialEventItems { get; set; }

    public virtual DbSet<SpecialEventItemPurchase> SpecialEventItemPurchases { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<SponsorPledgeDetail> SponsorPledgeDetails { get; set; }

    public virtual DbSet<SponsorPledgeType> SponsorPledgeTypes { get; set; }

    public virtual DbSet<SponsorPreference> SponsorPreferences { get; set; }

    public virtual DbSet<SponsorProgram> SponsorPrograms { get; set; }

    public virtual DbSet<Statement> Statements { get; set; }

    public virtual DbSet<StatementDetail> StatementDetails { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamAdjustment> TeamAdjustments { get; set; }

    public virtual DbSet<TeamPending> TeamPendings { get; set; }

    public virtual DbSet<TeamRoster> TeamRosters { get; set; }

    public virtual DbSet<TeamStanding> TeamStandings { get; set; }

    public virtual DbSet<TeamToCoach> TeamToCoaches { get; set; }

    public virtual DbSet<TermsAndCondition> TermsAndConditions { get; set; }

    public virtual DbSet<TextMessageOptIn> TextMessageOptIns { get; set; }

    public virtual DbSet<TextMessageOptInTeam> TextMessageOptInTeams { get; set; }

    public virtual DbSet<TextMessageSentLog> TextMessageSentLogs { get; set; }

    public virtual DbSet<TextMessageSentLogDetail> TextMessageSentLogDetails { get; set; }

    public virtual DbSet<TourRegistration> TourRegistrations { get; set; }

    public virtual DbSet<TourType> TourTypes { get; set; }

    public virtual DbSet<TourTypeItem> TourTypeItems { get; set; }

    public virtual DbSet<TourTypeSchedule> TourTypeSchedules { get; set; }

    public virtual DbSet<TourTypeScheduleSlot> TourTypeScheduleSlots { get; set; }

    public virtual DbSet<UsaePayBatchSummaryTemp> UsaePayBatchSummaryTemps { get; set; }

    public virtual DbSet<UsaepayBatch> UsaepayBatches { get; set; }

    public virtual DbSet<UsaepayBatchTotal> UsaepayBatchTotals { get; set; }

    public virtual DbSet<UsaepaybatchPelham> UsaepaybatchPelhams { get; set; }

    public virtual DbSet<UsaepaybatchSpringville> UsaepaybatchSpringvilles { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserPreference> UserPreferences { get; set; }

    public virtual DbSet<ValorDevice> ValorDevices { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VendorChargeItem> VendorChargeItems { get; set; }

    public virtual DbSet<Volunteer> Volunteers { get; set; }

    public virtual DbSet<WebBoard> WebBoards { get; set; }

    public virtual DbSet<WebFaq> WebFaqs { get; set; }

    public virtual DbSet<WebForm> WebForms { get; set; }

    public virtual DbSet<WebHomePageContent> WebHomePageContents { get; set; }

    public virtual DbSet<WebListCategory> WebListCategories { get; set; }

    public virtual DbSet<WebListItem> WebListItems { get; set; }

    public virtual DbSet<WebListPage> WebListPages { get; set; }

    public virtual DbSet<WebNewsEvent> WebNewsEvents { get; set; }

    public virtual DbSet<WebPageAccess> WebPageAccesses { get; set; }

    public virtual DbSet<WebTestimonial> WebTestimonials { get; set; }

    public virtual DbSet<WebTestimonialNote> WebTestimonialNotes { get; set; }

    public virtual DbSet<WebWebtext> WebWebtexts { get; set; }

    public virtual DbSet<WebsiteContactU> WebsiteContactUs { get; set; }

    public virtual DbSet<WebsiteContactUsNote> WebsiteContactUsNotes { get; set; }

    public virtual DbSet<XCrmlead> XCrmleads { get; set; }

    public virtual DbSet<XCrmleadNote> XCrmleadNotes { get; set; }

    public virtual DbSet<XEmailSentLogArchived> XEmailSentLogArchiveds { get; set; }

    public virtual DbSet<XEmailSentLogDetailArchived> XEmailSentLogDetailArchiveds { get; set; }

    public virtual DbSet<XFacilityOwnerShare> XFacilityOwnerShares { get; set; }

    public virtual DbSet<XFacilityOwnerShareToOrg> XFacilityOwnerShareToOrgs { get; set; }

    public virtual DbSet<XFacilityShareGroup> XFacilityShareGroups { get; set; }

    public virtual DbSet<XLeagueSchedulerDh> XLeagueSchedulerDhs { get; set; }

    public virtual DbSet<XLeagueShare> XLeagueShares { get; set; }

    public virtual DbSet<XSalesUser> XSalesUsers { get; set; }

    public virtual DbSet<XSeasonPassAdjustment> XSeasonPassAdjustments { get; set; }

    public virtual DbSet<XTextMessageSentLogArchived> XTextMessageSentLogArchiveds { get; set; }

    public virtual DbSet<XTextMessageSentLogDetailArchived> XTextMessageSentLogDetailArchiveds { get; set; }

    public virtual DbSet<Z00c2> Z00c2s { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountKey);

            entity.ToTable("Account", tb =>
                {
                    tb.HasTrigger("Account_DeleteTrg");
                    tb.HasTrigger("Account_Insert");
                    tb.HasTrigger("Account_Update");
                });

            entity.HasIndex(e => new { e.OrganizationKey, e.LoginEmail }, "idxLoginEmail");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.Account1First)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Account1Last)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Account2First)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Account2Last)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AccountAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AccountState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountZip)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.AlternatePhone1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BusinessName)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.EloginPassword)
                .HasMaxLength(50)
                .HasColumnName("ELoginPassword");
            entity.Property(e => e.EmailAddr2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FacilityPerHourCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastVerifiedDate).HasColumnType("datetime");
            entity.Property(e => e.LinkRegistrantEmailSent).HasColumnType("datetime");
            entity.Property(e => e.LinkRegistrantResponse)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.LinkRegistrantResponseDate).HasColumnType("datetime");
            entity.Property(e => e.LoginEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck).HasColumnName("NSFCheck");
            entity.Property(e => e.PrimaryPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReceivableReminderSent).HasColumnType("datetime");
            entity.Property(e => e.RequestLinkEmailSent).HasColumnType("datetime");
            entity.Property(e => e.ResidencyStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TempbullochAftercare2025Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TEMPBullochAftercare2025Status");
            entity.Property(e => e.VerificationCodeDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AccountAftercare>(entity =>
        {
            entity.HasKey(e => e.AccountAftercareKey).HasName("PK_AccountAftercareKey");

            entity.ToTable("AccountAftercare", tb =>
                {
                    tb.HasTrigger("AccountAftercare_DeleteTrg");
                    tb.HasTrigger("AccountAftercare_InsertTrg");
                    tb.HasTrigger("AccountAftercare_UpdateTrg");
                });

            entity.HasIndex(e => e.AccountKey, "idxAccountKey").IsUnique();

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.AccountHolder1Employer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountHolder2Employer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupAddr1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupAddr2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupAddr3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupAddr4)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupName2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupName3)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupName4)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupPhone1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChildPickupPhone2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChildPickupPhone3)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChildPickupPhone4)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmergencyContact2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactPhone2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmergencyContactRelationship)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactRelationship2)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.InsuranceCompany)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InsurancePolicyNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastVerified).HasColumnType("datetime");

            entity.HasOne(d => d.AccountKeyNavigation).WithOne(p => p.AccountAftercare)
                .HasForeignKey<AccountAftercare>(d => d.AccountKey)
                .HasConstraintName("FK_AccountAftercare_Account");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.AccountAftercares)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountAftercare_Organization");
        });

        modelBuilder.Entity<AccountCredit>(entity =>
        {
            entity.HasKey(e => e.AccountCreditKey);

            entity.ToTable("AccountCredit", tb =>
                {
                    tb.HasTrigger("AccountCredit_DeleteTrg");
                    tb.HasTrigger("AccountCredit_InsertTrg");
                    tb.HasTrigger("AccountCredit_UpdateTrg");
                });

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => e.MerchantBatchId, "idxMerchantBatchId");

            entity.HasIndex(e => new { e.RegistrationNbr, e.ConfirmationNbr }, "idxRegistrationNbr");

            entity.HasIndex(e => e.ShiftKey, "idxShiftKey");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(50)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(50)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditApprovedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreditBalanceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreditSource)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateCreditGiven).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck).HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.AccountCredits)
                .HasForeignKey(d => d.AccountKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountCredit_Account");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.AccountCredits)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_AccountCredit_Shift");
        });

        modelBuilder.Entity<AccountCreditLedgerHeader>(entity =>
        {
            entity.HasKey(e => e.AccountCreditLedgerHeaderKey);

            entity.ToTable("AccountCreditLedgerHeader");

            entity.Property(e => e.CreditAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditBalanceRemaining).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreditSourceType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreditStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateCreditGiven).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AccountCreditManualSource>(entity =>
        {
            entity.HasKey(e => e.AccountCreditManualSourceKey);

            entity.ToTable("AccountCreditManualSource", tb => tb.HasTrigger("AccountCreditManualSource_DeleteTrg"));

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValorTxnId)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AccountCreditReturnSource>(entity =>
        {
            entity.HasKey(e => e.AccountCreditReturnSourceKey);

            entity.ToTable("AccountCreditReturnSource");

            entity.HasIndex(e => e.FacilityReservationKey, "IX_AccountCreditReturnSource_FacilityReservation");

            entity.HasIndex(e => new { e.OrganizationKey, e.ReturnDate }, "IX_AccountCreditReturnSource_OrgReturnDate");

            entity.HasIndex(e => e.RegistrantToLeagueKey, "IX_AccountCreditReturnSource_Registration");

            entity.HasIndex(e => e.SeasonPassKey, "IX_AccountCreditReturnSource_SeasonPass");

            entity.HasIndex(e => new { e.SourceTable, e.SourceTableKey }, "IX_AccountCreditReturnSource_Source");

            entity.HasIndex(e => e.TeamKey, "IX_AccountCreditReturnSource_Team");

            entity.HasIndex(e => e.AccountCreditLedgerHeaderKey, "UX_AccountCreditReturnSource_LedgerHeader").IsUnique();

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.FromRevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OriginPaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.SourceTable)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ToRevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValorTxnId)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AccountDonation>(entity =>
        {
            entity.HasKey(e => e.AccountDonationKey);

            entity.ToTable("AccountDonation");

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => e.MerchantBatchId, "idxMerchantBatchId");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.RegistrationNbr, "idxRegistrationNbr");

            entity.HasIndex(e => e.ShiftKey, "idxShiftKey");

            entity.Property(e => e.AccountDonationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("R(eady) to Award, A(warded) in full, (I)nactive-not going to award");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationBalanceRemaining).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DonationDate).HasColumnType("datetime");
            entity.Property(e => e.DonationRecipient)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.AccountDonations)
                .HasForeignKey(d => d.AccountKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountDonation_Account");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.AccountDonations)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountDonation_Organization");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.AccountDonations)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_AccountDonation_Shift");
        });

        modelBuilder.Entity<AccountDonationAward>(entity =>
        {
            entity.HasKey(e => e.AccountDonationAwardKey);

            entity.ToTable("AccountDonationAward");

            entity.Property(e => e.AwardedAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AwardedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AwardedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AccountDonationKeyNavigation).WithMany(p => p.AccountDonationAwards)
                .HasForeignKey(d => d.AccountDonationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountDonationAward_AccountDonation");

            entity.HasOne(d => d.AwardedAccountNavigation).WithMany(p => p.AccountDonationAwards)
                .HasForeignKey(d => d.AwardedAccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountDonationAward_Account");
        });

        modelBuilder.Entity<AccountDonationPending>(entity =>
        {
            entity.HasKey(e => e.AccountDonationPendingKey).HasName("PK_AccountDonationPendingKey");

            entity.ToTable("AccountDonationPending");

            entity.Property(e => e.DonationAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationDate).HasColumnType("datetime");
            entity.Property(e => e.DonationRecipient)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.RegistrantToLeaguePendingKeyNavigation).WithMany(p => p.AccountDonationPendings)
                .HasForeignKey(d => d.RegistrantToLeaguePendingKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AccountDonationPending_RegistrantToLeaguePending");
        });

        modelBuilder.Entity<AccountNote>(entity =>
        {
            entity.HasKey(e => e.AccountNoteKey);

            entity.ToTable("AccountNote");

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.Property(e => e.AccountNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NoteAddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NoteDateTime).HasColumnType("datetime");
            entity.Property(e => e.NoteStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.AccountNotes)
                .HasForeignKey(d => d.AccountKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountNote_Account");
        });

        modelBuilder.Entity<AccountRegistrantLink>(entity =>
        {
            entity.HasKey(e => e.AccountRegistrantLinkKey);

            entity.ToTable("AccountRegistrantLink");

            entity.HasIndex(e => e.LinkedAccountKey, "idxLinkedAccountKey");

            entity.HasIndex(e => e.PrimaryAccountKey, "idxPrimaryAccountKey");

            entity.HasIndex(e => e.RegistrantKey, "idxRegistrantKey");

            entity.Property(e => e.PrimaryResponseDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AccountToDocument>(entity =>
        {
            entity.HasKey(e => e.AccountToDocumentKey).HasName("PK_AccountDocument");

            entity.ToTable("AccountToDocument");

            entity.HasIndex(e => new { e.OrganizationKey, e.AccountKey, e.DateAdded }, "IX_AccountToDocument_OrganizationKey_AccountKey_DateAdded").IsDescending(false, false, true);

            entity.HasIndex(e => new { e.OrganizationKey, e.VerifiedByOrg, e.DateAdded }, "IX_AccountToDocument_OrganizationKey_VerifiedByOrg_DateAdded").IsDescending(false, false, true);

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => e.DocumentTypeKey, "idxDocumentType");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.RegistrantKey, "idxRegistrantKey");

            entity.Property(e => e.AddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DocumentEncrypted).HasColumnType("image");
            entity.Property(e => e.DocumentFileName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DocumentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pdfencrypted).HasColumnName("PDFEncrypted");

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.AccountToDocuments)
                .HasForeignKey(d => d.AccountKey)
                .HasConstraintName("FK_AccountToDocument_Account");

            entity.HasOne(d => d.DocumentTypeKeyNavigation).WithMany(p => p.AccountToDocuments)
                .HasForeignKey(d => d.DocumentTypeKey)
                .HasConstraintName("FK_AccountToDocument_DocumentType");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.AccountToDocuments)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountToDocument_Organization");

            entity.HasOne(d => d.RegistrantKeyNavigation).WithMany(p => p.AccountToDocuments)
                .HasForeignKey(d => d.RegistrantKey)
                .HasConstraintName("FK_AccountToDocument_Registrant");
        });

        modelBuilder.Entity<ActivityCalendar>(entity =>
        {
            entity.HasKey(e => e.ActivityCalendarKey);

            entity.ToTable("ActivityCalendar");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.AppointmentType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EventComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EventEndTime).HasColumnType("datetime");
            entity.Property(e => e.EventLocation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EventStartTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RecurrenceException).HasColumnType("text");
            entity.Property(e => e.RecurrenceRule).HasMaxLength(1024);
        });

        modelBuilder.Entity<ActivityCategory>(entity =>
        {
            entity.HasKey(e => e.ActivityCategoryKey);

            entity.ToTable("ActivityCategory", tb =>
                {
                    tb.HasTrigger("ActivityCategory_DeleteTrg");
                    tb.HasTrigger("ActivityCategory_Insert");
                    tb.HasTrigger("ActivityCategory_Update");
                });

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.ActivityCategory1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ActivityCategory");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.ActivityCategories)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityCategory_Organization");
        });

        modelBuilder.Entity<ActivityDate>(entity =>
        {
            entity.HasKey(e => e.ActivityDateKey);

            entity.ToTable("ActivityDate", tb =>
                {
                    tb.HasTrigger("ActivityDate_DeleteTrg");
                    tb.HasTrigger("ActivityDate_Insert");
                    tb.HasTrigger("ActivityDate_UpdateTrg");
                });

            entity.HasIndex(e => e.LeagueKey, "idxLeague");

            entity.Property(e => e.ActivityEndTime).HasColumnType("datetime");
            entity.Property(e => e.ActivityStartTime).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.LeagueKeyNavigation).WithMany(p => p.ActivityDates)
                .HasForeignKey(d => d.LeagueKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityDate_League");
        });

        modelBuilder.Entity<AdditionalCost>(entity =>
        {
            entity.HasKey(e => e.AdditionalCostKey);

            entity.ToTable("AdditionalCost", tb =>
                {
                    tb.HasTrigger("AdditionalCost_DeleteTrg");
                    tb.HasTrigger("AdditionalCost_Insert");
                    tb.HasTrigger("AdditionalCost_Update");
                });

            entity.Property(e => e.ItemDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.AdditionalCosts)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdditionalCost_Organization");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.AdditionalCosts)
                .HasForeignKey(d => d.SeasonKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AdditionalCost_Season");
        });

        modelBuilder.Entity<AdditionalCostColor>(entity =>
        {
            entity.HasKey(e => e.AdditionalCostColorKey);

            entity.ToTable("AdditionalCostColor", tb =>
                {
                    tb.HasTrigger("AdditionalCostColor_DeleteTrg");
                    tb.HasTrigger("AdditionalCostColor_Insert");
                    tb.HasTrigger("AdditionalCostColor_Update");
                });

            entity.Property(e => e.ItemColor)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.AdditionalCostKeyNavigation).WithMany(p => p.AdditionalCostColors)
                .HasForeignKey(d => d.AdditionalCostKey)
                .HasConstraintName("FK_AdditionalCostColor_AdditionalCost");
        });

        modelBuilder.Entity<AdditionalCostSize>(entity =>
        {
            entity.HasKey(e => e.AdditionalCostSizeKey);

            entity.ToTable("AdditionalCostSize", tb =>
                {
                    tb.HasTrigger("AdditionalCostSize_DeleteTrg");
                    tb.HasTrigger("AdditionalCostSize_Insert");
                    tb.HasTrigger("AdditionalCostSize_Update");
                });

            entity.Property(e => e.ItemSize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.AdditionalCostKeyNavigation).WithMany(p => p.AdditionalCostSizes)
                .HasForeignKey(d => d.AdditionalCostKey)
                .HasConstraintName("FK_AdditionalCostSize_AdditionalCost");
        });

        modelBuilder.Entity<ApplicationError>(entity =>
        {
            entity.HasKey(e => e.ApplicationErrorKey);

            entity.ToTable("ApplicationError");

            entity.Property(e => e.Browser)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.ErrorMessage).HasColumnType("text");
            entity.Property(e => e.ErrorThrown).HasColumnType("text");
            entity.Property(e => e.ErrorType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OperatingSystem)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PageName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ResponseData).HasColumnType("text");
            entity.Property(e => e.ResponseText).HasColumnType("text");
            entity.Property(e => e.StatusText).HasColumnType("text");
            entity.Property(e => e.UserAgent).HasColumnType("text");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApplicationPreference>(entity =>
        {
            entity.HasKey(e => e.ApplicationPreferenceKey);

            entity.ToTable("ApplicationPreference");

            entity.HasIndex(e => new { e.OrganizationKey, e.ApplicationType }, "idxOrgAndType");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.ApplicationType)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationWaiver).HasColumnType("text");
            entity.Property(e => e.BackgroundCheckUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BackgroundCheckURL");
            entity.Property(e => e.BackgroundFeeToCoach).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DobonApplication).HasColumnName("DOBOnApplication");
            entity.Property(e => e.SsnonApplication).HasColumnName("SSNOnApplication");
        });

        modelBuilder.Entity<AspnetApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId)
                .HasName("PK__aspnet_A__C93A4C9860207986")
                .IsClustered(false);

            entity.ToTable("aspnet_Applications");

            entity.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE462FCE631").IsUnique();

            entity.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__3091033165D952DC").IsUnique();

            entity.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index").IsClustered();

            entity.Property(e => e.ApplicationId).ValueGeneratedNever();
            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspnetMembership>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_M__1788CC4D7EA500A6")
                .IsClustered(false);

            entity.ToTable("aspnet_Membership");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail }, "aspnet_Membership_index").IsClustered();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.Password).HasMaxLength(128);
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.PasswordSalt).HasMaxLength(128);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetMemberships)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__Appli__008D4918");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetMembership)
                .HasForeignKey<AspnetMembership>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__UserI__01816D51");
        });

        modelBuilder.Entity<AspnetProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__aspnet_P__1788CC4C158865FE");

            entity.ToTable("aspnet_Profile");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PropertyNames).HasColumnType("ntext");
            entity.Property(e => e.PropertyValuesBinary).HasColumnType("image");
            entity.Property(e => e.PropertyValuesString).HasColumnType("ntext");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetProfile)
                .HasForeignKey<AspnetProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pr__UserI__1770AE70");
        });

        modelBuilder.Entity<AspnetRole>(entity =>
        {
            entity.HasKey(e => e.RoleId)
                .HasName("PK__aspnet_R__8AFACE1B20FA18AA")
                .IsClustered(false);

            entity.ToTable("aspnet_Roles", tb =>
                {
                    tb.HasTrigger("AspnetRoles_Delete");
                    tb.HasTrigger("AspnetRoles_Insert");
                });

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName, e.OrganizationKey }, "aspnet_Roles_index1")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Ro__Appli__22E2611C");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.AspnetRoles)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_aspnet_Roles_Organization");
        });

        modelBuilder.Entity<AspnetRolesToScreen>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.ScreenName });

            entity.ToTable("aspnet_RolesToScreens", tb =>
                {
                    tb.HasTrigger("AspnetRolesToScreens_Delete");
                    tb.HasTrigger("AspnetRolesToScreens_Insert");
                });

            entity.HasIndex(e => e.RoleId, "idxRoleId");

            entity.HasIndex(e => e.ScreenName, "idxScreenName");

            entity.Property(e => e.ScreenName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.AspnetRolesToScreens)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_aspnet_RolesToScreens_aspnet_Roles");
        });

        modelBuilder.Entity<AspnetSchemaVersion>(entity =>
        {
            entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion }).HasName("PK__aspnet_S__5A1E6BC1723F29C1");

            entity.ToTable("aspnet_SchemaVersions");

            entity.Property(e => e.Feature).HasMaxLength(128);
            entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
        });

        modelBuilder.Entity<AspnetUser>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_U__1788CC4D6A9E07F9")
                .IsClustered(false);

            entity.ToTable("aspnet_Users");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetUsers)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__Appli__6C86506B");
        });

        modelBuilder.Entity<AspnetUsersInRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__aspnet_U__AF2760AD26B2F200");

            entity.ToTable("aspnet_UsersInRoles", tb =>
                {
                    tb.HasTrigger("AspnetUsersInRoles_Delete");
                    tb.HasTrigger("AspnetUsersInRoles_Insert");
                });

            entity.HasIndex(e => e.RoleId, "aspnet_UsersInRoles_index");

            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.AspnetUsersInRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__RoleI__298F5EAB");

            entity.HasOne(d => d.User).WithMany(p => p.AspnetUsersInRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__UserI__289B3A72");
        });

        modelBuilder.Entity<AuditAccount>(entity =>
        {
            entity.HasKey(e => e.AuditAccountKey);

            entity.ToTable("Audit_Account");

            entity.Property(e => e.Account1First)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Account1Last)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Account2First)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Account2Last)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AccountAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AccountState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AccountZip)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.AlternatePhone1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.BusinessName)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.EloginPassword)
                .HasMaxLength(50)
                .HasColumnName("ELoginPassword");
            entity.Property(e => e.EmailAddr2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FacilityPerHourCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastVerifiedDate).HasColumnType("datetime");
            entity.Property(e => e.LinkRegistrantEmailSent).HasColumnType("datetime");
            entity.Property(e => e.LinkRegistrantResponse)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.LinkRegistrantResponseDate).HasColumnType("datetime");
            entity.Property(e => e.LoginEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck).HasColumnName("NSFCheck");
            entity.Property(e => e.PrimaryPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReceivableReminderSent).HasColumnType("datetime");
            entity.Property(e => e.RequestLinkEmailSent).HasColumnType("datetime");
            entity.Property(e => e.ResidencyStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VerificationCodeDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AuditAccountAftercare>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_AccountAftercare");

            entity.Property(e => e.AccountHolder1Employer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccountHolder2Employer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditAftercareKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.ChildPickupAddr1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupAddr2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupAddr3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupAddr4)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupName2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupName3)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupName4)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildPickupPhone1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChildPickupPhone2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChildPickupPhone3)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ChildPickupPhone4)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmergencyContact2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactPhone2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmergencyContactRelationship)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactRelationship2)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.InsuranceCompany)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InsurancePolicyNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastVerified).HasColumnType("datetime");
        });

        modelBuilder.Entity<AuditAccountCredit>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_AccountCredit");

            entity.Property(e => e.AuditAccountCreditKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(50)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(50)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditApprovedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CreditBalanceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreditDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreditSource)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateCreditGiven).HasColumnType("datetime");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck).HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditActivityCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_ActivityCategory");

            entity.Property(e => e.ActivityCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ActivityType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditActivityCategoryKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<AuditActivityDate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_ActivityDate");

            entity.Property(e => e.ActivityEndTime).HasColumnType("datetime");
            entity.Property(e => e.ActivityStartTime).HasColumnType("datetime");
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditActivityDateKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
        });

        modelBuilder.Entity<AuditAdditionalCost>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_AdditionalCost");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditAdditionalCostKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<AuditAdditionalCostColor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_AdditionalCostColor");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditAdditionalCostColorKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.ItemColor)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditAdditionalCostSize>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_AdditionalCostSize");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditAdditionalCostSizeKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.ItemSize)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditAspnetRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_AspnetRoles");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.AuditUserDetailsRolesKey).ValueGeneratedOnAdd();
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);
        });

        modelBuilder.Entity<AuditAspnetRolesToScreen>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_AspnetRolesToScreens");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditAspnetRolesToScreens).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.ScreenName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditAspnetUsersInRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_AspnetUsersInRoles");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditAspnetUsersInRolesKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
        });

        modelBuilder.Entity<AuditCoachApplication>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_CoachApplication");

            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditCoachApplicationKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.BackgroundCheckBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CoachAppEmail).HasColumnType("datetime");
            entity.Property(e => e.CoachFirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CoachLastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CommentsFromReviewer).HasColumnType("text");
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmedDate).HasColumnType("datetime");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CriminalOffense)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateOfBgcheck)
                .HasColumnType("datetime")
                .HasColumnName("DateOfBGCheck");
            entity.Property(e => e.EmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Employer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployerAddress)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.EncryptedSsn)
                .HasMaxLength(50)
                .HasColumnName("EncryptedSSN");
            entity.Property(e => e.EverSuspended)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ImageFileName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PassBackgroundCheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PlayerToCoach)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PreviousAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PreviousCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PreviousState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PreviousZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName3)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReferencePhone1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReferencePhone2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReferencePhone3)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RelationshipToPlayer)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfApplication)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerCapacity)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditCustomQuestion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_CustomQuestion");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditCustomQuestionKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.CustomQuestion)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.QuestionArea)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.QuestionStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuestionType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReportLabel)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditCustomQuestionDd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_CustomQuestionDD");

            entity.Property(e => e.AssociatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditCustomQuestionDdkey)
                .ValueGeneratedOnAdd()
                .HasColumnName("AuditCustomQuestionDDKey");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.CustomQuestionDdkey).HasColumnName("CustomQuestionDDKey");
            entity.Property(e => e.DropdownText)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditCustomQuestionProgram>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_CustomQuestionProgram");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditCustomQuestionProgramKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.CustomQuestion)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CustomQuestionAdded).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.QuestionArea)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.QuestionType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.ReportLabel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<AuditCustomQuestionProgramDd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_CustomQuestionProgramDD");

            entity.Property(e => e.AssociatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditCustomQuestionProgramDdkey)
                .ValueGeneratedOnAdd()
                .HasColumnName("AuditCustomQuestionProgramDDKey");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.CustomQuestionProgramDdkey).HasColumnName("CustomQuestionProgramDDKey");
            entity.Property(e => e.DropdownText)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditEmailOptOut>(entity =>
        {
            entity.HasKey(e => e.AuditEmailOptOutKey);

            entity.ToTable("Audit_EmailOptOut");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OptOutDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AuditFacilityAvailableHour>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_FacilityAvailableHours");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditFacilityAvailableHoursKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.FridayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FridayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LightFeeStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MondayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MondayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SaturdayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SaturdayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SundayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SundayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ThursdayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Thursdayend)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TuesdayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TuesdayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.WednesdayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.WednesdayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditFacilityOtherFee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_FacilityOtherFee");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditFacilityOtherFeeKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.FlatOrHourly)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.OptionalOrRequired)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.OtherFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OtherFeeDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OtherFeeDescriptionText)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.OtherFeeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TimeFeeStarts)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditFacilityRate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_FacilityRates");

            entity.Property(e => e.AdditionalPerHour).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AlcoholAgreement).IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditFacilityRatesKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.DailyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DailyRateNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DailyRateNonprofit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EndDateToReserve).HasColumnType("datetime");
            entity.Property(e => e.FullDayRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FullDayRateNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FullDayRateNonprofit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HalfDayRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HalfDayRateNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HalfDayRateNonprofit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HourlyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HourlyRateNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HourlyRateNonprofit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaximumDaysInAdvance).HasComment("Maximum number of days between booking and actual reservation.");
            entity.Property(e => e.MaximumWithTablesChairs).HasColumnName("MaximumWIthTablesChairs");
            entity.Property(e => e.NoAlcoholAgreement).IsUnicode(false);
            entity.Property(e => e.RentalAgreement).IsUnicode(false);
            entity.Property(e => e.ReservationDaysInAdvance).HasComment("Minimum days between booking and actual reservation. For example, if 2, you could not reserve the day before.");
            entity.Property(e => e.SecurityDeposit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositAlcohol).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositAlcoholNon).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StartDateToReserve).HasColumnType("datetime");
        });

        modelBuilder.Entity<AuditFacilityReservation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_FacilityReservation");

            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AlcoholAgreement).IsUnicode(false);
            entity.Property(e => e.ApplicantAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicantEmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicantZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditFacilityReservationKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateOfReservation).HasColumnType("datetime");
            entity.Property(e => e.EndTimeOfEvent).HasColumnType("datetime");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HeldDepositInformation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MembershipDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NoAlcoholAgreement).IsUnicode(false);
            entity.Property(e => e.PurposeOfUse)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.RentalAgreement).IsUnicode(false);
            entity.Property(e => e.ReservationAdjustment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReservationComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ReservationFeeCharged).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReservationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReservationType)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.ResidentNon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RoomConfiguration)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositCharged).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositKeptReason)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDepositReturnAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositReturnDate).HasColumnType("datetime");
            entity.Property(e => e.StartTimeOfEvent).HasColumnType("datetime");
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalOptionalFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalRequiredFee).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<AuditFacilityReservationOtherFee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_FacilityReservationOtherFees");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditFacilityReservationOtherFeesKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.OtherFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TimeFeeStarts)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditFacilitySpace>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_FacilitySpace");

            entity.Property(e => e.ActiveInactive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditFacilitySpaceKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.DepositRevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DirectionsToFacility).IsUnicode(false);
            entity.Property(e => e.FacilityAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FacilityName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FacilityState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FacilityStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FacilityZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.XRentalFacility).HasColumnName("xRentalFacility");
        });

        modelBuilder.Entity<AuditFacilityTieredRate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_FacilityTieredRates");

            entity.Property(e => e.AdditionalFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditFacilityTieredRatesKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.FacilityTieredRatesStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<AuditFacilityToCustomQuestion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_FacilityToCustomQuestion");

            entity.Property(e => e.Answer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditFacilityToCustomQuestionKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
        });

        modelBuilder.Entity<AuditLeague>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_League");

            entity.Property(e => e.ActivityDateTimeInfo)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditLeagueKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.BirthDateHigh).HasColumnType("datetime");
            entity.Property(e => e.BirthDateLow).HasColumnType("datetime");
            entity.Property(e => e.EarlyBirdAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EarlyBirdBasedOn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EarlyBirdDate).HasColumnType("datetime");
            entity.Property(e => e.LateRegAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LateRegStart).HasColumnType("datetime");
            entity.Property(e => e.LateRegistrationBasedOn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LeagueName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LeagueStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocationInformation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MilitaryDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinimumDeposit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinimumDepositPct).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NonmemberFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PlayerFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationSessionEnd).HasColumnType("datetime");
            entity.Property(e => e.RegistrationSessionStart).HasColumnType("datetime");
            entity.Property(e => e.TeamFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValidateEligibility)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<AuditMembership>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_Membership");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditMembershipKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MemberAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberAlternatePhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberBirthDate).HasColumnType("datetime");
            entity.Property(e => e.MemberCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MemberEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberFirstName)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.MemberLastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MemberPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberZipcode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MembershipNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyBankDraft)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MonthlyBankDraftCancelBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyBankDraftCancelDate).HasColumnType("datetime");
            entity.Property(e => e.MonthlyBankDraftStartDate).HasColumnType("datetime");
            entity.Property(e => e.PlaceOfEmployment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentAddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentAddedDate).HasColumnType("datetime");
            entity.Property(e => e.RecurringPaymentCancelBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentCancelDate).HasColumnType("datetime");
            entity.Property(e => e.RecurringPaymentLastFour).HasMaxLength(25);
            entity.Property(e => e.RecurringPaymentRegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ReminderEmailSent).HasColumnType("datetime");
        });

        modelBuilder.Entity<AuditMembershipDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_MembershipDetail");

            entity.Property(e => e.AddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AddlPersonCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditMembershipDetailKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountReason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DraftReconcileDate).HasColumnType("datetime");
            entity.Property(e => e.LostCardCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipEndDate).HasColumnType("datetime");
            entity.Property(e => e.MembershipStartDate).HasColumnType("datetime");
            entity.Property(e => e.NsffeeTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFeeTotal");
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<AuditMembershipId>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_MembershipId");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditMembershipIdKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.MembershipIdStatus)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditOnlineSession>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_OnlineSession");

            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.DateSessionAdded).HasColumnType("datetime");
            entity.Property(e => e.NameForLookup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OnlineSessionId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SessionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.WebsiteDomainName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditOrganization>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_Organization");

            entity.Property(e => e.ActivityPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AfterhoursPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AllowAmex).HasColumnName("AllowAMEX");
            entity.Property(e => e.AllowDisc).HasColumnName("AllowDISC");
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditOrganizationKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.BackgroundCheckUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BackgroundCheckURL");
            entity.Property(e => e.ContactEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DailyPercentage).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DomainName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EditorCssfile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EditorCSSFile");
            entity.Property(e => e.FacilityAlcoholAgreement).HasColumnType("text");
            entity.Property(e => e.FacilityRentalAgreement).HasColumnType("text");
            entity.Property(e => e.FacilitySalesTax).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.FeeScheduleFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FeeStructure)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FromEmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FromEmailPw)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FromEmailPW");
            entity.Property(e => e.GatewayUsed)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GlorRevenueCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GLOrRevenueCode");
            entity.Property(e => e.ImageEditorPath)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JarvisComments).HasColumnType("text");
            entity.Property(e => e.LeagueMgmtPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipFlatOrPercent)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.MembershipFlatRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipPctRate).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MerchantAcctKey).HasMaxLength(75);
            entity.Property(e => e.MerchantAcctNbr).HasMaxLength(75);
            entity.Property(e => e.MerchantPctToRegistrant).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MinimumConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MonthlyBilledAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NameForLookup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameOfAcceptor)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationCity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationSt)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OrganizationZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PaymentFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlayerTermsAndConditions).HasColumnType("text");
            entity.Property(e => e.PossalesTax)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("POSSalesTax");
            entity.Property(e => e.PosscreenName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("POSScreenName");
            entity.Property(e => e.PracticeTimeTextNotificationMinutes).HasColumnName("PracticeTimeTExtNotificationMinutes");
            entity.Property(e => e.ServiceAgreementFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StandingsType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SwipePctToRegistrant).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TaxId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TeamPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserNameAcceptAgreement)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditPayment>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_Payment");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditPaymentFacility>(entity =>
        {
            entity.HasKey(e => e.AuditPaymentFacilityKey);

            entity.ToTable("Audit_PaymentFacility");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditPaymentMembership>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_PaymentMembership");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditPaymentMembershipKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentNotes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditPaymentPo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_PaymentPOS");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditPaymentPoskey)
                .ValueGeneratedOnAdd()
                .HasColumnName("AuditPaymentPOSKey");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPoskey).HasColumnName("PaymentPOSKey");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Poskey).HasColumnName("POSKey");
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesTax).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<AuditPaymentSpecialEvent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_PaymentSpecialEvent");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditPaymentSponsor>(entity =>
        {
            // the pre-2026-10-16 sponsor payment audit rows (old single-table columns), renamed
            // Audit_PaymentSponsorOld on 2026-10-24 when Audit_PaymentSponsor was re-created for
            // the new PaymentSponsor table
            entity
                .HasNoKey()
                .ToTable("Audit_PaymentSponsorOld");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ChildsAgeGroup)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateOfRefund).HasColumnType("datetime");
            entity.Property(e => e.FirstChoiceUniformColor)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PersonSponsoring)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RefundInformation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefundMerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RefundNotes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.RefundPaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RefundedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SecondChoiceUniformColor)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SponsorAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SponsorshipAdded).HasColumnType("datetime");
            entity.Property(e => e.SponsorshipExpiration).HasColumnType("datetime");
        });

        modelBuilder.Entity<AuditRegistrant>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_Registrant");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditRegistrantKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HospitalChoice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MedicalConditions)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ParticipantPhysician)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PhysicianPhoneNbr)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegistrantStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SpecialNeeds)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditRegistrantToLeague>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_RegistrantToLeague");

            entity.Property(e => e.AcceptTc).HasColumnName("AcceptTC");
            entity.Property(e => e.AddlCostItemTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApproximateHeight)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.CoachName1)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.CoachName2)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.CoachType1)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.CoachType2)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EarlyBirdDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Grade)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.JerseySize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LateRegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nsftotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFTotal");
            entity.Property(e => e.PantShortSize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PreviousSeasonDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.RegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RemovedFromWaitlistDate).HasColumnType("datetime");
            entity.Property(e => e.RequestedCoach)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RequestedFriend)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RequestedTeam)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SchoolAttending)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.SiblingDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TotalInvoiceAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaidAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VolunteerCapacity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerCapacity2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerInterestEmailReminder).HasColumnType("datetime");
            entity.Property(e => e.VolunteerName1)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerName2)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.WaiverCoach)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditSeason>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_Season");

            entity.Property(e => e.AgeRequirementText)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditSeasonKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.CoachApplicationEnd).HasColumnType("datetime");
            entity.Property(e => e.CoachApplicationStart).HasColumnType("datetime");
            entity.Property(e => e.ComputeAgeAsOf).HasColumnType("datetime");
            entity.Property(e => e.CostInformation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateInformation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DonationRevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GenderSpecific)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MembershipDollarDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NonResidentRegistrationStart).HasColumnType("datetime");
            entity.Property(e => e.NotifyEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OneOrMultipleSessions)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.PreviousProgramDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProgramDescription).IsUnicode(false);
            entity.Property(e => e.ProgramLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProgramName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProgramType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationEnd).HasColumnType("datetime");
            entity.Property(e => e.RegistrationReceipt)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationStart).HasColumnType("datetime");
            entity.Property(e => e.RegistrationType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ResidentsOnly)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SeasonContactEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeasonContactName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SeasonContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SeasonPassDollarDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SeasonStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SiblingDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnreturnedEquipFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WaitlistEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuditSeasonSiblingDiscount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_SeasonSiblingDiscount");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditSeasonSiblingDiscountKey).ValueGeneratedOnAdd();
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
        });

        modelBuilder.Entity<AuditUserDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Audit_UserDetails");

            entity.Property(e => e.AuditAction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Audit_Action");
            entity.Property(e => e.AuditTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("Audit_Timestamp");
            entity.Property(e => e.AuditUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Audit_User");
            entity.Property(e => e.AuditUserDetailsKey).ValueGeneratedOnAdd();
            entity.Property(e => e.UserIdStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AuthorizeNetBatch>(entity =>
        {
            entity.HasKey(e => e.AuthorizeNetBatchKey);

            entity.ToTable("AuthorizeNetBatch");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.BatchTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DifferenceComments).HasColumnType("text");
            entity.Property(e => e.JarvisBatchTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SettleDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.AuthorizeNetBatches)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthorizeNetBatch_Organization");
        });

        modelBuilder.Entity<Batch20250217>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("batch_20250217");

            entity.Property(e => e.Amount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("amount");
            entity.Property(e => e.BatchId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("batch_id");
            entity.Property(e => e.Closed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("closed");
            entity.Property(e => e.Count)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("count");
            entity.Property(e => e.Opened)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("opened");
            entity.Property(e => e.Organizationkey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("organizationkey");
            entity.Property(e => e.Seq)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("seq");
        });

        modelBuilder.Entity<BillingProgramsToExclude>(entity =>
        {
            entity.HasKey(e => e.SeasonKey);

            entity.ToTable("BillingProgramsToExclude");

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.Property(e => e.SeasonKey).ValueGeneratedNever();
        });

        modelBuilder.Entity<BullochAftercare2025>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("bullochAftercare2025");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PrimaryPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityKey);

            entity.ToTable("City");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.CityName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CityStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HomeCity)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Organization");
        });

        modelBuilder.Entity<ClassAttendance>(entity =>
        {
            entity.HasKey(e => e.ClassAttendanceKey);

            entity.ToTable("ClassAttendance");

            entity.Property(e => e.CheckInBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CheckInDateTime).HasColumnType("datetime");
            entity.Property(e => e.CheckOutBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CheckOutDateTime).HasColumnType("datetime");
            entity.Property(e => e.CheckedOutRelationship)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CheckedOutTo)
                .HasMaxLength(36)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CoachApplication>(entity =>
        {
            entity.HasKey(e => e.CoachApplicationKey).HasName("PK_CoachAplication");

            entity.ToTable("CoachApplication", tb =>
                {
                    tb.HasTrigger("CoachApplication_DeleteTrg");
                    tb.HasTrigger("CoachApplication_Insert");
                    tb.HasTrigger("CoachApplication_Update");
                });

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => e.LeagueKey, "idxLeagueKey");

            entity.HasIndex(e => e.MerchantBatchId, "idxMerchantBatchId");

            entity.HasIndex(e => e.RegistrationNbr, "idxRegistrationNbr");

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.HasIndex(e => e.ShiftKey, "idxShiftKey");

            entity.Property(e => e.ApplicationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("(S)ubmitted, (A)ctive, (I)nactive, (D)enied");
            entity.Property(e => e.BackgroundCheckBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.BackgroundExplain).IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CoachAppEmail).HasColumnType("datetime");
            entity.Property(e => e.CoachFirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CoachLastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CodeOfConductDate).HasColumnType("datetime");
            entity.Property(e => e.CommentsFromReviewer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmedDate).HasColumnType("datetime");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CriminalOffense)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateOfBgcheck)
                .HasColumnType("datetime")
                .HasColumnName("DateOfBGCheck");
            entity.Property(e => e.EmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Employer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployerAddress)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.EncryptedSsn)
                .HasMaxLength(50)
                .HasColumnName("EncryptedSSN");
            entity.Property(e => e.EverSuspended)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ImageFileName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PassBackgroundCheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PlayerToCoach)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PreviousAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PreviousCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PreviousState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PreviousZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceName3)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReferencePhone1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReferencePhone2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReferencePhone3)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RelationshipToPlayer)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfApplication)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerCapacity)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.CoachApplications)
                .HasForeignKey(d => d.AccountKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoachApplication_Account");

            entity.HasOne(d => d.LeagueKeyNavigation).WithMany(p => p.CoachApplications)
                .HasForeignKey(d => d.LeagueKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoachApplication_League");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.CoachApplications)
                .HasForeignKey(d => d.SeasonKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoachApplication_Season");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.CoachApplications)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_CoachApplication_Shift");
        });

        modelBuilder.Entity<CoachToCustomQuestion>(entity =>
        {
            entity.HasKey(e => e.CoachToCustomQuestionKey);

            entity.ToTable("CoachToCustomQuestion");

            entity.HasIndex(e => e.ApplicationKey, "idxApplicationKey");

            entity.HasIndex(e => new { e.CustomQuestionKey, e.TypeOfApplication }, "idxCustomQuestionKeyType");

            entity.Property(e => e.Answer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfApplication)
                .HasMaxLength(9)
                .IsUnicode(false);

            entity.HasOne(d => d.ApplicationKeyNavigation).WithMany(p => p.CoachToCustomQuestions)
                .HasForeignKey(d => d.ApplicationKey)
                .HasConstraintName("FK_CoachToCustomQuestion_CoachApplication");

            entity.HasOne(d => d.CustomQuestionKeyNavigation).WithMany(p => p.CoachToCustomQuestions)
                .HasForeignKey(d => d.CustomQuestionKey)
                .HasConstraintName("FK_CoachToCustomQuestion_CustomQuestion");
        });

        modelBuilder.Entity<CreditCardPost>(entity =>
        {
            entity.HasKey(e => e.CreditCardPostKey);

            entity.ToTable("CreditCardPost");

            entity.Property(e => e.CreditCardPost1)
                .HasColumnType("text")
                .HasColumnName("CreditCardPost");
            entity.Property(e => e.PostDate).HasColumnType("datetime");
            entity.Property(e => e.PostResponse).HasColumnType("text");
            entity.Property(e => e.PostSource)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomQuestion>(entity =>
        {
            entity.HasKey(e => e.CustomQuestionKey);

            entity.ToTable("CustomQuestion", tb =>
                {
                    tb.HasTrigger("CustomQuestion_DeleteTrg");
                    tb.HasTrigger("CustomQuestion_Insert");
                });

            entity.HasIndex(e => new { e.OrganizationKey, e.QuestionType, e.QuestionStatus }, "idxOrgStatusType");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.CustomQuestion1)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("CustomQuestion");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.QuestionArea)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.QuestionStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuestionType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ReportLabel)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.CustomQuestions)
                .HasForeignKey(d => d.OrganizationKey)
                .HasConstraintName("FK_CustomQuestion_Organization");
        });

        modelBuilder.Entity<CustomQuestionDd>(entity =>
        {
            entity.HasKey(e => e.CustomQuestionDdkey);

            entity.ToTable("CustomQuestionDD", tb =>
                {
                    tb.HasTrigger("CustomQuestionDD_DeleteTrg");
                    tb.HasTrigger("CustomQuestionDD_Insert");
                    tb.HasTrigger("CustomQuestionDD_Update");
                });

            entity.HasIndex(e => e.CustomQuestionKey, "idxCustomQuestionKey");

            entity.Property(e => e.CustomQuestionDdkey).HasColumnName("CustomQuestionDDKey");
            entity.Property(e => e.AssociatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DropdownText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.CustomQuestionKeyNavigation).WithMany(p => p.CustomQuestionDds)
                .HasForeignKey(d => d.CustomQuestionKey)
                .HasConstraintName("FK_CustomQuestionDD_CustomQuestion");
        });

        modelBuilder.Entity<CustomQuestionFacility>(entity =>
        {
            entity.HasKey(e => e.CustomQuestionFacilityKey);

            entity.ToTable("CustomQuestionFacility");

            entity.HasIndex(e => e.FacilitySpaceKey, "idxFacilitySpaceKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.CustomQuestion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.QuestionStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.QuestionType)
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.CustomQuestionFacilities)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .HasConstraintName("FK_CustomQuestionFacility_FacilitySpace");
        });

        modelBuilder.Entity<CustomQuestionFacilityDd>(entity =>
        {
            entity.HasKey(e => e.CustomQuestionFacilityDdkey);

            entity.ToTable("CustomQuestionFacilityDD");

            entity.HasIndex(e => e.CustomQuestionFacilityKey, "idxCustomQuestionFacilityKey");

            entity.Property(e => e.CustomQuestionFacilityDdkey).HasColumnName("CustomQuestionFacilityDDKey");
            entity.Property(e => e.DropdownText)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.CustomQuestionFacilityKeyNavigation).WithMany(p => p.CustomQuestionFacilityDds)
                .HasForeignKey(d => d.CustomQuestionFacilityKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomQuestionFacilityDD_CustomQuestionFacility");
        });

        modelBuilder.Entity<CustomQuestionProgram>(entity =>
        {
            entity.HasKey(e => e.CustomQuestionProgramKey);

            entity.ToTable("CustomQuestionProgram", tb =>
                {
                    tb.HasTrigger("CustomQuestionProgram_DeleteTrg");
                    tb.HasTrigger("CustomQuestionProgram_Insert");
                    tb.HasTrigger("CustomQuestionProgram_Update");
                });

            entity.HasIndex(e => e.CustomQuestionKey, "idxCustomQuestionKey");

            entity.Property(e => e.CustomQuestion)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.CustomQuestionAdded).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.QuestionArea)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.QuestionType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.ReportLabel)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.CustomQuestionKeyNavigation).WithMany(p => p.CustomQuestionPrograms)
                .HasForeignKey(d => d.CustomQuestionKey)
                .HasConstraintName("FK_CustomQuestionProgram_CustomQuestion");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.CustomQuestionPrograms)
                .HasForeignKey(d => d.SeasonKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomQuestionProgram_Season");
        });

        modelBuilder.Entity<CustomQuestionProgramDd>(entity =>
        {
            entity.HasKey(e => e.CustomQuestionProgramDdkey).HasName("PK_CustomQuestionProgramList");

            entity.ToTable("CustomQuestionProgramDD", tb =>
                {
                    tb.HasTrigger("CustomQuestionProgramDD_DeleteTrg");
                    tb.HasTrigger("CustomQuestionProgramDD_Insert");
                    tb.HasTrigger("CustomQuestionProgramDD_Update");
                });

            entity.Property(e => e.CustomQuestionProgramDdkey).HasColumnName("CustomQuestionProgramDDKey");
            entity.Property(e => e.AssociatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DropdownText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.CustomQuestionProgramKeyNavigation).WithMany(p => p.CustomQuestionProgramDds)
                .HasForeignKey(d => d.CustomQuestionProgramKey)
                .HasConstraintName("FK_CustomQuestionProgramDD_CustomQuestionProgram");
        });

        modelBuilder.Entity<CustomReportTemplate>(entity =>
        {
            entity.HasKey(e => e.CustomReportTemplateKey);

            entity.ToTable("CustomReportTemplate");

            entity.Property(e => e.FieldList).HasColumnType("text");
            entity.Property(e => e.TemplateName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TemplateType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DailyBarcodeTicket>(entity =>
        {
            entity.HasKey(e => e.DailyBarcodeTicketKey);

            entity.ToTable("DailyBarcodeTicket");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CountyResideIn)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DailyBarcode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IssuedAt).HasColumnType("datetime");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PosproductLabel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSProductLabel");
            entity.Property(e => e.PostransactionKey).HasColumnName("POSTransactionKey");
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SourceOfPurchase)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasComment("Online, POS");
            entity.Property(e => e.UsedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<DiscountCode>(entity =>
        {
            entity.HasKey(e => e.DiscountCodeKey);

            entity.ToTable("DiscountCode");

            entity.Property(e => e.DiscountCode1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("DiscountCode");
            entity.Property(e => e.DiscountCodeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountCodeDesc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DiscountCodePercentage).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DiscountCodeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DiscountEndDate).HasColumnType("datetime");
            entity.Property(e => e.DiscountStartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictKey);

            entity.ToTable("District");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DistrictStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Districts)
                .HasForeignKey(d => d.OrganizationKey)
                .HasConstraintName("FK_District_Organization");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeKey);

            entity.ToTable("DocumentType");

            entity.HasIndex(e => new { e.OrganizationKey, e.DocumentTypeStatus }, "IX_DocumentType_OrganizationKey_Status");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.AppliesTo)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.DocumentType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DocumentType");
            entity.Property(e => e.DocumentTypeDesc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DocumentTypeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.DonationKey).IsClustered(false);

            entity.ToTable("Donation");

            entity.HasIndex(e => e.ContributorEmail, "idxContributorEmail");

            entity.HasIndex(e => e.DonationItemKey, "idxDonationItemKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey").IsClustered();

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ContributorAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContributorCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContributorEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContributorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContributorPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContributorState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContributorZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationDate).HasColumnType("datetime");
            entity.Property(e => e.DonationPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.OrganizationComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.DonationItemKeyNavigation).WithMany(p => p.Donations)
                .HasForeignKey(d => d.DonationItemKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donation_DonationItem");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Donations)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Donation_Organization");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.Donations)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_Donation_Shift");
        });

        modelBuilder.Entity<DonationConfigure>(entity =>
        {
            entity.HasKey(e => e.DonationConfigureKey);

            entity.ToTable("DonationConfigure");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DonationDescription)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DonationPurpose)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DonationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NotifyEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.DonationConfigures)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonationConfigure_Organization");
        });

        modelBuilder.Entity<DonationItem>(entity =>
        {
            entity.HasKey(e => e.DonationItemKey);

            entity.ToTable("DonationItem");

            entity.HasIndex(e => e.DonationConfigureKey, "idxDonationConfigureKey");

            entity.HasIndex(e => e.DonationItemKey, "idxDonationItemKey");

            entity.Property(e => e.AmountType)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.DonationItem1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DonationItem");
            entity.Property(e => e.DonationItemAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonationItemDesc)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DonationItemStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.DonationConfigureKeyNavigation).WithMany(p => p.DonationItems)
                .HasForeignKey(d => d.DonationConfigureKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonationItem_DonationConfigure");
        });

        modelBuilder.Entity<DonationItemDropdown>(entity =>
        {
            entity.HasKey(e => e.DonationItemDropdownKey);

            entity.ToTable("DonationItemDropdown");

            entity.HasIndex(e => e.DonationItemKey, "idxDonationItemKey");

            entity.Property(e => e.DonationDropdownText).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.DonationItemKeyNavigation).WithMany(p => p.DonationItemDropdowns)
                .HasForeignKey(d => d.DonationItemKey)
                .HasConstraintName("FK_DonationItemDropdown_DonationItem");
        });

        modelBuilder.Entity<EmailBounceLog>(entity =>
        {
            entity.HasKey(e => e.EmailBounceLogKey);

            entity.ToTable("EmailBounceLog");

            entity.HasIndex(e => new { e.OrganizationKey, e.BounceEmailAddress }, "idxOrgEmailAddr").IsUnique();

            entity.Property(e => e.BounceEmailAddress)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.BounceMessage).IsUnicode(false);
            entity.Property(e => e.BounceType)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.EmailData).HasColumnType("text");
            entity.Property(e => e.FullBounceReason).HasColumnType("text");
            entity.Property(e => e.SendgridVerified).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmailDistributionList>(entity =>
        {
            entity.HasKey(e => e.EmailDistributionListKey);

            entity.ToTable("EmailDistributionList");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DistributionListName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DistributionListStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<EmailDistributionListDetail>(entity =>
        {
            entity.HasKey(e => e.EmailDistributionListDetailKey);

            entity.ToTable("EmailDistributionListDetail");

            entity.HasIndex(e => e.EmailDistributionListKey, "idxDistributionListKey");

            entity.HasIndex(e => new { e.EmailDistributionListKey, e.DistributionEmailAddr }, "idxKeyAndEmail");

            entity.Property(e => e.DistributionEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameOfIndividual)
                .HasMaxLength(81)
                .IsUnicode(false);

            entity.HasOne(d => d.EmailDistributionListKeyNavigation).WithMany(p => p.EmailDistributionListDetails)
                .HasForeignKey(d => d.EmailDistributionListKey)
                .HasConstraintName("FK_EmailDistributionListDetail_EmailDistributionList");
        });

        modelBuilder.Entity<EmailOptOut>(entity =>
        {
            entity.HasKey(e => e.EmailOptOutKey);

            entity.ToTable("EmailOptOut", tb =>
                {
                    tb.HasTrigger("EmailOptOut_DeleteTrg");
                    tb.HasTrigger("EmailOptOut_InsertTrg");
                    tb.HasTrigger("EmailOptOut_UpdateTrg");
                });

            entity.HasIndex(e => new { e.OrganizationKey, e.EmailAddress }, "idxOrgEmail");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OptOutDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmailSentLog>(entity =>
        {
            entity.HasKey(e => e.EmailSentLogKey);

            entity.ToTable("EmailSentLog");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.Archived)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Attachment1Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Attachment2Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateSent).HasColumnType("datetime");
            entity.Property(e => e.EmailBody).HasColumnType("ntext");
            entity.Property(e => e.EmailSendStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmailSubject)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReplyToEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ScreenSentFrom)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SendGridJson)
                .HasColumnType("text")
                .HasColumnName("SendGridJSON");
            entity.Property(e => e.SendInBackground)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SentBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfSend)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmailSentLogDetail>(entity =>
        {
            entity.HasKey(e => e.EmailSentLogDetailKey);

            entity.ToTable("EmailSentLogDetail");

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => new { e.EmailSentLogKey, e.EmailAddressSent }, "idxEmailSentKeyAddress");

            entity.Property(e => e.AttachmentName1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BadEmailReason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddressSent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailContent).HasColumnType("ntext");
            entity.Property(e => e.EmailOrigin)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EmailStatus)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ScdateSent)
                .HasColumnType("datetime")
                .HasColumnName("SCDateSent");
            entity.Property(e => e.SendGridDateSent).HasColumnType("datetime");
        });

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.HasKey(e => e.EmailTemplateKey);

            entity.ToTable("EmailTemplate");

            entity.HasIndex(e => new { e.OrganizationKey, e.EmailTemplateName }, "idxOrgAndName");

            entity.HasIndex(e => new { e.OrganizationKey, e.TemplateType }, "idxOrgAndType");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.EmailTemplateName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SystemTemplate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TemplateType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.EmailTemplates)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmailTemplate_Organization");
        });

        modelBuilder.Entity<ErrorException>(entity =>
        {
            entity.HasKey(e => e.ErrorExceptionKey).HasName("PK_AppException");

            entity.ToTable("ErrorException");

            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.ErrorMessage).HasColumnType("text");
            entity.Property(e => e.ErrorThrown).HasColumnType("text");
            entity.Property(e => e.Httpstatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HTTPStatus");
            entity.Property(e => e.PageName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StackTrace).HasColumnType("text");
            entity.Property(e => e.StatusText).HasColumnType("text");
            entity.Property(e => e.UserAgent).HasColumnType("text");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ErrorExceptionDetail>(entity =>
        {
            entity.HasKey(e => e.ErrorExceptionDetailKey);

            entity.ToTable("ErrorExceptionDetail");

            entity.HasIndex(e => e.ErrorExceptionKey, "idxErrorExceptionKey");

            entity.Property(e => e.FieldName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FieldValue)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ErrorExceptionKeyNavigation).WithMany(p => p.ErrorExceptionDetails)
                .HasForeignKey(d => d.ErrorExceptionKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ErrorExceptionDetail_ErrorException");
        });

        modelBuilder.Entity<ErrorExceptionDetailNew>(entity =>
        {
            entity.HasKey(e => e.ErrorExceptionDetailNewKey);

            entity.ToTable("ErrorExceptionDetailNew");

            entity.Property(e => e.FieldName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FieldValue)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ErrorExceptionNewKeyNavigation).WithMany(p => p.ErrorExceptionDetailNews)
                .HasForeignKey(d => d.ErrorExceptionNewKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ErrorExceptionDetailNew_ErrorExceptionNew");
        });

        modelBuilder.Entity<ErrorExceptionNew>(entity =>
        {
            entity.HasKey(e => e.ErrorExceptionNewKey);

            entity.ToTable("ErrorExceptionNew");

            entity.Property(e => e.Browser)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");
            entity.Property(e => e.ErrorMessage).HasColumnType("text");
            entity.Property(e => e.ErrorThrown).HasColumnType("text");
            entity.Property(e => e.ErrorType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OperatingSystem)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PageName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ResponseData).HasColumnType("text");
            entity.Property(e => e.ResponseText).HasColumnType("text");
            entity.Property(e => e.StatusText).HasColumnType("text");
            entity.Property(e => e.UserAgent).HasColumnType("text");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ErrorFeedback>(entity =>
        {
            entity.HasKey(e => e.AppErrorFeedbackKey).HasName("PK_AppErrorFeedback");

            entity.ToTable("ErrorFeedback");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.ErrorDetails).HasColumnType("text");
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FacilityAvailableHour>(entity =>
        {
            entity.HasKey(e => e.FacilityAvailableHoursKey);

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("FacilityAvailableHours_DeleteTrg");
                    tb.HasTrigger("FacilityAvailableHours_InsertTrg");
                    tb.HasTrigger("FacilityAvailableHours_UpdateTrg");
                });

            entity.HasIndex(e => e.FacilitySpaceKey, "idxFacilitySpaceKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.FridayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FridayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LightFeeStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MondayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MondayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SaturdayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SaturdayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SundayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.SundayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ThursdayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ThursdayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TuesdayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TuesdayStart)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.WednesdayEnd)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.WednesdayStart)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.FacilityAvailableHours)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .HasConstraintName("FK_FacilityAvailableHours_FacilitySpace");
        });

        modelBuilder.Entity<FacilityCategory>(entity =>
        {
            entity.HasKey(e => e.FacilityCategoryKey);

            entity.ToTable("FacilityCategory");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.FacilityCategoryName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FacilityCategoryStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<FacilityChildAssociation>(entity =>
        {
            entity.HasKey(e => e.FacilityChildAssociationKey).HasName("PK_FacilitySpaceBlock");

            entity.ToTable("FacilityChildAssociation");
        });

        modelBuilder.Entity<FacilityComplex>(entity =>
        {
            entity.HasKey(e => e.FacilityComplexKey);

            entity.ToTable("FacilityComplex");

            entity.HasIndex(e => e.CityKey, "idxCityKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.ComplexAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ComplexName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ComplexState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ComplexStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ComplexZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DirectionsToComplex).IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MapLink).IsUnicode(false);
        });

        modelBuilder.Entity<FacilityOtherFee>(entity =>
        {
            entity.HasKey(e => e.FacilityOtherFeeKey);

            entity.ToTable("FacilityOtherFee", tb =>
                {
                    tb.HasTrigger("FacilityOtherFee_DeleteTrg");
                    tb.HasTrigger("FacilityOtherFee_InsertTrg");
                    tb.HasTrigger("FacilityOtherFee_UpdateTrg");
                });

            entity.Property(e => e.FlatOrHourly)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OptionalOrRequired)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.OtherFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OtherFeeDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OtherFeeDescriptionText)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.OtherFeeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TimeFeeStarts)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.FacilityOtherFees)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .HasConstraintName("FK_FacilityOtherFee_FacilitySpace");
        });

        modelBuilder.Entity<FacilityRate>(entity =>
        {
            entity.HasKey(e => e.FacilityRatesKey);

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("FacilityRates_DeleteTrg");
                    tb.HasTrigger("FacilityRates_InsertTrg");
                    tb.HasTrigger("FacilityRates_UpdateTrg");
                });

            entity.HasIndex(e => e.FacilitySpaceKey, "idxFacilitySpaceKey");

            entity.Property(e => e.AdditionalPerHour).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AlcoholAgreement).IsUnicode(false);
            entity.Property(e => e.DailyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DailyRateNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DailyRateNonprofit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EndDateToReserve).HasColumnType("datetime");
            entity.Property(e => e.FullDayRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FullDayRateNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FullDayRateNonprofit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HalfDayRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HalfDayRateNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HalfDayRateNonprofit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HourlyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HourlyRateNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HourlyRateNonprofit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MaximumDaysInAdvance).HasComment("Maximum number of days between booking and actual reservation.");
            entity.Property(e => e.MaximumWithTablesChairs).HasColumnName("MaximumWIthTablesChairs");
            entity.Property(e => e.NoAlcoholAgreement).IsUnicode(false);
            entity.Property(e => e.RentalAgreement).IsUnicode(false);
            entity.Property(e => e.ReservationDaysInAdvance).HasComment("Minimum days between booking and actual reservation. For example, if 2, you could not reserve the day before.");
            entity.Property(e => e.SecurityDeposit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositAlcohol).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositAlcoholNon).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositNonResident).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StartDateToReserve).HasColumnType("datetime");

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.FacilityRates)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityRates_FacilitySpace");
        });

        modelBuilder.Entity<FacilityRatesFlat>(entity =>
        {
            entity.HasKey(e => e.FacilityRatesFlatKey);

            entity.ToTable("FacilityRatesFlat");

            entity.Property(e => e.FlatRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FlatRateDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FlatRateStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FacilityReservation>(entity =>
        {
            entity.HasKey(e => e.FacilityReservationKey);

            entity.ToTable("FacilityReservation", tb =>
                {
                    tb.HasTrigger("FacilityReservation_DeleteTrg");
                    tb.HasTrigger("FacilityReservation_InsertTrg");
                    tb.HasTrigger("FacilityReservation_UpdateTrg");
                });

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.PrepCleanupTimeKey, "idxPrepCleanupTime");

            entity.HasIndex(e => e.ReservationStatus, "idxReservationStatus");

            entity.HasIndex(e => e.ReservationType, "idxReservationType");

            entity.HasIndex(e => e.StartTimeOfEvent, "idxStartTimeOfEvent");

            entity.HasIndex(e => e.TeamKey, "idxTeamKey");

            entity.HasIndex(e => e.FacilitySpaceKey, "idx_facilityspace");

            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AlcoholAgreement).IsUnicode(false);
            entity.Property(e => e.ApplicantAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicantEmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicantZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateOfReservation).HasColumnType("datetime");
            entity.Property(e => e.EndTimeOfEvent).HasColumnType("datetime");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HeldDepositInformation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MembershipDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NoAlcoholAgreement).IsUnicode(false);
            entity.Property(e => e.PurposeOfUse)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.RentalAgreement).IsUnicode(false);
            entity.Property(e => e.ReservationAdjustment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReservationComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ReservationFeeCharged).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReservationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReservationType)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.ResidentNon)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RoomConfiguration)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositCharged).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositKeptReason)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SecurityDepositReturnAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDepositReturnDate).HasColumnType("datetime");
            entity.Property(e => e.StartTimeOfEvent).HasColumnType("datetime");
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalOptionalFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalRequiredFee).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.FacilityReservations)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityReservation_FacilitySpace");
        });

        modelBuilder.Entity<FacilityReservationOtherFee>(entity =>
        {
            entity.HasKey(e => e.FacilityReservationOtherFeesKey);

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("FacilityReservationOtherFees_DeleteTrg");
                    tb.HasTrigger("FacilityReservationOtherFees_InsertTrg");
                    tb.HasTrigger("FacilityReservationOtherFees_UpdateTrg");
                });

            entity.HasIndex(e => e.FacilityReservationKey, "idxFacilityReservationKey");

            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OptionalOrRequiredStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OtherFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TimeFeeStarts)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilityOtherFeeKeyNavigation).WithMany(p => p.FacilityReservationOtherFees)
                .HasForeignKey(d => d.FacilityOtherFeeKey)
                .HasConstraintName("FK_FacilityReservationOtherFees_FacilityOtherFee");

            entity.HasOne(d => d.FacilityReservationKeyNavigation).WithMany(p => p.FacilityReservationOtherFees)
                .HasForeignKey(d => d.FacilityReservationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityReservationOtherFees_FacilityReservation");
        });

        modelBuilder.Entity<FacilityShare>(entity =>
        {
            entity.HasKey(e => e.FacilityShareKey);

            entity.ToTable("FacilityShare");

            entity.HasIndex(e => e.MainOrganization, "idxMainOrganization");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ShareStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.FacilityShares)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityShare_FacilitySpace1");

            entity.HasOne(d => d.MainOrganizationNavigation).WithMany(p => p.FacilityShareMainOrganizationNavigations)
                .HasForeignKey(d => d.MainOrganization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityShare_Organization1");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.FacilityShareOrganizationKeyNavigations)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityShare_Organization");
        });

        modelBuilder.Entity<FacilityShareGroupMember>(entity =>
        {
            entity.HasKey(e => e.FacilityShareGroupMemberKey);

            entity.ToTable("FacilityShareGroupMember");

            entity.HasOne(d => d.FacilityShareGroupKeyNavigation).WithMany(p => p.FacilityShareGroupMembers)
                .HasForeignKey(d => d.FacilityShareGroupKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityShareGroupMember_FacilityShareGroup");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.FacilityShareGroupMembers)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityShareGroupMember_Organization");
        });

        modelBuilder.Entity<FacilityShareGroupMemberCategory>(entity =>
        {
            entity.HasKey(e => e.FacilityShareGroupMemberCategoryKey);

            entity.ToTable("FacilityShareGroupMemberCategory");

            entity.Property(e => e.ActivityCategory)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilityShareGroupMemberKeyNavigation).WithMany(p => p.FacilityShareGroupMemberCategories)
                .HasForeignKey(d => d.FacilityShareGroupMemberKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityShareGroupMemberCategory_FacilityShareGroupMember");
        });

        modelBuilder.Entity<FacilitySpace>(entity =>
        {
            entity.HasKey(e => e.FacilitySpaceKey);

            entity.ToTable("FacilitySpace", tb =>
                {
                    tb.HasTrigger("FacilitySpace_DeleteTrg");
                    tb.HasTrigger("FacilitySpace_InsertTrg");
                    tb.HasTrigger("FacilitySpace_UpdateTrg");
                });

            entity.HasIndex(e => e.CityKey, "idxCityKey");

            entity.HasIndex(e => e.FacilityCategoryKey, "idxFacilityCategoryKey");

            entity.HasIndex(e => e.FacilityComplexKey, "idxFacilityComplexKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.XRentalFacility, "idxRental");

            entity.HasIndex(e => e.RevenueCode, "idxRevenueCode");

            entity.Property(e => e.ActiveInactive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("(A)ctive or (I)nactive. Inactive will not show up as a choice");
            entity.Property(e => e.AllowToReserveOnline).HasComment("Could allow online reservation with no rates attached. Just have to reserve to use.");
            entity.Property(e => e.DepositRevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DirectionsToFacility).IsUnicode(false);
            entity.Property(e => e.FacilityAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FacilityName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FacilityState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FacilityStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("(O)pen or (C)losed. This is only used for games/practices when closing/opening for weather or other issues where facility is temporarily unavailable");
            entity.Property(e => e.FacilityZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MapLink)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.XRentalFacility)
                .HasComment("Should have rates attached.")
                .HasColumnName("xRentalFacility");
        });

        modelBuilder.Entity<FacilityTieredRate>(entity =>
        {
            entity.HasKey(e => e.FacilityTieredRatesKey);

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("FacilityTieredRates_DeleteTrg");
                    tb.HasTrigger("FacilityTieredRates_Insert");
                    tb.HasTrigger("FacilityTieredRates_Update");
                });

            entity.HasIndex(e => e.FacilitySpaceKey, "idxFacilitySpaceKey");

            entity.Property(e => e.AdditionalFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FacilityTieredRatesStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.FacilityTieredRates)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityTieredRates_FacilitySpace");
        });

        modelBuilder.Entity<FacilityToCustomQuestion>(entity =>
        {
            entity.HasKey(e => e.FacilityToCustomQuestionKey);

            entity.ToTable("FacilityToCustomQuestion", tb =>
                {
                    tb.HasTrigger("FacilityToCustomQuestion_DeleteTrg");
                    tb.HasTrigger("FacilityToCustomQuestion_InsertTrg");
                    tb.HasTrigger("FacilityToCustomQuestion_UpdateTrg");
                });

            entity.Property(e => e.Answer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilityReservationKeyNavigation).WithMany(p => p.FacilityToCustomQuestions)
                .HasForeignKey(d => d.FacilityReservationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityToCustomQuestion_FacilityReservation");
        });

        modelBuilder.Entity<FacilityToSport>(entity =>
        {
            entity.HasKey(e => e.FacilityToSportKey);

            entity.ToTable("FacilityToSport");

            entity.HasIndex(e => e.ActivityCategoryKey, "idxActivityCategoryKey");

            entity.HasIndex(e => e.FacilitySpaceKey, "idxFacilitySpaceKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasOne(d => d.ActivityCategoryKeyNavigation).WithMany(p => p.FacilityToSports)
                .HasForeignKey(d => d.ActivityCategoryKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityToSport_ActivityCategory");

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.FacilityToSports)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .HasConstraintName("FK_FacilityToSport_FacilitySpace");
        });

        modelBuilder.Entity<GrantFunding>(entity =>
        {
            entity.HasKey(e => e.GrantFundingKey);

            entity.ToTable("GrantFunding");

            entity.HasIndex(e => e.RegistrantToLeagueKey, "idxRegistrantToLeague").IsUnique();

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GradeLevel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Hispanic)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HouseholdIncome)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HouseholdMakeup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Housing)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.RacialBackground)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GrantFundingPending>(entity =>
        {
            entity.HasKey(e => e.GrantFundingPendingKey);

            entity.ToTable("GrantFundingPending");

            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GradeLevel)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Hispanic)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HouseholdIncome)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HouseholdMakeup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Housing)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.RacialBackground)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.HolidayKey);

            entity.ToTable("Holiday");

            entity.Property(e => e.HolidayDate).HasColumnType("datetime");
            entity.Property(e => e.HolidayName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorKey);

            entity.ToTable("Instructor");

            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.InstructorAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InstructorCity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.InstructorClasses)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InstructorContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstructorEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InstructorEpassword)
                .HasMaxLength(25)
                .HasColumnName("InstructorEPassword");
            entity.Property(e => e.InstructorFlatRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InstructorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InstructorNotes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.InstructorPercentage).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.InstructorSt)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstructorStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InstructorZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ServiceAgreementExpiration).HasColumnType("datetime");
            entity.Property(e => e.ServiceAgreementFileName)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.VerificationCodeDate).HasColumnType("datetime");
            entity.Property(e => e.XServiceAgreementPdf).HasColumnName("xServiceAgreementPDF");
        });

        modelBuilder.Entity<InvalidCredentialsLog>(entity =>
        {
            entity.ToTable("InvalidCredentialsLog");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.InvalidCredentialsLogId).HasColumnName("InvalidCredentialsLogID");
            entity.Property(e => e.FailureReason)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LoginAttemptDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.InventoryItemKey);

            entity.ToTable("InventoryItem");

            entity.Property(e => e.CostOfItem).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ImageFileName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.InventoryItemCategory)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.InventoryItemColor)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.InventoryItemDesc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.InventoryItemName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.InventoryItemSize)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.InventoryItemStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PreferredVendor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.InventoryItemSizeNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.InventoryItemSize)
                .HasConstraintName("FK_InventoryItem_InventoryItemSize");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryItem_Organization");
        });

        modelBuilder.Entity<InventoryItemSize>(entity =>
        {
            entity.HasKey(e => e.InventoryItemSizeDesc);

            entity.ToTable("InventoryItemSize");

            entity.Property(e => e.InventoryItemSizeDesc)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InvoiceHistory>(entity =>
        {
            entity.HasKey(e => e.InvoiceHistoryKey);

            entity.ToTable("InvoiceHistory");

            entity.Property(e => e.BalanceDue).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DateInvoiceSent).HasColumnType("datetime");
            entity.Property(e => e.InvoiceSentBy)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JarvisAdminUser>(entity =>
        {
            entity.HasKey(e => e.JarvisAdminUserKey).HasName("PK_UserLoginMgmt");

            entity.ToTable("JarvisAdminUser");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.UserFullName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
        });

        modelBuilder.Entity<JerseySize>(entity =>
        {
            entity.HasKey(e => e.JerseySizeKey);

            entity.ToTable("JerseySize");

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.Property(e => e.JerseySize1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("JerseySize");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.JerseySizes)
                .HasForeignKey(d => d.SeasonKey)
                .HasConstraintName("FK_JerseySize_Season");
        });

        modelBuilder.Entity<League>(entity =>
        {
            entity.HasKey(e => e.LeagueKey);

            entity.ToTable("League", tb =>
                {
                    tb.HasTrigger("League_DeleteTrg");
                    tb.HasTrigger("League_Insert");
                    tb.HasTrigger("League_Update");
                });

            entity.HasIndex(e => e.FacilitySpaceKey, "idxFacilitySpaceKey");

            entity.HasIndex(e => e.InstructorKey, "idxInstructorKey");

            entity.HasIndex(e => new { e.SeasonKey, e.LeagueStatus }, "idx_SeasonKey");

            entity.Property(e => e.ActivityDateTimeInfo)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.BirthDateHigh).HasColumnType("datetime");
            entity.Property(e => e.BirthDateLow).HasColumnType("datetime");
            entity.Property(e => e.EarlyBirdAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EarlyBirdBasedOn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EarlyBirdDate).HasColumnType("datetime");
            entity.Property(e => e.GenderRestriction)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LateRegAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LateRegStart).HasColumnType("datetime");
            entity.Property(e => e.LateRegistrationBasedOn)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LeagueName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LeagueStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocationInformation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MilitaryDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinimumDeposit).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MinimumDepositPct).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NonmemberFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PlayerFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationSessionEnd).HasColumnType("datetime");
            entity.Property(e => e.RegistrationSessionStart).HasColumnType("datetime");
            entity.Property(e => e.TeamFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ValidateEligibility)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.InstructorKeyNavigation).WithMany(p => p.Leagues)
                .HasForeignKey(d => d.InstructorKey)
                .HasConstraintName("FK_League_Instructor");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.Leagues)
                .HasForeignKey(d => d.SeasonKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_League_Season1");
        });

        modelBuilder.Entity<LeagueSchedulerDateException>(entity =>
        {
            entity.HasKey(e => e.LeagueSchedulerDateExceptionKey);

            entity.ToTable("LeagueSchedulerDateException");

            entity.HasIndex(e => e.LeagueKey, "idxLeagueKey");

            entity.Property(e => e.GameDateException).HasColumnType("datetime");
        });

        modelBuilder.Entity<LeagueSchedulerFacility>(entity =>
        {
            entity.HasKey(e => e.LeagueSchedulerFacilityKey);

            entity.ToTable("LeagueSchedulerFacility");

            entity.HasIndex(e => e.LeagueSchedulerParmsKey, "idxLeagueSchedulerParmsKey");
        });

        modelBuilder.Entity<LeagueSchedulerParm>(entity =>
        {
            entity.HasKey(e => e.LeagueSchedulerParmsKey);

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.EndDateOfSchedule).HasColumnType("datetime");
            entity.Property(e => e.StartDateOfSchedule).HasColumnType("datetime");
        });

        modelBuilder.Entity<LeagueSchedulerTeamMatchup>(entity =>
        {
            entity.HasKey(e => e.TeamMatchupKey).HasName("PK_LSTeamMatchups");

            entity.ToTable("LeagueSchedulerTeamMatchup");

            entity.Property(e => e.TypeOfMatchup)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Locker>(entity =>
        {
            entity.HasKey(e => e.LockerKey).HasName("PK_Locker1");

            entity.ToTable("Locker");

            entity.Property(e => e.LockerStatus)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.HasOne(d => d.LockerRangeKeyNavigation).WithMany(p => p.Lockers)
                .HasForeignKey(d => d.LockerRangeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locker_LockerRange");

            entity.HasOne(d => d.LockerTypeKeyNavigation).WithMany(p => p.Lockers)
                .HasForeignKey(d => d.LockerTypeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locker_LockerType");
        });

        modelBuilder.Entity<LockerRange>(entity =>
        {
            entity.HasKey(e => e.LockerRangeKey).HasName("pk_locker_range");

            entity.ToTable("LockerRange");

            entity.HasOne(d => d.LockerTypeKeyNavigation).WithMany(p => p.LockerRanges)
                .HasForeignKey(d => d.LockerTypeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LockerRange_LockerType");
        });

        modelBuilder.Entity<LockerRental>(entity =>
        {
            entity.HasKey(e => e.LockerRentalKey);

            entity.ToTable("LockerRental");

            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepositAmountPaid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepositAmountReturned).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepositWithheldReason)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IdonFile).HasColumnName("IDOnFile");
            entity.Property(e => e.Idreturned).HasColumnName("IDReturned");
            entity.Property(e => e.RateApplied).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RentalEndDateTime).HasColumnType("datetime");
            entity.Property(e => e.RentalNotes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RentalStartDateTime).HasColumnType("datetime");
            entity.Property(e => e.RenterFirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RenterLastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RenterPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.LockerKeyNavigation).WithMany(p => p.LockerRentals)
                .HasForeignKey(d => d.LockerKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LockerRental_Locker");
        });

        modelBuilder.Entity<LockerType>(entity =>
        {
            entity.HasKey(e => e.LockerTypeKey).HasName("pk_locker_type");

            entity.ToTable("LockerType");

            entity.Property(e => e.DepositAmount).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.LockerTypeName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LockerTypeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RentalRate).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MedicalRelease>(entity =>
        {
            entity.HasKey(e => e.MedicalReleaseKey);

            entity.ToTable("MedicalRelease");

            entity.HasIndex(e => e.RegistrantKey, "idxRegistrantKey");

            entity.Property(e => e.AlternatePhone1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AlternatePhone2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.DateOfLastTetanusBooster).HasColumnType("datetime");
            entity.Property(e => e.Dosage1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Dosage2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Dosage3)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Dosage4)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact1Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact1Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmergencyContact1Relationship)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact2Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContact2Phone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmergencyContact2Relationship)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FamilyPhysician)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FrequencyOfDosage1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FrequencyOfDosage2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FrequencyOfDosage3)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FrequencyOfDosage4)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.GroupId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.HospitalPreference)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastVerified).HasColumnType("datetime");
            entity.Property(e => e.LeagueGroupId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LeagueInsuranceCo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LeaguePolicyNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MedicalDiagnosis1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MedicalDiagnosis2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MedicalDiagnosis3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MedicalDiagnosis4)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Medication1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Medication2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Medication3)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Medication4)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParentGuardian1Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParentGuardian1Relationship)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ParentGuardian2Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParentGuardian2Relationship)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ParentInsuranceCo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhysicianAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhysicianCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhysicianPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PhysicianState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PlayersAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlayersCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PlayersState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PlayersZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipKey);

            entity.ToTable("Membership", tb =>
                {
                    tb.HasTrigger("Membership_DeleteTrg");
                    tb.HasTrigger("Membership_Insert");
                    tb.HasTrigger("Membership_Update");
                });

            entity.HasIndex(e => e.MemberEmailAddr, "idxMemberEmailAddr");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.MemberLastName, "idx_memberlastname");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MemberAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberAlternatePhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberBirthDate).HasColumnType("datetime");
            entity.Property(e => e.MemberCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MemberEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberFirstName)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.MemberLastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MemberPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberZipcode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyBankDraft)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MonthlyBankDraftCancelBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MonthlyBankDraftCancelDate).HasColumnType("datetime");
            entity.Property(e => e.MonthlyBankDraftStartDate).HasColumnType("datetime");
            entity.Property(e => e.PlaceOfEmployment)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentAddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentAddedDate).HasColumnType("datetime");
            entity.Property(e => e.RecurringPaymentCancelBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentCancelDate).HasColumnType("datetime");
            entity.Property(e => e.RecurringPaymentLastFour).HasMaxLength(25);
            entity.Property(e => e.RecurringPaymentRegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RecurringPaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.MxVaultedCustomerId).HasColumnName("MXVaultedCustomerId");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Memberships)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Membership_Organization");
        });

        modelBuilder.Entity<MembershipAddlPerson>(entity =>
        {
            entity.HasKey(e => e.MembershipAddlPersonKey);

            entity.ToTable("MembershipAddlPerson");

            entity.HasIndex(e => e.MembershipKey, "idxMembershipKey");

            entity.Property(e => e.AddlPersonBirthDate).HasColumnType("datetime");
            entity.Property(e => e.AddlPersonFirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.AddlPersonLastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AddlPersonStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RelationshipToMember)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.MembershipKeyNavigation).WithMany(p => p.MembershipAddlPeople)
                .HasForeignKey(d => d.MembershipKey)
                .HasConstraintName("FK_MembershipAddlPerson_Membership");
        });

        modelBuilder.Entity<MembershipCategory>(entity =>
        {
            entity.HasKey(e => e.MembershipCategoryKey);

            entity.ToTable("MembershipCategory");

            entity.Property(e => e.MembershipCategory1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MembershipCategory");
        });

        modelBuilder.Entity<MembershipCheckin>(entity =>
        {
            entity.HasKey(e => e.MembershipCheckInKey);

            entity.ToTable("MembershipCheckin");

            entity.Property(e => e.CheckinDateTime).HasColumnType("datetime");
            entity.Property(e => e.CheckinSource)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Manual or Scan");
            entity.Property(e => e.MemberName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MembershipDetail>(entity =>
        {
            entity.HasKey(e => e.MembershipDetailKey);

            entity.ToTable("MembershipDetail", tb =>
                {
                    tb.HasTrigger("MembershipDetail_DeleteTrg");
                    tb.HasTrigger("MembershipDetail_Insert");
                    tb.HasTrigger("MembershipDetail_Update");
                });

            entity.HasIndex(e => e.MembershipKey, "idxMembershipKey");

            entity.HasIndex(e => e.MembershipTypeKey, "idxMembershipTypeKey");

            entity.Property(e => e.AddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AddlPersonCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountReason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DraftReconcileDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LostCardCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipEndDate).HasColumnType("datetime");
            entity.Property(e => e.MembershipStartDate).HasColumnType("datetime");
            entity.Property(e => e.NsffeeTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFeeTotal");
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MembershipKeyNavigation).WithMany(p => p.MembershipDetails)
                .HasForeignKey(d => d.MembershipKey)
                .HasConstraintName("FK_MembershipDetail_Membership");

            entity.HasOne(d => d.MembershipTypeKeyNavigation).WithMany(p => p.MembershipDetails)
                .HasForeignKey(d => d.MembershipTypeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MembershipDetail_MembershipType");
        });

        modelBuilder.Entity<MembershipId>(entity =>
        {
            entity.HasKey(e => e.MembershipIdKey);

            entity.ToTable("MembershipId", tb =>
                {
                    tb.HasTrigger("MembershipId_DeleteTrg");
                    tb.HasTrigger("MembershipId_Insert");
                    tb.HasTrigger("MembershipId_Update");
                });

            entity.HasIndex(e => e.MembershipKey, "idxMembershipKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.MembershipId1, "idx_membershipid");

            entity.Property(e => e.BarcodeNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MembershipId1).HasColumnName("MembershipId");
            entity.Property(e => e.MembershipIdStatus)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.MembershipKeyNavigation).WithMany(p => p.MembershipIds)
                .HasForeignKey(d => d.MembershipKey)
                .HasConstraintName("FK_MembershipId_Membership");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.MembershipIds)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MembershipId_Organization");
        });

        modelBuilder.Entity<MembershipImport>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MembershipImport");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("CITY");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Expire).HasColumnName("EXPIRE");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.MembershipAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipType)
                .HasMaxLength(100)
                .HasColumnName("MEMBERSHIP_TYPE");
            entity.Property(e => e.PassIdNumber).HasColumnName("PASS_ID_NUMBER");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("PHONE");
            entity.Property(e => e.PhoneFormatted).HasMaxLength(50);
            entity.Property(e => e.St)
                .HasMaxLength(50)
                .HasColumnName("ST");
            entity.Property(e => e.Start).HasColumnName("START");
            entity.Property(e => e.Zip).HasColumnName("ZIP");
        });

        modelBuilder.Entity<MembershipNote>(entity =>
        {
            entity.HasKey(e => e.MembershipNotesKey);

            entity.HasIndex(e => e.MembershipKey, "idxMembershipKey");

            entity.Property(e => e.MembershipNote1)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("MembershipNote");
            entity.Property(e => e.MembershipNoteDate).HasColumnType("datetime");
            entity.Property(e => e.MembershipNoteStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NoteAddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MembershipPreference>(entity =>
        {
            entity.HasKey(e => e.MembershipPreferencesKey);

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.BarcodedCardCreation)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Jarvis or ThirdParty");
            entity.Property(e => e.FacilityReservationDiscountPct).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LostCardCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasComment("Jarvis-Assigned the MembershipKey by Jarvis, Manual-entered manually, Pool-obtain from pool of numbers");
            entity.Property(e => e.MembershipIdAssignment)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.MembershipSalesTax).HasColumnType("decimal(18, 4)");
        });

        modelBuilder.Entity<MembershipScanErrorLog>(entity =>
        {
            entity.HasKey(e => e.MembershipScanErrorLogKey).HasName("PK__Membersh__D623E7CAFDDBE2C1");

            entity.ToTable("MembershipScanErrorLog");

            entity.Property(e => e.BarcodeData).HasMaxLength(50);
            entity.Property(e => e.ErrorTime).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(45)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Source).HasMaxLength(100);
        });

        modelBuilder.Entity<MembershipScanLog>(entity =>
        {
            entity.HasKey(e => e.MembershipScanLogKey).HasName("PK__Membersh__89321871050F4C82");

            entity.ToTable("MembershipScanLog");

            entity.Property(e => e.BarcodeData).HasMaxLength(50);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(45)
                .HasColumnName("IPAddress");
            entity.Property(e => e.ScanTime).HasColumnType("datetime");
            entity.Property(e => e.UserAgent).HasMaxLength(500);

            entity.HasOne(d => d.MembershipKeyNavigation).WithMany(p => p.MembershipScanLogs)
                .HasForeignKey(d => d.MembershipKey)
                .HasConstraintName("FK__Membershi__Membe__2F2E9728");
        });

        modelBuilder.Entity<MembershipType>(entity =>
        {
            entity.HasKey(e => e.MembershipTypeKey);

            entity.ToTable("MembershipType");

            entity.HasIndex(e => e.MembershipTypeDescKey, "idxMembershipTypeDescKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.AddlPersonPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipPeriod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MembershipTypeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MembershipTypeDescKeyNavigation).WithMany(p => p.MembershipTypes)
                .HasForeignKey(d => d.MembershipTypeDescKey)
                .HasConstraintName("FK_MembershipType_MembershipTypeDescription");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.MembershipTypes)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MembershipType_Organization");
        });

        modelBuilder.Entity<MembershipTypeDescription>(entity =>
        {
            entity.HasKey(e => e.MembershipTypeDescKey);

            entity.ToTable("MembershipTypeDescription");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.MembershipTypeDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MembershipTypeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.MembershipTypeDescriptions)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MembershipTypeDescription_Organization");
        });

        modelBuilder.Entity<MembershipVisit>(entity =>
        {
            entity.HasKey(e => e.MembershipVisitKey);

            entity.ToTable("MembershipVisit");

            entity.Property(e => e.VisitDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<MxmerchantBatch>(entity =>
        {
            entity.HasKey(e => e.MxmerchantBatchKey);

            entity.ToTable("MXMerchantBatch");

            entity.HasIndex(e => new { e.OrganizationKey, e.BatchOpenDate, e.BatchNumber }, "idxOrgBatchDateEMV").IsUnique();

            entity.Property(e => e.MxmerchantBatchKey).HasColumnName("MXMerchantBatchKey");
            entity.Property(e => e.BatchCloseDate).HasColumnType("datetime");
            entity.Property(e => e.BatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BatchOpenDate).HasColumnType("datetime");
            entity.Property(e => e.DiscrepancyComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Emvterminal).HasColumnName("EMVTerminal");
            entity.Property(e => e.JarvisAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MxmerchantAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("MXMerchantAmount");
        });

        modelBuilder.Entity<MxmerchantBatchTxn>(entity =>
        {
            entity.HasKey(e => e.MxmerchantBatchTxnKey);

            entity.ToTable("MXMerchantBatchTxn");

            entity.Property(e => e.MxmerchantBatchTxnKey).HasColumnName("MXMerchantBatchTxnKey");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Authcode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Batch)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CreatedByDevice)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OriginalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SettleDate).HasColumnType("datetime");
            entity.Property(e => e.SettledAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SettledSource)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OnlineSession>(entity =>
        {
            entity.HasKey(e => e.OnlineSessionId).HasName("PK_RegistrationSession");

            entity.ToTable("OnlineSession", tb =>
                {
                    tb.HasTrigger("OnlineSession_DeleteTrg");
                    tb.HasTrigger("OnlineSession_InsertTrg");
                    tb.HasTrigger("OnlineSession_UpdateTrg");
                });

            entity.Property(e => e.OnlineSessionId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.DateSessionAdded).HasColumnType("datetime");
            entity.Property(e => e.NameForLookup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SessionType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.WebsiteDomainName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.OnlineSessions)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrationSession_Organization");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrganizationKey).HasName("PK_OrganizationKey");

            entity.ToTable("Organization", tb =>
                {
                    tb.HasTrigger("Organization_DeleteTrg");
                    tb.HasTrigger("Organization_Insert");
                    tb.HasTrigger("Organization_Update");
                });

            entity.HasIndex(e => e.OrganizationName, "idxOrganizationName").IsUnique();

            entity.Property(e => e.AccountCreditRevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ActivityPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AfterhoursPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AllowAmex).HasColumnName("AllowAMEX");
            entity.Property(e => e.AllowDisc).HasColumnName("AllowDISC");
            entity.Property(e => e.BackgroundCheckUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("BackgroundCheckURL");
            entity.Property(e => e.BatchCashChecks).HasComment("if you feed cash/checks and do not batch cash/checks, then payment is sent to Govt Portal to create import file to Tyler or Caselle");
            entity.Property(e => e.ContactEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DailyPercentage).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DocumentPath)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DomainName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EditorCssfile)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EditorCSSFile");
            entity.Property(e => e.EmvappId)
                .HasMaxLength(75)
                .HasColumnName("EMVAppId");
            entity.Property(e => e.FacilityAlcoholAgreement).HasColumnType("text");
            entity.Property(e => e.FacilityRentalAgreement).HasColumnType("text");
            entity.Property(e => e.FacilitySalesTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.FeeScheduleFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FeeStructure)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FeedCashChecks).HasComment("if you feed cash/checks and do not batch cash/checks, then payment is sent to Govt Portal to create import file to Tyler or Caselle");
            entity.Property(e => e.FromEmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FromEmailPw)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FromEmailPW");
            entity.Property(e => e.GatewayUsed)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GlorRevenueCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("GLOrRevenueCode");
            entity.Property(e => e.ImageEditorPath)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JarvisComments).HasColumnType("text");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LeagueMgmtPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipFlatOrPercent)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.MembershipFlatRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MembershipPctRate).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MerchantAcctKey).HasMaxLength(75);
            entity.Property(e => e.MerchantAcctNbr).HasMaxLength(75);
            entity.Property(e => e.MerchantPctToRegistrant).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.MerchantSecretKey).HasMaxLength(75);
            entity.Property(e => e.MinimumConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MonthlyBilledAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NameForLookup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NameOfAcceptor)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OnlineFacilityApproval).HasComment("This is set for organizations that have online facility reservations that do not first require approval, but they want to be aware of them and approve them after the reservation has been made and/or paid for.");
            entity.Property(e => e.OnlinePracticeApproval).HasComment("Set for organizations that have online practice requests from their website and these requests need to be approved.");
            entity.Property(e => e.OrganizationAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationCity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationSt)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.OrganizationZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PaymentFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PlayerTermsAndConditions).HasColumnType("text");
            entity.Property(e => e.PossalesTax)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("POSSalesTax");
            entity.Property(e => e.PosscreenName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("POSScreenName");
            entity.Property(e => e.RegistrationSalesTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ReportEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReportPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SeasonPassSalesTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.ServiceAgreementFile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShiftLocationType)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("Singe or Multiple");
            entity.Property(e => e.StandingsType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SwipePctToRegistrant).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TaxId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TeamPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UseEmvterminal).HasColumnName("UseEMVTerminal");
            entity.Property(e => e.UserNameAcceptAgreement)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrganizationAssociation>(entity =>
        {
            entity.HasKey(e => e.OrganizationAssociationKey);

            entity.ToTable("OrganizationAssociation", tb => tb.HasComment("Allows Jarvis customers to share fields with each other. Used for game management and notifications between cities."));

            entity.HasIndex(e => e.AssociatedOrganization, "idxAssociated");

            entity.HasIndex(e => e.MainOrganization, "idxMain");

            entity.Property(e => e.OrganizationAssociationKey).HasComment("Unique identifier");
            entity.Property(e => e.AssociatedOrganization).HasComment("This is the organization the main organization is sharing the field with. This organization cannot make any changes to the facility configuration. They can only view it's schedule and use it for scheduling.");
            entity.Property(e => e.MainOrganization).HasComment("This is the organization that owns the fields. They control the field configuration and field status (open/closed).");
            entity.Property(e => e.NotifyEmail1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("An email of someone from the associated organization that wishes to be notified if the field status changes.");
            entity.Property(e => e.NotifyEmail2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("An email of someone from the associated organization that wishes to be notified if the field status changes.");
            entity.Property(e => e.NotifyEmail3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("An email of someone from the associated organization that wishes to be notified if the field status changes.");
            entity.Property(e => e.NotifyText1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("The cell phone number of someone from the associated organization that wishes to be notified if the field status changes. They will receive a text to this number.");
            entity.Property(e => e.NotifyText2)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("The cell phone number of someone from the associated organization that wishes to be notified if the field status changes. They will receive a text to this number.");
            entity.Property(e => e.NotifyText3)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("The cell phone number of someone from the associated organization that wishes to be notified if the field status changes. They will receive a text to this number.");
            entity.Property(e => e.ReplyToEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("when one organization sending emails on behalf of the other, who do the reply emails go to?");

            entity.HasOne(d => d.AssociatedOrganizationNavigation).WithMany(p => p.OrganizationAssociationAssociatedOrganizationNavigations)
                .HasForeignKey(d => d.AssociatedOrganization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAssociation_Organization3");

            entity.HasOne(d => d.MainOrganizationNavigation).WithMany(p => p.OrganizationAssociationMainOrganizationNavigations)
                .HasForeignKey(d => d.MainOrganization)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationAssociation_Organization2");
        });

        modelBuilder.Entity<OrganizationHoliday>(entity =>
        {
            entity.HasKey(e => e.OrganizationHolidayKey);

            entity.ToTable("OrganizationHoliday");

            entity.HasIndex(e => new { e.OrganizationKey, e.HolidayKey }, "idxOrgHolidayKey").IsUnique();

            entity.HasOne(d => d.HolidayKeyNavigation).WithMany(p => p.OrganizationHolidays)
                .HasForeignKey(d => d.HolidayKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrganizationHoliday_Holiday");
        });

        modelBuilder.Entity<PantShortSize>(entity =>
        {
            entity.HasKey(e => e.PantShortSizeKey);

            entity.ToTable("PantShortSize");

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.Property(e => e.PantShortSize1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PantShortSize");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.PantShortSizes)
                .HasForeignKey(d => d.SeasonKey)
                .HasConstraintName("FK_PantShortSize_Season");
        });

        modelBuilder.Entity<Park>(entity =>
        {
            entity.HasKey(e => e.ParkKey);

            entity.ToTable("Park");

            entity.HasIndex(e => e.XCityKey, "idxCityKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DescriptionOfPark).HasColumnType("text");
            entity.Property(e => e.DirectionsToPark).HasColumnType("text");
            entity.Property(e => e.ParkCity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ParkImageName).HasColumnType("text");
            entity.Property(e => e.ParkImageNameLg).HasColumnType("text");
            entity.Property(e => e.ParkMapLink).HasColumnType("text");
            entity.Property(e => e.ParkName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ParkStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.XCityKey).HasColumnName("xCityKey");
            entity.Property(e => e.XParkSt)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("xParkSt");
            entity.Property(e => e.XParkZipcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("xParkZipcode");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Parks)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Park_Organization");

            entity.HasOne(d => d.XCityKeyNavigation).WithMany(p => p.Parks)
                .HasForeignKey(d => d.XCityKey)
                .HasConstraintName("FK_Park_City");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentKey);

            entity.ToTable("Payment", tb =>
                {
                    tb.HasTrigger("Payment_DeleteTrg");
                    tb.HasTrigger("Payment_Insert");
                    tb.HasTrigger("Payment_Update");
                });

            entity.HasIndex(e => e.MerchantBatchId, "idxMerchantBatchId");

            entity.HasIndex(e => e.RegistrantToLeagueKey, "idxRegistrantToLeagueKey");

            entity.HasIndex(e => e.RegistrationNbr, "idxRegistrationNbr");

            entity.HasIndex(e => e.ShiftKey, "idxShiftKey");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckCityStZip)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValorTxnId)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_Payment_Shift");
        });

        modelBuilder.Entity<PaymentFacility>(entity =>
        {
            entity.HasKey(e => e.PaymentFacilityKey);

            entity.ToTable("PaymentFacility", tb =>
                {
                    tb.HasTrigger("PaymentFacility_DeleteTrg");
                    tb.HasTrigger("PaymentFacility_Insert");
                    tb.HasTrigger("PaymentFacility_Update");
                });

            entity.HasIndex(e => e.FacilityReservationKey, "idxFacilityReservationKey");

            entity.HasIndex(e => e.MerchantBatchId, "idxMerchantBatchId");

            entity.HasIndex(e => e.RegistrationNbr, "idxRegistrationNbr");

            entity.HasIndex(e => e.ShiftKey, "idxShiftKey");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValorTxnId)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilityReservationKeyNavigation).WithMany(p => p.PaymentFacilities)
                .HasForeignKey(d => d.FacilityReservationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentFacility_FacilityReservation");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentFacilities)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentFacility_Shift");
        });

        modelBuilder.Entity<PaymentInstructor>(entity =>
        {
            entity.HasKey(e => e.PaymentInstructorKey);

            entity.ToTable("PaymentInstructor");

            entity.Property(e => e.CashReceiptNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments).HasColumnType("text");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PaymentLockerRental>(entity =>
        {
            entity.HasKey(e => e.PaymentLockerRentalKey);

            entity.ToTable("PaymentLockerRental");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckCityStZip)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValorTxnId)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.LockerRentalKeyNavigation).WithMany(p => p.PaymentLockerRentals)
                .HasForeignKey(d => d.LockerRentalKey)
                .HasConstraintName("FK_PaymentLockerRental_LockerRental");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentLockerRentals)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentLockerRental_Shift");
        });

        modelBuilder.Entity<PaymentLockerRentalRefundAllocation>(entity =>
        {
            entity.HasKey(e => new { e.RefundPaymentKey, e.OriginalPaymentKey });

            entity.ToTable("PaymentLockerRentalRefundAllocation");

            entity.Property(e => e.AmountRefunded).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ConvenienceFeeRefunded).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OriginalPaymentKeyNavigation).WithMany(p => p.PaymentLockerRentalRefundAllocationOriginalPaymentKeyNavigations)
                .HasForeignKey(d => d.OriginalPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentLockerRentalRefundAllocation_Original");

            entity.HasOne(d => d.RefundPaymentKeyNavigation).WithMany(p => p.PaymentLockerRentalRefundAllocationRefundPaymentKeyNavigations)
                .HasForeignKey(d => d.RefundPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentLockerRentalRefundAllocation_Refund");
        });

        modelBuilder.Entity<PaymentMembership>(entity =>
        {
            entity.HasKey(e => e.PaymentMembershipKey);

            entity.ToTable("PaymentMembership", tb =>
                {
                    tb.HasTrigger("PaymentMembership_DeleteTrg");
                    tb.HasTrigger("PaymentMembership_Insert");
                    tb.HasTrigger("PaymentMembership_Update");
                });

            entity.HasIndex(e => e.MembershipDetailKey, "idxMembershipDetailKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.RegistrationNbr, "idxRegistrationNbr");

            entity.HasIndex(e => e.ShiftKey, "idxShiftKey");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentNotes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MembershipDetailKeyNavigation).WithMany(p => p.PaymentMemberships)
                .HasForeignKey(d => d.MembershipDetailKey)
                .HasConstraintName("FK_PaymentMembership_MembershipDetail");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentMemberships)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentMembership_Shift");
        });

        modelBuilder.Entity<PaymentMembershipRefundAllocation>(entity =>
        {
            entity.HasKey(e => new { e.RefundPaymentKey, e.OriginalPaymentKey });

            entity.ToTable("PaymentMembershipRefundAllocation");

            entity.Property(e => e.AmountRefunded).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ConvenienceFeeRefunded).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OriginalPaymentKeyNavigation).WithMany(p => p.PaymentMembershipRefundAllocationOriginalPaymentKeyNavigations)
                .HasForeignKey(d => d.OriginalPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentMembershipRefundAllocation_Original");

            entity.HasOne(d => d.RefundPaymentKeyNavigation).WithMany(p => p.PaymentMembershipRefundAllocationRefundPaymentKeyNavigations)
                .HasForeignKey(d => d.RefundPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentMembershipRefundAllocation_Refund");
        });

        modelBuilder.Entity<PaymentMerchandise>(entity =>
        {
            entity.HasKey(e => e.PaymentMerchandiseKey);

            entity.ToTable("PaymentMerchandise");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.ChargedTo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InventoryItemColor)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.InventoryItemName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.InventoryItemSize)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments).HasColumnType("text");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.PaymentMerchandises)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentMerchandise_Organization");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentMerchandises)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentMerchandise_Shift");
        });

        modelBuilder.Entity<PaymentPo>(entity =>
        {
            entity.HasKey(e => e.PaymentPoskey);

            entity.ToTable("PaymentPOS", tb =>
                {
                    tb.HasTrigger("PaymentPOS_DeleteTrg");
                    tb.HasTrigger("PaymentPOS_Insert");
                    tb.HasTrigger("PaymentPOS_Update");
                });

            entity.HasIndex(e => new { e.RegistrationNbr, e.ConfirmationNbr }, "idxConfirmationNbrs");

            entity.HasIndex(e => e.Poskey, "idxPOSKey");

            entity.Property(e => e.PaymentPoskey).HasColumnName("PaymentPOSKey");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Poskey).HasColumnName("POSKey");
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesTax).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PoskeyNavigation).WithMany(p => p.PaymentPos)
                .HasForeignKey(d => d.Poskey)
                .HasConstraintName("FK_PaymentPOS_POS");
        });

        modelBuilder.Entity<PaymentRefundAllocation>(entity =>
        {
            entity.HasKey(e => new { e.RefundPaymentKey, e.OriginalPaymentKey });

            entity.ToTable("PaymentRefundAllocation");

            entity.Property(e => e.AmountRefunded).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ConvenienceFeeRefunded).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OriginalPaymentKeyNavigation).WithMany(p => p.PaymentRefundAllocationOriginalPaymentKeyNavigations)
                .HasForeignKey(d => d.OriginalPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentRefundAllocation_Original");

            entity.HasOne(d => d.RefundPaymentKeyNavigation).WithMany(p => p.PaymentRefundAllocationRefundPaymentKeyNavigations)
                .HasForeignKey(d => d.RefundPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentRefundAllocation_Refund");
        });

        modelBuilder.Entity<PaymentSeasonPass>(entity =>
        {
            entity.HasKey(e => e.PaymentSeasonPassKey);

            entity.ToTable("PaymentSeasonPass");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckCityStZip)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefundCheckName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("reference field from processor");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.SeasonPassKeyNavigation).WithMany(p => p.PaymentSeasonPasses)
                .HasForeignKey(d => d.SeasonPassKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentSeasonPass_SeasonPass");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentSeasonPasses)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentSeasonPass_Shift");
        });

        modelBuilder.Entity<PaymentSeasonPassRefundAllocation>(entity =>
        {
            entity.HasKey(e => new { e.RefundPaymentKey, e.OriginalPaymentKey });

            entity.ToTable("PaymentSeasonPassRefundAllocation");

            entity.Property(e => e.AmountRefunded).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ConvenienceFeeRefunded).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OriginalPaymentKeyNavigation).WithMany(p => p.PaymentSeasonPassRefundAllocationOriginalPaymentKeyNavigations)
                .HasForeignKey(d => d.OriginalPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentSeasonPassRefundAllocation_Original");

            entity.HasOne(d => d.RefundPaymentKeyNavigation).WithMany(p => p.PaymentSeasonPassRefundAllocationRefundPaymentKeyNavigations)
                .HasForeignKey(d => d.RefundPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentSeasonPassRefundAllocation_Refund");
        });

        modelBuilder.Entity<PaymentSpecialEvent>(entity =>
        {
            entity.HasKey(e => e.PaymentSpecialEventKey);

            entity.ToTable("PaymentSpecialEvent", tb =>
                {
                    tb.HasTrigger("PaymentSpecialEvent_DeleteTrg");
                    tb.HasTrigger("PaymentSpecialEvent_InsertTrg");
                    tb.HasTrigger("PaymentSpecialEvent_UpdateTrg");
                });

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentSpecialEvents)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentSpecialEvent_Shift");

            entity.HasOne(d => d.SpecialEventKeyNavigation).WithMany(p => p.PaymentSpecialEvents)
                .HasForeignKey(d => d.SpecialEventKey)
                .HasConstraintName("FK_PaymentSpecialEvent_SpecialEvent");
        });

        modelBuilder.Entity<PaymentSponsor>(entity =>
        {
            // sponsor pledge multi-payment redesign (2026-10): payment rows only; the pledge is
            // SponsorPledgeDetail. Audit triggers added 2026-10-24 (Audit_PaymentSponsor) - EF
            // must know about them or SaveChanges fails on this table.
            entity.HasKey(e => e.PaymentSponsorKey);

            entity.ToTable("PaymentSponsor", tb =>
                {
                    tb.HasTrigger("PaymentSponsor_DeleteTrg");
                    tb.HasTrigger("PaymentSponsor_InsertTrg");
                    tb.HasTrigger("PaymentSponsor_UpdateTrg");
                });

            entity.HasIndex(e => e.SponsorPledgeDetailKey, "IX_PaymentSponsor_SponsorPledgeDetailKey");

            entity.HasIndex(e => new { e.OrganizationKey, e.PaymentDate }, "IX_PaymentSponsor_OrganizationKey_PaymentDate");

            entity.HasIndex(e => e.ShiftKey, "IX_PaymentSponsor_ShiftKey");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentNotes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValorTxnId)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.SponsorPledgeDetailKeyNavigation).WithMany(p => p.PaymentSponsors)
                .HasForeignKey(d => d.SponsorPledgeDetailKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentSponsor_SponsorPledgeDetail");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.PaymentSponsors)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentSponsor_Organization");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentSponsors)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentSponsor_Shift");
        });

        modelBuilder.Entity<SponsorPledgeDetail>(entity =>
        {
            entity.HasKey(e => e.SponsorPledgeDetailKey);

            entity.ToTable("SponsorPledgeDetail", tb =>
                {
                    tb.HasTrigger("SponsorPledgeDetail_DeleteTrg");
                    tb.HasTrigger("SponsorPledgeDetail_InsertTrg");
                    tb.HasTrigger("SponsorPledgeDetail_UpdateTrg");
                });

            entity.HasIndex(e => e.SponsorKey, "IX_SponsorPledgeDetail_SponsorKey");

            entity.HasIndex(e => new { e.OrganizationKey, e.SponsorshipAdded }, "IX_SponsorPledgeDetail_OrganizationKey");

            entity.Property(e => e.AddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChildsAgeGroup)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FirstChoiceUniformColor)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PersonSponsoring)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SecondChoiceUniformColor)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SponsorAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SponsorshipAdded).HasColumnType("datetime");
            entity.Property(e => e.SponsorshipExpiration).HasColumnType("datetime");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.SponsorPledgeDetails)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SponsorPledgeDetail_Organization");

            entity.HasOne(d => d.SponsorKeyNavigation).WithMany(p => p.SponsorPledgeDetails)
                .HasForeignKey(d => d.SponsorKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SponsorPledgeDetail_Sponsor");

            entity.HasOne(d => d.SponsorPledgeTypeKeyNavigation).WithMany(p => p.SponsorPledgeDetails)
                .HasForeignKey(d => d.SponsorPledgeTypeKey)
                .HasConstraintName("FK_SponsorPledgeDetail_SponsorPledgeType");
        });

        modelBuilder.Entity<PaymentTeam>(entity =>
        {
            entity.HasKey(e => e.PaymentTeamKey);

            entity.ToTable("PaymentTeam");

            entity.HasIndex(e => e.MerchantBatchId, "idxMerchantBatchId");

            entity.HasIndex(e => e.RegistrationNbr, "idxRegistrationNbr");

            entity.HasIndex(e => e.ShiftKey, "idxShiftKey");

            entity.HasIndex(e => e.TeamKey, "idxTeamKey");

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentTeams)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentTeam_Shift");

            entity.HasOne(d => d.TeamKeyNavigation).WithMany(p => p.PaymentTeams)
                .HasForeignKey(d => d.TeamKey)
                .HasConstraintName("FK_PaymentTeam_Team");
        });

        modelBuilder.Entity<PaymentTourRefundAllocation>(entity =>
        {
            entity.HasKey(e => new { e.RefundPaymentKey, e.OriginalPaymentKey });

            entity.ToTable("PaymentTourRefundAllocation");

            entity.Property(e => e.AmountRefunded).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OriginalPaymentKeyNavigation).WithMany(p => p.PaymentTourRefundAllocationOriginalPaymentKeyNavigations)
                .HasForeignKey(d => d.OriginalPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentTourRefundAllocation_Original");

            entity.HasOne(d => d.RefundPaymentKeyNavigation).WithMany(p => p.PaymentTourRefundAllocationRefundPaymentKeyNavigations)
                .HasForeignKey(d => d.RefundPaymentKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentTourRefundAllocation_Refund");
        });

        modelBuilder.Entity<PaymentTourRegistration>(entity =>
        {
            entity.HasKey(e => e.PaymentTourRegistrationKey);

            entity.ToTable("PaymentTourRegistration");

            entity.Property(e => e.CardAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CardCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CardFirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CardLastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CardState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CardZipCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesTax).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.TourRegistrationKeyNavigation).WithMany(p => p.PaymentTourRegistrations)
                .HasForeignKey(d => d.TourRegistrationKey)
                .HasConstraintName("FK_PaymentTourRegistration_TourRegistration");
        });

        modelBuilder.Entity<PaymentVendor>(entity =>
        {
            entity.HasKey(e => e.PaymentVendorKey).IsClustered(false);

            entity.ToTable("PaymentVendor");

            entity.HasIndex(e => new { e.RegistrationNbr, e.ConfirmationNbr }, "idxConfirmationNbrs");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey").IsClustered();

            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(25)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(25)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.ChargeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateOfCharge).HasColumnType("datetime");
            entity.Property(e => e.DateOfRefund).HasColumnType("datetime");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentNotes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RefundAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RefundInformation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RefundNotes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.RefundPaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RefundedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VendorNotes)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PaymentVendors)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_PaymentVendor_Shift");

            entity.HasOne(d => d.VendorKeyNavigation).WithMany(p => p.PaymentVendors)
                .HasForeignKey(d => d.VendorKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentVendor_Vendor");
        });

        modelBuilder.Entity<Po>(entity =>
        {
            entity.HasKey(e => e.Poskey);

            entity.ToTable("POS");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.Poskey).HasColumnName("POSKey");
            entity.Property(e => e.ChargedTo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateTimeEntered).HasColumnType("datetime");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PoscategoryKey).HasColumnName("POSCategoryKey");
            entity.Property(e => e.PositemKey).HasColumnName("POSItemKey");
            entity.Property(e => e.PriceEach).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SalesTax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalNsf)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalNSF");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PoscategoryKeyNavigation).WithMany(p => p.Pos)
                .HasForeignKey(d => d.PoscategoryKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POS_POSCategory");

            entity.HasOne(d => d.PositemKeyNavigation).WithMany(p => p.Pos)
                .HasForeignKey(d => d.PositemKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POS_POSItem");
        });

        modelBuilder.Entity<Poscategory>(entity =>
        {
            entity.HasKey(e => e.PoscategoryKey);

            entity.ToTable("POSCategory");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.PoscategoryKey).HasColumnName("POSCategoryKey");
            entity.Property(e => e.ButtonColor)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CategoryStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Posinventory>(entity =>
        {
            entity.HasKey(e => e.PosinventoryKey);

            entity.ToTable("POSInventory");

            entity.Property(e => e.PosinventoryKey).HasColumnName("POSInventoryKey");
            entity.Property(e => e.PoslocationKey).HasColumnName("POSLocationKey");
            entity.Property(e => e.PosproductKey).HasColumnName("POSProductKey");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.PoslocationKeyNavigation).WithMany(p => p.Posinventories)
                .HasForeignKey(d => d.PoslocationKey)
                .HasConstraintName("FK_POSInventory_POSLocation");

            entity.HasOne(d => d.PosproductKeyNavigation).WithMany(p => p.Posinventories)
                .HasForeignKey(d => d.PosproductKey)
                .HasConstraintName("FK_POSInventory_POSProduct");
        });

        modelBuilder.Entity<PosinventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.PosinventoryTransactionKey);

            entity.ToTable("POSInventoryTransaction");

            entity.Property(e => e.PosinventoryTransactionKey).HasColumnName("POSInventoryTransactionKey");
            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PosinventoryKey).HasColumnName("POSInventoryKey");
            entity.Property(e => e.PoslocationKey).HasColumnName("POSLocationKey");
            entity.Property(e => e.PosproductKey).HasColumnName("POSProductKey");
            entity.Property(e => e.StaffNotes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransactionType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Receive, Sale, Adjustment");

            entity.HasOne(d => d.PosinventoryKeyNavigation).WithMany(p => p.PosinventoryTransactions)
                .HasForeignKey(d => d.PosinventoryKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POSInventoryTransaction_POSInventory");

            entity.HasOne(d => d.PoslocationKeyNavigation).WithMany(p => p.PosinventoryTransactions)
                .HasForeignKey(d => d.PoslocationKey)
                .HasConstraintName("FK_POSInventoryTransaction_POSLocation");

            entity.HasOne(d => d.PosproductKeyNavigation).WithMany(p => p.PosinventoryTransactions)
                .HasForeignKey(d => d.PosproductKey)
                .HasConstraintName("FK_POSInventoryTransaction_POSProduct");
        });

        modelBuilder.Entity<Positem>(entity =>
        {
            entity.HasKey(e => e.PositemKey);

            entity.ToTable("POSItem");

            entity.Property(e => e.PositemKey).HasColumnName("POSItemKey");
            entity.Property(e => e.ItemButtonColor)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ItemStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PoscategoryKey).HasColumnName("POSCategoryKey");
            entity.Property(e => e.PoswaiverForm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSWaiverForm");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.PoscategoryKeyNavigation).WithMany(p => p.Positems)
                .HasForeignKey(d => d.PoscategoryKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POSItem_POSCategory");
        });

        modelBuilder.Entity<Poslocation>(entity =>
        {
            entity.HasKey(e => e.PoslocationKey);

            entity.ToTable("POSLocation");

            entity.Property(e => e.PoslocationKey).HasColumnName("POSLocationKey");
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PoslocationTypeKey)
                .HasComment("Concession, Retail, Recreation, Admissions, Maintenance, Storage")
                .HasColumnName("POSLocationTypeKey");

            entity.HasOne(d => d.PoslocationTypeKeyNavigation).WithMany(p => p.Poslocations)
                .HasForeignKey(d => d.PoslocationTypeKey)
                .HasConstraintName("FK_POSLocation_POSLocationType");
        });

        modelBuilder.Entity<PoslocationType>(entity =>
        {
            entity.HasKey(e => e.PoslocationTypeKey);

            entity.ToTable("POSLocationType");

            entity.Property(e => e.PoslocationTypeKey).HasColumnName("POSLocationTypeKey");
            entity.Property(e => e.PoslocationTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSLocationTypeName");
        });

        modelBuilder.Entity<Pospreference>(entity =>
        {
            entity.HasKey(e => e.PospreferenceKey);

            entity.ToTable("POSPreference");

            entity.Property(e => e.PospreferenceKey).HasColumnName("POSPreferenceKey");
            entity.Property(e => e.TakeEmv).HasColumnName("TakeEMV");
        });

        modelBuilder.Entity<Posproduct>(entity =>
        {
            entity.HasKey(e => e.PosproductKey);

            entity.ToTable("POSProduct");

            entity.Property(e => e.PosproductKey).HasColumnName("POSProductKey");
            entity.Property(e => e.DefaultPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PosproductCategoryKey).HasColumnName("POSProductCategoryKey");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.PosproductCategoryKeyNavigation).WithMany(p => p.Posproducts)
                .HasForeignKey(d => d.PosproductCategoryKey)
                .HasConstraintName("FK_POSProduct_POSProductCategory");
        });

        modelBuilder.Entity<PosproductCategory>(entity =>
        {
            entity.HasKey(e => e.PosproductCategoryKey).HasName("PK_POSProductCategoryKey");

            entity.ToTable("POSProductCategory");

            entity.Property(e => e.PosproductCategoryKey).HasColumnName("POSProductCategoryKey");
            entity.Property(e => e.ButtonColor)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ProductCategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductCategoryStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Postransaction>(entity =>
        {
            entity.HasKey(e => e.PostransactionKey).HasName("PK_POSTransactions");

            entity.ToTable("POSTransaction");

            entity.Property(e => e.PostransactionKey).HasColumnName("POSTransactionKey");
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateTimeEntered).HasColumnType("datetime");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EnteredByUser)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PoslocationKey).HasColumnName("POSLocationKey");
            entity.Property(e => e.RefundReason)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SubtotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalTaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.XOriginalTransactionId).HasColumnName("xOriginalTransactionId");
        });

        modelBuilder.Entity<PostransactionItem>(entity =>
        {
            entity.HasKey(e => e.TransactionItemId).HasName("PK_POSTransactionItems");

            entity.ToTable("POSTransactionItem");

            entity.Property(e => e.ConvenienceFeeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateTimeAdded).HasColumnType("datetime");
            entity.Property(e => e.ItemDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PositemKey).HasColumnName("POSItemKey");
            entity.Property(e => e.PosproductKey).HasColumnName("POSProductKey");
            entity.Property(e => e.PostransactionKey).HasColumnName("POSTransactionKey");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SubtotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PositemKeyNavigation).WithMany(p => p.PostransactionItems)
                .HasForeignKey(d => d.PositemKey)
                .HasConstraintName("FK_POSTransactionItem_POSItem");

            entity.HasOne(d => d.PosproductKeyNavigation).WithMany(p => p.PostransactionItems)
                .HasForeignKey(d => d.PosproductKey)
                .HasConstraintName("FK_POSTransactionItem_POSProduct");

            entity.HasOne(d => d.PostransactionKeyNavigation).WithMany(p => p.PostransactionItems)
                .HasForeignKey(d => d.PostransactionKey)
                .HasConstraintName("FK_POSTransactionItem_POSTransaction");
        });

        modelBuilder.Entity<PostransactionPayment>(entity =>
        {
            entity.HasKey(e => e.PostransactionPaymentKey).HasName("PK_POSTransactionPayments");

            entity.ToTable("POSTransactionPayment");

            entity.Property(e => e.PostransactionPaymentKey).HasColumnName("POSTransactionPaymentKey");
            entity.Property(e => e.Ccexpiration)
                .HasMaxLength(50)
                .HasColumnName("CCExpiration");
            entity.Property(e => e.CclastFour)
                .HasMaxLength(50)
                .HasColumnName("CCLastFour");
            entity.Property(e => e.CheckNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConfirmationNbr)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MerchantBatchId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Nsfcheck)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("NSFCheck");
            entity.Property(e => e.Nsffee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFFee");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentId)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentNotes)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PaymentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaymentToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PostransactionKey).HasColumnName("POSTransactionKey");
            entity.Property(e => e.RegistrationNbr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValorTxnId)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.PostransactionKeyNavigation).WithMany(p => p.PostransactionPayments)
                .HasForeignKey(d => d.PostransactionKey)
                .HasConstraintName("FK_POSTransactionPayments_Transaction");

            entity.HasOne(d => d.ShiftKeyNavigation).WithMany(p => p.PostransactionPayments)
                .HasForeignKey(d => d.ShiftKey)
                .HasConstraintName("FK_POSTransactionPayment_Shift");
        });

        modelBuilder.Entity<PostransactionRefundLine>(entity =>
        {
            entity.HasKey(e => e.RefundLineId);

            entity.ToTable("POSTransactionRefundLine");

            entity.HasIndex(e => new { e.PostransactionKey, e.TransactionItemId }, "IX_POSTransactionRefundLine_TxnItem");

            entity.Property(e => e.ConvenienceFeeRefunded).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateTimeEntered).HasColumnType("datetime");
            entity.Property(e => e.EnteredByUser).HasMaxLength(30);
            entity.Property(e => e.LineRefundTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PostransactionKey).HasColumnName("POSTransactionKey");
            entity.Property(e => e.SubtotalRefunded).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxRefunded).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.PostransactionKeyNavigation).WithMany(p => p.PostransactionRefundLines)
                .HasForeignKey(d => d.PostransactionKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POSTransactionRefundLine_POSTransaction");
        });

        modelBuilder.Entity<PostransactionWaiver>(entity =>
        {
            entity.HasKey(e => e.PostransactionWaiverKey).HasName("PK__POSTrans__C61B7E7B0AE367DF");

            entity.ToTable("POSTransactionWaiver");

            entity.Property(e => e.PostransactionWaiverKey).HasColumnName("POSTransactionWaiverKey");
            entity.Property(e => e.ElectronicSignature)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PostransactionKey).HasColumnName("POSTransactionKey");
            entity.Property(e => e.RequiredWaiverType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SignedByName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SignedDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<RecurringDebitAudit>(entity =>
        {
            entity.HasKey(e => e.RecurringDebitAuditKey);

            entity.ToTable("RecurringDebitAudit");

            entity.HasIndex(e => e.MainTableKey, "idxMainTableKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DateOfTransaction).HasColumnType("datetime");
            entity.Property(e => e.DebitAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RecurringDebitSource)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Resolution)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ResolutionBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ResolutionDate).HasColumnType("datetime");
            entity.Property(e => e.ResponseReasonDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Registrant>(entity =>
        {
            entity.HasKey(e => e.RegistrantKey);

            entity.ToTable("Registrant", tb =>
                {
                    tb.HasTrigger("Registrant_DeleteTrg");
                    tb.HasTrigger("Registrant_InsertTrg");
                    tb.HasTrigger("Registrant_UpdateTrg");
                });

            entity.HasIndex(e => e.AccountKey, "idx_AccountKey");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.DateEntered).HasColumnType("datetime");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.HospitalChoice)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MedicalConditions)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ParticipantPhysician)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PhysicianPhoneNbr)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegistrantStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SpecialNeeds)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.Registrants)
                .HasForeignKey(d => d.AccountKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registrant_Account");
        });

        modelBuilder.Entity<RegistrantAdditionalCost>(entity =>
        {
            entity.HasKey(e => e.RegistrantAdditionalCostKey);

            entity.ToTable("RegistrantAdditionalCost");

            entity.HasIndex(e => e.AdditionalCostKey, "idxAdditionalCostKey");

            entity.HasIndex(e => e.RegistrantToLeagueKey, "idxRegistrantToLeagueKey");

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.Property(e => e.ItemColor)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ItemSize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.AdditionalCostKeyNavigation).WithMany(p => p.RegistrantAdditionalCosts)
                .HasForeignKey(d => d.AdditionalCostKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantAdditionalCost_AdditionalCost");

            entity.HasOne(d => d.RegistrantToLeagueKeyNavigation).WithMany(p => p.RegistrantAdditionalCosts)
                .HasForeignKey(d => d.RegistrantToLeagueKey)
                .HasConstraintName("FK_RegistrantAdditionalCost_RegistrantToLeague");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.RegistrantAdditionalCosts)
                .HasForeignKey(d => d.SeasonKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantAdditionalCost_Season");
        });

        modelBuilder.Entity<RegistrantAdditionalCostPending>(entity =>
        {
            entity.HasKey(e => e.RegistrantAdditionalCostPendingKey);

            entity.ToTable("RegistrantAdditionalCostPending");

            entity.Property(e => e.AdjustmentFor)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ItemColor)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ItemSize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.RegistrantToLeaguePendingKeyNavigation).WithMany(p => p.RegistrantAdditionalCostPendings)
                .HasForeignKey(d => d.RegistrantToLeaguePendingKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantAdditionalCostPending_RegistrantToLeaguePending1");
        });

        modelBuilder.Entity<RegistrantCustomQuestion>(entity =>
        {
            entity.HasKey(e => e.RegistrantCustomQuestionKey);

            entity.ToTable("RegistrantCustomQuestion");

            entity.HasIndex(e => e.CustomQuestionProgramKey, "idxCustomQuestionProgramKey");

            entity.HasIndex(e => e.RegistrantToLeagueKey, "idxRegistrantToLeagueKey");

            entity.Property(e => e.Answer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AssociatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IndividualOrTeam)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.CustomQuestionProgramKeyNavigation).WithMany(p => p.RegistrantCustomQuestions)
                .HasForeignKey(d => d.CustomQuestionProgramKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantCustomQuestion_CustomQuestionProgram");
        });

        modelBuilder.Entity<RegistrantCustomQuestionPending>(entity =>
        {
            entity.HasKey(e => e.RegistrantCustomQuestionPendingKey).HasName("PK_RegistrantCustomQuestionPending_1");

            entity.ToTable("RegistrantCustomQuestionPending");

            entity.Property(e => e.Answer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AssociatedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IndividualOrTeam)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<RegistrantToLeague>(entity =>
        {
            entity.HasKey(e => e.RegistrantToLeagueKey).HasName("PK_RegistrantToLeague_1");

            entity.ToTable("RegistrantToLeague");

            entity.HasIndex(e => e.LeagueKey, "idxLeagueKey");

            entity.HasIndex(e => e.RegistrantKey, "idxRegistrantKey");

            entity.HasIndex(e => new { e.RegistrantKey, e.SeasonKey, e.LeagueKey }, "idxRegistrantSeasonLeague").IsUnique();

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.HasIndex(e => e.TeamKey, "idxTeamKey");

            entity.Property(e => e.AcceptTc).HasColumnName("AcceptTC");
            entity.Property(e => e.AddlCostItemTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApproximateHeight)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CoachName1)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.CoachName2)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.CoachType1)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.CoachType2)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EarlyBirdDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EquipReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.Grade)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.JerseySize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LateRegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Nsftotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("NSFTotal");
            entity.Property(e => e.PantShortSize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PreviousSeasonDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.RegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RemovedFromWaitlistDate).HasColumnType("datetime");
            entity.Property(e => e.RequestedCoach)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RequestedFriend)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RequestedTeam)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SchoolAttending)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.SiblingDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TotalInvoiceAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaidAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VolunteerCapacity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerCapacity2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerInterestEmailReminder).HasColumnType("datetime");
            entity.Property(e => e.VolunteerName1)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerName2)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.WaiverCoach)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.LeagueKeyNavigation).WithMany(p => p.RegistrantToLeagues)
                .HasForeignKey(d => d.LeagueKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantToLeague_League");

            entity.HasOne(d => d.RegistrantKeyNavigation).WithMany(p => p.RegistrantToLeagues)
                .HasForeignKey(d => d.RegistrantKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantToLeague_Registrant");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.RegistrantToLeagues)
                .HasForeignKey(d => d.SeasonKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantToLeague_Season");
        });

        modelBuilder.Entity<RegistrantToLeagueAdjustment>(entity =>
        {
            entity.HasKey(e => e.RegistrantToLeagueAdjustmentKey);

            entity.ToTable("RegistrantToLeagueAdjustment");

            entity.HasIndex(e => e.RegistrantToLeagueKey, "idxRegistrantToLeagueKey");

            entity.Property(e => e.AdjustmentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentDate).HasColumnType("datetime");
            entity.Property(e => e.AdjustmentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(300)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RegistrantToLeagueAdjustmentPending>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RegistrantToLeagueAdjustmentPending");

            entity.Property(e => e.AdjustmentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentDate).HasColumnType("datetime");
            entity.Property(e => e.AdjustmentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.RegistrantToLeagueAdjustmentPendingKey).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<RegistrantToLeagueDay>(entity =>
        {
            entity.HasKey(e => e.RegistrantToLeagueDayKey);

            entity.ToTable("RegistrantToLeagueDay");

            entity.HasIndex(e => new { e.RegistrantToLeagueKey, e.DayOfWeek }, "UX_RegistrantToLeagueDay_Registrant_DOW").IsUnique();

            entity.HasOne(d => d.RegistrantToLeagueKeyNavigation).WithMany(p => p.RegistrantToLeagueDays)
                .HasForeignKey(d => d.RegistrantToLeagueKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantToLeagueDay_RegistrantToLeague");
        });

        modelBuilder.Entity<RegistrantToLeagueDayPending>(entity =>
        {
            entity.HasKey(e => e.RegistrantToLeagueDayPendingKey);

            entity.ToTable("RegistrantToLeagueDayPending");

            entity.HasOne(d => d.RegistrantToLeaguePendingKeyNavigation).WithMany(p => p.RegistrantToLeagueDayPendings)
                .HasForeignKey(d => d.RegistrantToLeaguePendingKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrantToLeagueDayPending_RegistrantToLeaguePending");
        });

        modelBuilder.Entity<RegistrantToLeaguePending>(entity =>
        {
            entity.HasKey(e => e.RegistrantToLeaguePendingKey);

            entity.ToTable("RegistrantToLeaguePending");

            entity.Property(e => e.AcceptTc).HasColumnName("AcceptTC");
            entity.Property(e => e.AddlCostItemTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApproximateHeight)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CoachName1)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.CoachName2)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.CoachType1)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.CoachType2)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DiscountCodeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EarlyBirdDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Grade)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.JerseySize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LateRegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MilitaryDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PantShortSize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PreviousSeasonDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.RegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.RequestedCoach)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RequestedFriend)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RequestedTeam)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SchoolAttending)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.SiblingDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TotalInvoiceAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VolunteerCapacity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerCapacity2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerName1)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.VolunteerName2)
                .HasMaxLength(36)
                .IsUnicode(false);
            entity.Property(e => e.WaiverCoach)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResidentAddress>(entity =>
        {
            entity.HasKey(e => e.ResidentAddressKey);

            entity.ToTable("ResidentAddress");

            entity.HasIndex(e => new { e.OrganizationKey, e.ResidentAddress1 }, "idxOrgAddress");

            entity.Property(e => e.ResidentAddress1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ResidentAddress");
        });

        modelBuilder.Entity<ResidentZipCode>(entity =>
        {
            entity.HasKey(e => e.ResidentZipCodeKey);

            entity.ToTable("ResidentZipCode");

            entity.HasIndex(e => new { e.OrganizationKey, e.ResidentZipCode1 }, "idxOrgZip");

            entity.Property(e => e.ResidentZipCode1)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ResidentZipCode");
        });

        modelBuilder.Entity<RevenueCode>(entity =>
        {
            entity.HasKey(e => e.RevenueCodeKey);

            entity.ToTable("RevenueCode");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.RevenueCode1, "idxRevenueCode");

            entity.Property(e => e.BudgetCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Glaccount)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("GLAccount");
            entity.Property(e => e.RevenueCode1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RevenueCode");
            entity.Property(e => e.RevenueCodeDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCodeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.RevenueCodes)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RevenueCode_Organization");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleKey);

            entity.ToTable("Schedule");

            entity.HasIndex(e => e.FacilitySpaceKey, "idxFacilitySpaceKey");

            entity.HasIndex(e => e.GameStartTime, "idxGameStartTime");

            entity.HasIndex(e => e.HomeTeam, "idxHomeTeam");

            entity.HasIndex(e => e.LeagueKey, "idxLeagueKey");

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.HasIndex(e => e.VisitingTeam, "idxVisitingTeam");

            entity.Property(e => e.CalendarSubject)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CoinFlip)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.GameEndTime).HasColumnType("datetime");
            entity.Property(e => e.GameStartTime).HasColumnType("datetime");
            entity.Property(e => e.GameStatus)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.GameType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.XGameDate)
                .HasColumnType("datetime")
                .HasColumnName("xGameDate");
            entity.Property(e => e.XGameDateTime)
                .HasColumnType("datetime")
                .HasColumnName("xGameDateTime");
            entity.Property(e => e.XHomeTeamForfeit).HasColumnName("xHomeTeamForfeit");
            entity.Property(e => e.XScheduleForTeam).HasColumnName("xScheduleForTeam");
            entity.Property(e => e.XSharedGameKey).HasColumnName("xSharedGameKey");
            entity.Property(e => e.XSlotVerified).HasColumnName("xSlotVerified");
            entity.Property(e => e.XVisitingTeamForfeit).HasColumnName("xVisitingTeamForfeit");

            entity.HasOne(d => d.LeagueKeyNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.LeagueKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_League");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.SeasonKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Season");
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolKey);

            entity.ToTable("School");

            entity.Property(e => e.SchoolName)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.SchoolStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Schools)
                .HasForeignKey(d => d.OrganizationKey)
                .HasConstraintName("FK_School_Organization");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.SeasonKey);

            entity.ToTable("Season", tb =>
                {
                    tb.HasTrigger("Season_DeleteTrg");
                    tb.HasTrigger("Season_Insert");
                    tb.HasTrigger("Season_Update");
                });

            entity.HasIndex(e => e.ActivityCategoryKey, "idxActivityCategoryKey");

            entity.HasIndex(e => new { e.OrganizationKey, e.ActivityCategoryKey, e.SeasonStatus, e.ProgramType }, "idxOrgCategoryStatusType");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.AgeRequirementText)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CoachApplicationEnd).HasColumnType("datetime");
            entity.Property(e => e.CoachApplicationStart).HasColumnType("datetime");
            entity.Property(e => e.ComputeAgeAsOf).HasColumnType("datetime");
            entity.Property(e => e.CostInformation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.DateInformation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DonationRevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GenderSpecific)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MembershipDollarDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NonResidentRegistrationStart).HasColumnType("datetime");
            entity.Property(e => e.NotifyEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OneOrMultipleSessions)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.PreviousProgramDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProgramDescription).IsUnicode(false);
            entity.Property(e => e.ProgramLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProgramName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProgramSeason)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ProgramType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ProgramYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RegistrationEnd).HasColumnType("datetime");
            entity.Property(e => e.RegistrationReceipt)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationStart).HasColumnType("datetime");
            entity.Property(e => e.RegistrationType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("(I)ndividual, (T)eam, (B)oth. Indicates how the person will register. Either as an individaul, as a team or registration can take place either individually or as a team.");
            entity.Property(e => e.ResidentsOnly)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SeasonContactEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeasonContactName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SeasonContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SeasonPassDollarDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SeasonStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SiblingDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnreturnedEquipFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WaitlistEmail)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ActivityCategoryKeyNavigation).WithMany(p => p.Seasons)
                .HasForeignKey(d => d.ActivityCategoryKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Season_ActivityCategory");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Seasons)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Season_Organization");
        });

        modelBuilder.Entity<SeasonPass>(entity =>
        {
            entity.HasKey(e => e.SeasonPassKey);

            entity.ToTable("SeasonPass");

            entity.HasIndex(e => e.AccountKey, "IX_SeasonPass_Account");

            entity.HasIndex(e => new { e.OrganizationKey, e.FulfillmentStatus, e.DateAdded }, "IX_SeasonPass_Fulfillment");

            entity.HasIndex(e => new { e.OrganizationKey, e.AccountKey, e.SeasonPassYear }, "IX_SeasonPass_Org_Account_Year").IsDescending(false, false, true);

            entity.HasIndex(e => new { e.OrganizationKey, e.SeasonPassKey }, "IX_SeasonPass_Org_Pass");

            entity.HasIndex(e => new { e.OrganizationKey, e.SeasonPassYear }, "IX_SeasonPass_Org_Year");

            entity.HasIndex(e => e.BarcodeNumber, "UX_SeasonPass_Barcode").IsUnique();

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.SeasonPassSetupKey, "idxSeasonPassSetupKey");

            entity.Property(e => e.AddOnFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AddlPersonTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.AdjustmentTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BarcodeNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FulfillmentBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FulfillmentChoice)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.FulfillmentDate).HasColumnType("datetime");
            entity.Property(e => e.FulfillmentStatus)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasComment("Pending, Mailed, Picked Up");
            entity.Property(e => e.Idverified).HasColumnName("IDVerified");
            entity.Property(e => e.InactivateReason)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LostCardCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MailingAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MailingCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MailingName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MailingState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MailingZipCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PassHolderEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PassHolderFirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PassHolderLastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PassHolderPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PostageFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.SeasonPassOrderStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SeasonPassPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalDue)
                .HasComment("SeasonPassPrice + AddlPersonTotal + ConvenienceFee")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.SeasonPassSetupKeyNavigation).WithMany(p => p.SeasonPasses)
                .HasForeignKey(d => d.SeasonPassSetupKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeasonPass_SeasonPassSetup");
        });

        modelBuilder.Entity<SeasonPassAccessType>(entity =>
        {
            entity.HasKey(e => e.SeasonPassAccessTypeKey);

            entity.ToTable("SeasonPassAccessType");

            entity.Property(e => e.AccessTypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AccessTypePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AccessTypeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("This must match a LocationName in table ShiftLocation");
        });

        modelBuilder.Entity<SeasonPassAddOn>(entity =>
        {
            entity.HasKey(e => e.SeasonPassAddOnKey);

            entity.ToTable("SeasonPassAddOn");

            entity.Property(e => e.AddOnName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AddOnPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.SeasonPassAccessTypeKeyNavigation).WithMany(p => p.SeasonPassAddOns)
                .HasForeignKey(d => d.SeasonPassAccessTypeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeasonPassAddOn_SeasonPassAccessType");

            entity.HasOne(d => d.SeasonPassKeyNavigation).WithMany(p => p.SeasonPassAddOns)
                .HasForeignKey(d => d.SeasonPassKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeasonPassAddOn_SeasonPass");
        });

        modelBuilder.Entity<SeasonPassAddlPerson>(entity =>
        {
            entity.HasKey(e => e.SeasonPassAddlPersonKey);

            entity.ToTable("SeasonPassAddlPerson");

            entity.HasIndex(e => new { e.SeasonPassKey, e.AddlPersonFirstName, e.AddlPersonLastName }, "IX_SeasonPassAddlPerson_Pass_First_Last");

            entity.HasIndex(e => e.SeasonPassKey, "IX_SeasonPassAddlPerson_SeasonPassKey");

            entity.HasIndex(e => e.SeasonPassKey, "idxSeasonPassKey");

            entity.Property(e => e.AddlPersonFirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.AddlPersonLastName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.SeasonPassKeyNavigation).WithMany(p => p.SeasonPassAddlPeople)
                .HasForeignKey(d => d.SeasonPassKey)
                .HasConstraintName("FK_SeasonPassAddlPerson_SeasonPass");
        });

        modelBuilder.Entity<SeasonPassCheckin>(entity =>
        {
            entity.HasKey(e => e.SeasonPassCheckinKey);

            entity.ToTable("SeasonPassCheckin");

            entity.Property(e => e.BarcodeNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CheckInDate).HasColumnType("datetime");
            entity.Property(e => e.CheckinSource)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DeviceId)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.SeasonPassAddlPersonKeyNavigation).WithMany(p => p.SeasonPassCheckins)
                .HasForeignKey(d => d.SeasonPassAddlPersonKey)
                .HasConstraintName("FK_SeasonPassCheckin_SeasonPassAddlPerson");

            entity.HasOne(d => d.SeasonPassKeyNavigation).WithMany(p => p.SeasonPassCheckins)
                .HasForeignKey(d => d.SeasonPassKey)
                .HasConstraintName("FK_SeasonPassCheckin_SeasonPass");
        });

        modelBuilder.Entity<SeasonPassId>(entity =>
        {
            entity.HasKey(e => e.SeasonPassIdKey);

            entity.ToTable("SeasonPassId");

            entity.HasIndex(e => new { e.OrganizationKey, e.SeasonPassKey }, "IX_SeasonPassId_Org_Pass");

            entity.HasIndex(e => new { e.OrganizationKey, e.SeasonPassKey, e.SeasonPassId1 }, "IX_SeasonPassId_Org_Pass_Id");

            entity.HasIndex(e => new { e.OrganizationKey, e.SeasonPassIdStatus, e.SeasonPassId1 }, "IX_SeasonPassId_Org_Status_Id");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.SeasonPassId1).HasColumnName("SeasonPassId");
            entity.Property(e => e.SeasonPassIdStatus)
                .HasMaxLength(11)
                .IsUnicode(false);

            entity.HasOne(d => d.SeasonPassKeyNavigation).WithMany(p => p.SeasonPassIds)
                .HasForeignKey(d => d.SeasonPassKey)
                .HasConstraintName("FK_SeasonPassId_SeasonPass");
        });

        modelBuilder.Entity<SeasonPassPreference>(entity =>
        {
            entity.HasKey(e => e.SeasonPassPreferencesKey);

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.BarcodedCardCreation)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("ThirdParty, Jarvis");
            entity.Property(e => e.CardHtmlfileName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CardHTMLFileName");
            entity.Property(e => e.FlatPostageRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FreePassMaxAgeAsOfDate).HasColumnType("datetime");
            entity.Property(e => e.LostCardCharge).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumberAssignmentMethod)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasComment("Pool, None, Manual");
            entity.Property(e => e.RequireIdverification).HasColumnName("RequireIDVerification");
            entity.Property(e => e.SeasonPassIdAssignment)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SeasonPassPricingTier>(entity =>
        {
            entity.HasKey(e => e.SeasonPassPricingTiersKey);

            entity.HasIndex(e => e.SeasonPassSetupKey, "idxSeasonPassSetupKey");

            entity.Property(e => e.TierPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.SeasonPassSetupKeyNavigation).WithMany(p => p.SeasonPassPricingTiers)
                .HasForeignKey(d => d.SeasonPassSetupKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeasonPassPricingTiers_SeasonPassSetup");
        });

        modelBuilder.Entity<SeasonPassSetup>(entity =>
        {
            entity.HasKey(e => e.SeasonPassSetupKey);

            entity.ToTable("SeasonPassSetup");

            entity.HasIndex(e => new { e.OrganizationKey, e.SeasonPassYear, e.SeasonPassDescription }, "idxOrg_Description").IsUnique();

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.RevenueCode, "idxRevenueCode");

            entity.HasIndex(e => e.SeasonPassYear, "idxSeasonPassYear");

            entity.Property(e => e.AddlPersonPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AllowAddlPersons)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.BarcodePreface)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.LocationName)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasComment("Valid scan locations: comma-separated ShiftLocation LocationName or SubLocationName values; empty = valid everywhere");
            entity.Property(e => e.PassSellEndDate).HasColumnType("datetime");
            entity.Property(e => e.PassSellStartDate).HasColumnType("datetime");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SeasonPassDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SeasonPassPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SeasonPassStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<SeasonSiblingDiscount>(entity =>
        {
            entity.HasKey(e => e.SeasonSiblingDiscountKey);

            entity.ToTable("SeasonSiblingDiscount", tb =>
                {
                    tb.HasTrigger("SeasonSiblingDiscount_DeleteTrg");
                    tb.HasTrigger("SeasonSiblingDiscount_Insert");
                    tb.HasTrigger("SeasonSiblingDiscount_Update");
                });

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.SeasonSiblingDiscounts)
                .HasForeignKey(d => d.SeasonKey)
                .HasConstraintName("FK_SeasonSiblingDiscount_Season");
        });

        modelBuilder.Entity<SharedProgramLeague>(entity =>
        {
            entity.HasKey(e => e.SharedProgramLeagueKey);

            entity.ToTable("SharedProgramLeague");
        });

        modelBuilder.Entity<SharedSchedule>(entity =>
        {
            entity.HasKey(e => e.SharedScheduleKey);

            entity.ToTable("SharedSchedule");
        });

        modelBuilder.Entity<SharedScheduleFacility>(entity =>
        {
            entity.HasKey(e => e.SharedScheduleFacilityKey);

            entity.ToTable("SharedScheduleFacility");
        });

        modelBuilder.Entity<SharedScheduleTeam>(entity =>
        {
            entity.HasKey(e => e.SharedScheduleTeamKey);

            entity.ToTable("SharedScheduleTeam");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftKey);

            entity.ToTable("Shift");

            entity.HasIndex(e => new { e.OrganizationKey, e.ShiftEndDate }, "idxOrgKeyEndDate");

            entity.HasIndex(e => e.OrganizationKey, "idx_organizationkey");

            entity.Property(e => e.BalancedOn).HasColumnType("datetime");
            entity.Property(e => e.BeginningBalance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DrawerTotalCash).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DrawerTotalChecks).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DrawerTotalCreditCard).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReceivablesInputTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ShiftBalancedName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ShiftComments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ShiftEndDate).HasColumnType("datetime");
            entity.Property(e => e.ShiftEndName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ShiftReleaseDate).HasColumnType("datetime");
            entity.Property(e => e.ShiftStartDate).HasColumnType("datetime");
            entity.Property(e => e.ShiftStartName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ShiftLocation>(entity =>
        {
            entity.HasKey(e => e.ShiftLocationKey);

            entity.ToTable("ShiftLocation");

            entity.Property(e => e.LocationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MainCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShiftLocationStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StaffContact)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubLocationName)
                .HasMaxLength(75)
                .IsUnicode(false);

            entity.HasOne(d => d.ValorDeviceKeyNavigation).WithMany(p => p.ShiftLocations)
                .HasForeignKey(d => d.ValorDeviceKey)
                .HasConstraintName("FK_ShiftLocation_ValorDevice");
        });

        modelBuilder.Entity<SilverSneakersImportcsv>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SilverSneakersImportcsv");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FullAddress).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Phone1).HasMaxLength(50);
            entity.Property(e => e.Phone2).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<SkillLevel>(entity =>
        {
            entity.HasKey(e => e.SkillLevelKey);

            entity.ToTable("SkillLevel");

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.Property(e => e.SkillLevel1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("SkillLevel");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.SkillLevels)
                .HasForeignKey(d => d.SeasonKey)
                .HasConstraintName("FK_SkillLevel_Season");
        });

        modelBuilder.Entity<SpecialEvent>(entity =>
        {
            entity.HasKey(e => e.SpecialEventKey);

            entity.ToTable("SpecialEvent");

            entity.HasIndex(e => e.EmailAddress, "idxEmailAddr");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.SpecialEventConfigureKey, "idxSpecialEventConfigureKey");

            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DateOfSale).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.HomeAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ResidentNonResident)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SaleAddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.SpecialEvents)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpecialEvent_Organization");

            entity.HasOne(d => d.SpecialEventConfigureKeyNavigation).WithMany(p => p.SpecialEvents)
                .HasForeignKey(d => d.SpecialEventConfigureKey)
                .HasConstraintName("FK_SpecialEvent_SpecialEventConfigure");
        });

        modelBuilder.Entity<SpecialEventConfigure>(entity =>
        {
            entity.HasKey(e => e.SpecialEventConfigureKey);

            entity.ToTable("SpecialEventConfigure");

            entity.Property(e => e.EventDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.EventEndDate).HasColumnType("datetime");
            entity.Property(e => e.EventName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventStartDate).HasColumnType("datetime");
            entity.Property(e => e.EventStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.SpecialEventConfigures)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpecialEventConfigure_Organization");
        });

        modelBuilder.Entity<SpecialEventItem>(entity =>
        {
            entity.HasKey(e => e.SpecialEventItemKey);

            entity.ToTable("SpecialEventItem");

            entity.Property(e => e.AdditionalQuestion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.EventItemDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventItemPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EventItemPriceNon).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EventItemStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.SpecialEventConfigureKeyNavigation).WithMany(p => p.SpecialEventItems)
                .HasForeignKey(d => d.SpecialEventConfigureKey)
                .HasConstraintName("FK_SpecialEventItem_SpecialEventConfigure");
        });

        modelBuilder.Entity<SpecialEventItemPurchase>(entity =>
        {
            entity.HasKey(e => e.SpecialEventItemPurchaseKey);

            entity.ToTable("SpecialEventItemPurchase");

            entity.HasIndex(e => e.SpecialEventKey, "idxSpecialEventKey");

            entity.Property(e => e.AnswerToQuestion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PriceEach).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.SpecialEventItemKeyNavigation).WithMany(p => p.SpecialEventItemPurchases)
                .HasForeignKey(d => d.SpecialEventItemKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpecialEventItemPurchase_SpecialEventItem");

            entity.HasOne(d => d.SpecialEventKeyNavigation).WithMany(p => p.SpecialEventItemPurchases)
                .HasForeignKey(d => d.SpecialEventKey)
                .HasConstraintName("FK_SpecialEventItemPurchase_SpecialEvent");
        });

        modelBuilder.Entity<Sponsor>(entity =>
        {
            entity.HasKey(e => e.SponsorKey);

            entity.ToTable("Sponsor", tb =>
                {
                    tb.HasTrigger("Sponsor_DeleteTrg");
                    tb.HasTrigger("Sponsor_InsertTrg");
                    tb.HasTrigger("Sponsor_UpdateTrg");
                });

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.AddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ContactAddress)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.ContactCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ContactPhoneNbr)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContactSecondaryPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContactState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContactZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.SponsorAddress)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.SponsorCity)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SponsorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SponsorNotes)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SponsorPrimaryPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SponsorSecondaryPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SponsorSince).HasColumnType("datetime");
            entity.Property(e => e.SponsorState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SponsorStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SponsorZip)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.WebsiteAddress)
                .HasMaxLength(75)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Sponsors)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sponsor_Organization");
        });

        modelBuilder.Entity<SponsorPledgeType>(entity =>
        {
            entity.HasKey(e => e.SponsorPledgeTypeKey);

            entity.ToTable("SponsorPledgeType");

            entity.HasIndex(e => e.SponsorProgramKey, "idxSponsorProgramKey");

            entity.Property(e => e.SponsorPledgeType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SponsorPledgeType");
            entity.Property(e => e.SponsorPledgeTypeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SponsorPledgeTypeDesc)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SponsorPledgeTypeStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.SponsorProgramKeyNavigation).WithMany(p => p.SponsorPledgeTypes)
                .HasForeignKey(d => d.SponsorProgramKey)
                .HasConstraintName("FK_SponsorPledgeType_SponsorProgram");
        });

        modelBuilder.Entity<SponsorPreference>(entity =>
        {
            entity.HasKey(e => e.SponsorPreferenceKey);

            entity.ToTable("SponsorPreference");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.OnlineEmailNotification)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SponsorVerbiageOnline).HasColumnType("text");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.SponsorPreferences)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SponsorPreference_OrganizationKey");
        });

        modelBuilder.Entity<SponsorProgram>(entity =>
        {
            entity.HasKey(e => e.SponsorProgramKey);

            entity.ToTable("SponsorProgram");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.ProgramName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SponsorProgramStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.SponsorPrograms)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SponsorProgram_OrganizationKey");
        });

        modelBuilder.Entity<Statement>(entity =>
        {
            entity.HasKey(e => e.StatementKey);

            entity.ToTable("Statement");

            entity.Property(e => e.StatementDate).HasColumnType("datetime");
            entity.Property(e => e.StatementName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalInvoice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Statements)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Statement_Organization");
        });

        modelBuilder.Entity<StatementDetail>(entity =>
        {
            entity.HasKey(e => e.StatementDetailKey);

            entity.ToTable("StatementDetail");

            entity.Property(e => e.BillRate).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.BilledAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationPercentTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.StatementKeyNavigation).WithMany(p => p.StatementDetails)
                .HasForeignKey(d => d.StatementKey)
                .HasConstraintName("FK_StatementDetail_Statement");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamKey);

            entity.ToTable("Team");

            entity.HasIndex(e => e.CityKey, "idxCityKey");

            entity.HasIndex(e => e.LeagueKey, "idxLeagueKey");

            entity.Property(e => e.AdjustmentTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Comments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EarlyBirdDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EquipReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.LateRegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RegistrationPassword)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RosterSentOn).HasColumnType("datetime");
            entity.Property(e => e.TeamAdded).HasColumnType("datetime");
            entity.Property(e => e.TeamColors)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TeamRegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TeamStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalInvoiceAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalNsf)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TotalNSF");
            entity.Property(e => e.TotalPaidAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnreturnedEquipCharge).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CityKeyNavigation).WithMany(p => p.Teams)
                .HasForeignKey(d => d.CityKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_City");

            entity.HasOne(d => d.LeagueKeyNavigation).WithMany(p => p.Teams)
                .HasForeignKey(d => d.LeagueKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Team_League");
        });

        modelBuilder.Entity<TeamAdjustment>(entity =>
        {
            entity.HasKey(e => e.TeamAdjustmentKey);

            entity.ToTable("TeamAdjustment");

            entity.Property(e => e.AdjustmentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentDate).HasColumnType("datetime");
            entity.Property(e => e.AdjustmentPostedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.TeamKeyNavigation).WithMany(p => p.TeamAdjustments)
                .HasForeignKey(d => d.TeamKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamAdjustment_Team");
        });

        modelBuilder.Entity<TeamPending>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TeamPending");

            entity.Property(e => e.CoachEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CoachName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.EarlyBirdDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EnteredBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LateRegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MilitaryDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TeamAdded).HasColumnType("datetime");
            entity.Property(e => e.TeamColors)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TeamPendingKey).ValueGeneratedOnAdd();
            entity.Property(e => e.TeamRegistrationFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TeamStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalInvoiceAmt).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TeamRoster>(entity =>
        {
            entity.HasKey(e => e.TeamRosterKey);

            entity.ToTable("TeamRoster");

            entity.HasIndex(e => e.EmailAddress, "idxEmailAddress");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.TeamKey, "idxTeamKey");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.JerseySize)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.TeamRosters)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamRoster_Organization");

            entity.HasOne(d => d.TeamKeyNavigation).WithMany(p => p.TeamRosters)
                .HasForeignKey(d => d.TeamKey)
                .HasConstraintName("FK_TeamRoster_Team");
        });

        modelBuilder.Entity<TeamStanding>(entity =>
        {
            entity.HasKey(e => e.TeamStandingsKey).HasName("PK_TempStandingsComputation");

            entity.Property(e => e.NbrLost).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.NbrWon).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Wlpercent)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("WLPercent");

            entity.HasOne(d => d.LeagueKeyNavigation).WithMany(p => p.TeamStandings)
                .HasForeignKey(d => d.LeagueKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamStandings_League");

            entity.HasOne(d => d.TeamKeyNavigation).WithMany(p => p.TeamStandings)
                .HasForeignKey(d => d.TeamKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamStandings_Team");
        });

        modelBuilder.Entity<TeamToCoach>(entity =>
        {
            entity.HasKey(e => e.TeamToCoachKey);

            entity.ToTable("TeamToCoach");

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => e.CoachKey, "idxCoachKey");

            entity.HasIndex(e => e.ProgramType, "idxProgramType");

            entity.HasIndex(e => new { e.TeamKey, e.CoachType }, "idxTeamCoachType");

            entity.HasIndex(e => e.TeamKey, "idxTeamKey");

            entity.Property(e => e.AccountKey).HasComment("The account holder record the coach is tied to.");
            entity.Property(e => e.CoachEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CoachKey).HasComment("The key to the coach application for youth coaches. Will not be populated for adult coach/managers, only the 'AccountKey'.");
            entity.Property(e => e.CoachName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Name of the coach. For coach's with applications (youth) will keep from having to join to get name. For adult teams, the record is linked to the account so it tells which account holder is the coach/manager.");
            entity.Property(e => e.CoachType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("This is the 'Volunteer Capacity - 'Head Coach', 'Assistant Coach' or the actual volunteer capacity value");
            entity.Property(e => e.ProgramType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("'Adult Team', 'Youth Team', 'Youth Full' or 'Individual'. Indicates the type of team the coach is for. 'Youth Team' is for the invite process, while 'Youth Full' is for those programs registering only youth teams.");

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.TeamToCoaches)
                .HasForeignKey(d => d.AccountKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamToCoach_Account");

            entity.HasOne(d => d.CoachKeyNavigation).WithMany(p => p.TeamToCoaches)
                .HasForeignKey(d => d.CoachKey)
                .HasConstraintName("FK_TeamToCoach_CoachApplication");

            entity.HasOne(d => d.TeamKeyNavigation).WithMany(p => p.TeamToCoaches)
                .HasForeignKey(d => d.TeamKey)
                .HasConstraintName("FK_TeamToCoach_Team");
        });

        modelBuilder.Entity<TermsAndCondition>(entity =>
        {
            entity.HasKey(e => e.TermsAndConditionsKey);

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TermsAndConditionsText).HasColumnType("ntext");

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.TermsAndConditions)
                .HasForeignKey(d => d.SeasonKey)
                .HasConstraintName("FK_TermsAndConditions_Season");
        });

        modelBuilder.Entity<TextMessageOptIn>(entity =>
        {
            entity.HasKey(e => e.TextMessageOptInKey);

            entity.ToTable("TextMessageOptIn");

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => new { e.OrganizationKey, e.CellPhone }, "idxOrgCellPhone");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.CellPhone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CellPhoneDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OptInDate).HasColumnType("datetime");
            entity.Property(e => e.OptOutDate).HasColumnType("datetime");

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.TextMessageOptIns)
                .HasForeignKey(d => d.AccountKey)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TextMessageOptIn_Account");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.TextMessageOptIns)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextMessageOptIn_Organization");
        });

        modelBuilder.Entity<TextMessageOptInTeam>(entity =>
        {
            entity.HasKey(e => e.TextMessageOptInTeamKey);

            entity.ToTable("TextMessageOptInTeam");

            entity.HasIndex(e => e.TeamKey, "idxTeamKey");

            entity.HasIndex(e => e.TextMessageOptInKey, "idxTextMessageOptInKey");

            entity.Property(e => e.OptInDate).HasColumnType("datetime");

            entity.HasOne(d => d.TeamKeyNavigation).WithMany(p => p.TextMessageOptInTeams)
                .HasForeignKey(d => d.TeamKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextMessageOptInTeam_Team");

            entity.HasOne(d => d.TextMessageOptInKeyNavigation).WithMany(p => p.TextMessageOptInTeams)
                .HasForeignKey(d => d.TextMessageOptInKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextMessageOptInTeam_TextMessageOptIn");
        });

        modelBuilder.Entity<TextMessageSentLog>(entity =>
        {
            entity.HasKey(e => e.TextMessageSentLogKey);

            entity.ToTable("TextMessageSentLog");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DateSent).HasColumnType("datetime");
            entity.Property(e => e.ScreenSentFrom)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SentBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TextMessage)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfSend)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.TextMessageSentLogs)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextMessageSentLog_Organization");
        });

        modelBuilder.Entity<TextMessageSentLogDetail>(entity =>
        {
            entity.HasKey(e => e.TextMessageSentLogDetailKey);

            entity.ToTable("TextMessageSentLogDetail");

            entity.HasIndex(e => e.AccountKey, "idxAccountKey");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => e.TextMessageSentLogKey, "idxTextMessageSentLogKey");

            entity.Property(e => e.CellPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MessageId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MessageIdStopped)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Recipient)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Smsreturn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMSReturn");
            entity.Property(e => e.TextMessage).HasColumnType("text");

            entity.HasOne(d => d.AccountKeyNavigation).WithMany(p => p.TextMessageSentLogDetails)
                .HasForeignKey(d => d.AccountKey)
                .HasConstraintName("FK_TextMessageSentLogDetail_Account");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.TextMessageSentLogDetails)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextMessageSentLogDetail_Organization");

            entity.HasOne(d => d.TextMessageSentLogKeyNavigation).WithMany(p => p.TextMessageSentLogDetails)
                .HasForeignKey(d => d.TextMessageSentLogKey)
                .HasConstraintName("FK_TextMessageSentLogDetail_TextMessageSentLog");
        });

        modelBuilder.Entity<TourRegistration>(entity =>
        {
            entity.HasKey(e => e.TourRegistrationKey);

            entity.ToTable("TourRegistration");

            entity.Property(e => e.BookingDateTime).HasColumnType("datetime");
            entity.Property(e => e.CheckedInTime).HasColumnType("datetime");
            entity.Property(e => e.CheckedOutTime).HasColumnType("datetime");
            entity.Property(e => e.ConvenienceFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FirstName2)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.GroupName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SpecialRequest).HasColumnType("text");
            entity.Property(e => e.StaffNotes).IsUnicode(false);
            entity.Property(e => e.TotalDue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPaid).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TourDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.TourTypeItemKeyNavigation).WithMany(p => p.TourRegistrations)
                .HasForeignKey(d => d.TourTypeItemKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TourRegistration_TourTypeItem");
        });

        modelBuilder.Entity<TourType>(entity =>
        {
            entity.HasKey(e => e.TourTypeKey);

            entity.ToTable("TourType");

            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TourTypeDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TourTypeItem>(entity =>
        {
            entity.HasKey(e => e.TourTypeItemKey).HasName("PK_TourItem");

            entity.ToTable("TourTypeItem");

            entity.Property(e => e.PriceType)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TourItemDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TourPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.TourTypeKeyNavigation).WithMany(p => p.TourTypeItems)
                .HasForeignKey(d => d.TourTypeKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TourTypeItem_TourType");
        });

        modelBuilder.Entity<TourTypeSchedule>(entity =>
        {
            entity.HasKey(e => e.TourTypeScheduleKey).HasName("PK_TourSchedule");

            entity.ToTable("TourTypeSchedule");

            entity.Property(e => e.ScheduleDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TourTypeScheduleStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TourTypeScheduleSlot>(entity =>
        {
            entity.HasKey(e => e.TourTypeScheduleSlotKey).HasName("PK_TourScheduleSlot");

            entity.ToTable("TourTypeScheduleSlot");

            entity.Property(e => e.TourScheduleSlotStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.TourTypeScheduleKeyNavigation).WithMany(p => p.TourTypeScheduleSlots)
                .HasForeignKey(d => d.TourTypeScheduleKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TourScheduleSlot_TourSchedule");
        });

        modelBuilder.Entity<UsaePayBatchSummaryTemp>(entity =>
        {
            entity.HasKey(e => e.UsaePayBatchSummaryKey);

            entity.ToTable("USAePayBatchSummaryTemp");

            entity.Property(e => e.UsaePayBatchSummaryKey).HasColumnName("USAePayBatchSummaryKey");
            entity.Property(e => e.PaymentTotal).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<UsaepayBatch>(entity =>
        {
            entity.HasKey(e => new { e.OrganizationKey, e.BatchId }).HasName("PK_usaepaybatch");

            entity.ToTable("USAepayBatch");

            entity.Property(e => e.OrganizationKey)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BatchId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Batch_Id");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Closed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DiscrepancyComments)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Opened)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrgPaymentTotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Seq)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsaepayBatchTotal>(entity =>
        {
            entity.HasKey(e => e.BatchId);

            entity.ToTable("UsaepayBatchTotal");

            entity.Property(e => e.BatchId).ValueGeneratedNever();
            entity.Property(e => e.PaymentTotal).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<UsaepaybatchPelham>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usaepaybatch_pelham");

            entity.Property(e => e.Amount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("amount");
            entity.Property(e => e.BatchId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("batch_id");
            entity.Property(e => e.Closed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("closed");
            entity.Property(e => e.Count)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("count");
            entity.Property(e => e.Opened)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("opened");
            entity.Property(e => e.Organizationkey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("organizationkey");
            entity.Property(e => e.Seq)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("seq");
        });

        modelBuilder.Entity<UsaepaybatchSpringville>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usaepaybatch_springville");

            entity.Property(e => e.Amount)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("amount");
            entity.Property(e => e.BatchId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("batch_id");
            entity.Property(e => e.Closed)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("closed");
            entity.Property(e => e.Count)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("count");
            entity.Property(e => e.Opened)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("opened");
            entity.Property(e => e.Organizationkey)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("organizationkey");
            entity.Property(e => e.Seq)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("seq");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("UserDetails_Insert");
                    tb.HasTrigger("UserDetails_Update");
                });

            entity.HasIndex(e => e.OrganizationKey, "idx_organizationkey");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.InitialScreen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastAccess).HasColumnType("datetime");
            entity.Property(e => e.LastChangedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserIdStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDetails_Organization");

            entity.HasOne(d => d.User).WithOne(p => p.UserDetail)
                .HasForeignKey<UserDetail>(d => d.UserId)
                .HasConstraintName("FK_UserDetails_aspnet_Users");
        });

        modelBuilder.Entity<UserPreference>(entity =>
        {
            entity.HasKey(e => e.UserPreferencesKey);

            entity.HasIndex(e => new { e.OrganizationKey, e.UserId, e.PreferenceArea }, "idxPreferencesArea");

            entity.Property(e => e.PreferenceArea)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PreferenceName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ValorDevice>(entity =>
        {
            entity.HasKey(e => e.ValorDeviceKey);

            entity.ToTable("ValorDevice");

            entity.Property(e => e.AppKey)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DeviceName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DeviceStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Epiid)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EPIId");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ShortName)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorKey);

            entity.ToTable("Vendor");

            entity.Property(e => e.ReminderEmailSent).HasColumnType("datetime");
            entity.Property(e => e.VendorAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorCity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VendorContactName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.VendorContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VendorDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VendorEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorState)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VendorStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.VendorZip)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vendor_Organization");
        });

        modelBuilder.Entity<VendorChargeItem>(entity =>
        {
            entity.HasKey(e => e.VendorChargeItemKey);

            entity.ToTable("VendorChargeItem");

            entity.Property(e => e.ChargeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ChargeItemDescription)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.ChargeItemStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RevenueCode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.VendorKeyNavigation).WithMany(p => p.VendorChargeItems)
                .HasForeignKey(d => d.VendorKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VendorChargeItem_Vendor");
        });

        modelBuilder.Entity<Volunteer>(entity =>
        {
            entity.HasKey(e => e.VolunteerKey);

            entity.ToTable("Volunteer");

            entity.HasIndex(e => e.SeasonKey, "idxSeasonKey");

            entity.Property(e => e.VolunteerCapacity)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.SeasonKeyNavigation).WithMany(p => p.Volunteers)
                .HasForeignKey(d => d.SeasonKey)
                .HasConstraintName("FK_Volunteer_Season");
        });

        modelBuilder.Entity<WebBoard>(entity =>
        {
            entity.HasKey(e => e.BoardKey);

            entity.ToTable("WebBoard");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.BoardMemberStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MemberPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MemberRole)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleDescLine1)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.RoleDescLine2)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.WebBoards)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebBoard_Organization");
        });

        modelBuilder.Entity<WebFaq>(entity =>
        {
            entity.HasKey(e => e.WebFaqkey);

            entity.ToTable("WebFAQ");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.WebFaqkey).HasColumnName("WebFAQKey");
            entity.Property(e => e.Faqanswer)
                .HasColumnType("text")
                .HasColumnName("FAQAnswer");
            entity.Property(e => e.Faqcategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FAQCategory");
            entity.Property(e => e.FaqdisplayOrder).HasColumnName("FAQDisplayOrder");
            entity.Property(e => e.Faqquestion)
                .HasColumnType("text")
                .HasColumnName("FAQQuestion");
            entity.Property(e => e.Faqstatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FAQStatus");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.WebFaqs)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebFAQ_Organization");
        });

        modelBuilder.Entity<WebForm>(entity =>
        {
            entity.HasKey(e => e.WebFormKey);

            entity.ToTable("WebForm");

            entity.HasIndex(e => new { e.OrganizationKey, e.FormStatus, e.FormCategory }, "idxOrgCategoryStatus");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.FormCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FormFilename)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FormStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FormSubject)
                .HasMaxLength(75)
                .IsUnicode(false);

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.WebForms)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebForm_Organization");
        });

        modelBuilder.Entity<WebHomePageContent>(entity =>
        {
            entity.HasKey(e => e.WebHomePageContentKey);

            entity.ToTable("WebHomePageContent");

            entity.HasIndex(e => new { e.OrganizationKey, e.HomePageContentArea }, "idxKeyAndContent");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.HomePageContentArea)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HomePageContentText).HasColumnType("ntext");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.WebHomePageContents)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebHomePageContent_Organization");
        });

        modelBuilder.Entity<WebListCategory>(entity =>
        {
            entity.HasKey(e => e.WebListCategoryKey);

            entity.ToTable("WebListCategory");

            entity.HasIndex(e => new { e.OrganizationKey, e.WeblistPageKey }, "idxWebListPageKey");

            entity.Property(e => e.WebListCategoryKey).HasComment("This table is populated manually depending on the requirements of the organizations website");
            entity.Property(e => e.WebsiteListCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WebListItem>(entity =>
        {
            entity.HasKey(e => e.WebListItemKey).HasName("PK_WebWhatsIncluded");

            entity.ToTable("WebListItem");

            entity.HasIndex(e => e.WebListCategoryKey, "idxWebListCategoryKey");

            entity.Property(e => e.WebListItem1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WebListItem");
        });

        modelBuilder.Entity<WebListPage>(entity =>
        {
            entity.HasKey(e => e.WebListPageKey);

            entity.ToTable("WebListPage");

            entity.Property(e => e.WebListPageKey).HasComment("This table is populated manually depending on the requirements of the organizations website");
            entity.Property(e => e.WebsitePage)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WebNewsEvent>(entity =>
        {
            entity.HasKey(e => e.NewsEventsKey);

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DateAdded).HasColumnType("datetime");
            entity.Property(e => e.NewsEndDate).HasColumnType("datetime");
            entity.Property(e => e.NewsEventsContent).HasColumnType("text");
            entity.Property(e => e.NewsEventsSubject)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NewsStartDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.WebNewsEvents)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebNewsEvents_Organization");
        });

        modelBuilder.Entity<WebPageAccess>(entity =>
        {
            entity.HasKey(e => e.WebPageAccessKey);

            entity.ToTable("WebPageAccess");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.WebPageAccesses)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebPageAccess_Organization");
        });

        modelBuilder.Entity<WebTestimonial>(entity =>
        {
            entity.HasKey(e => e.WebTestimonialKey);

            entity.ToTable("WebTestimonial");

            entity.Property(e => e.DateSubmitted).HasColumnType("datetime");
            entity.Property(e => e.SubmitterName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TestimonialContent).IsUnicode(false);
            entity.Property(e => e.TestimonialStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("(U)nread, (R)ead");
        });

        modelBuilder.Entity<WebTestimonialNote>(entity =>
        {
            entity.HasKey(e => e.WebTestimonialNoteKey);

            entity.ToTable("WebTestimonialNote");

            entity.Property(e => e.DateNoteAdded).HasColumnType("datetime");
            entity.Property(e => e.NoteAddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TestimonialNote)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WebWebtext>(entity =>
        {
            entity.HasKey(e => new { e.WebtextKey, e.OrganizationKey });

            entity.ToTable("WebWebtext");

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.HasIndex(e => new { e.WebtextKey, e.OrganizationKey }, "idx_keyandorg");

            entity.Property(e => e.WebtextKey)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WebtextCategory)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.WebtextStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.WebtextUniqueKey).ValueGeneratedOnAdd();
            entity.Property(e => e.WebtextVerbiage).HasColumnType("ntext");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.WebWebtexts)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WebWebtext_Organization");
        });

        modelBuilder.Entity<WebsiteContactU>(entity =>
        {
            entity.HasKey(e => e.WebsiteContactUsKey);

            entity.HasIndex(e => e.OrganizationKey, "idxOrganizationKey");

            entity.Property(e => e.DateSubmitted).HasColumnType("datetime");
            entity.Property(e => e.MessageContent).IsUnicode(false);
            entity.Property(e => e.MessageStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MessageSubject)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubmitterEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubmitterName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WebsiteContactUsNote>(entity =>
        {
            entity.HasKey(e => e.WebsiteContactUsNoteKey);

            entity.ToTable("WebsiteContactUsNote");

            entity.HasIndex(e => e.WebsiteContactUsKey, "idxWebsiteContactUsKey");

            entity.Property(e => e.ContactUsNote)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DateNoteAdded).HasColumnType("datetime");
            entity.Property(e => e.NoteAddedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XCrmlead>(entity =>
        {
            entity.HasKey(e => e.CrmleadKey).HasName("PK_CRMLead");

            entity.ToTable("xCRMLead");

            entity.Property(e => e.CrmleadKey).HasColumnName("CRMLeadKey");
            entity.Property(e => e.CallBackDate).HasColumnType("datetime");
            entity.Property(e => e.CompanyCity)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CompanyEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyExt)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CompanySt)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContactEmailAddr)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ContactPhoneExt)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.ContactTitle)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CrmleadStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CRMLeadStatus");
            entity.Property(e => e.CurrentlyUsing)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DemoDate).HasColumnType("datetime");
            entity.Property(e => e.FirstContactedDate).HasColumnType("datetime");
            entity.Property(e => e.LastTouchedDate).HasColumnType("datetime");
            entity.Property(e => e.LastVerifiedDate).HasColumnType("datetime");
            entity.Property(e => e.LeadType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OtherComments).HasColumnType("text");
            entity.Property(e => e.UnqualifiedDate).HasColumnType("datetime");
            entity.Property(e => e.UnqualifiedReason)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.WebAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XCrmleadNote>(entity =>
        {
            entity.HasKey(e => e.CrmleadNoteKey).HasName("PK_CRMLeadNote");

            entity.ToTable("xCRMLeadNote");

            entity.Property(e => e.CrmleadNoteKey).HasColumnName("CRMLeadNoteKey");
            entity.Property(e => e.CallOutcome)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CrmleadKey).HasColumnName("CRMLeadKey");
            entity.Property(e => e.NoteDate).HasColumnType("datetime");
            entity.Property(e => e.NoteText).HasColumnType("text");
        });

        modelBuilder.Entity<XEmailSentLogArchived>(entity =>
        {
            entity.HasKey(e => e.EmailSentLogKey).HasName("PK_EmailSentLogArchived");

            entity.ToTable("xEmailSentLogArchived");

            entity.Property(e => e.EmailSentLogKey).ValueGeneratedNever();
            entity.Property(e => e.Archived)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Attachment1Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Attachment2Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DateSent).HasColumnType("datetime");
            entity.Property(e => e.EmailBody).HasColumnType("ntext");
            entity.Property(e => e.EmailSendStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmailSubject)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ReplyToEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ScreenSentFrom)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SendGridJson)
                .HasColumnType("text")
                .HasColumnName("SendGridJSON");
            entity.Property(e => e.SendInBackground)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SentBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfSend)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XEmailSentLogDetailArchived>(entity =>
        {
            entity.HasKey(e => e.EmailSentLogDetailKey).HasName("PK_EmailSentLogDetailArchived");

            entity.ToTable("xEmailSentLogDetailArchived");

            entity.Property(e => e.EmailSentLogDetailKey).ValueGeneratedNever();
            entity.Property(e => e.BadEmailReason)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddressSent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailContent).HasColumnType("ntext");
            entity.Property(e => e.EmailOrigin)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.EmailStatus)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ScdateSent)
                .HasColumnType("datetime")
                .HasColumnName("SCDateSent");
            entity.Property(e => e.SendGridDateSent).HasColumnType("datetime");
        });

        modelBuilder.Entity<XFacilityOwnerShare>(entity =>
        {
            entity.HasKey(e => e.FacilityOwnerShareKey).HasName("PK_FacilitySpaceShared");

            entity.ToTable("xFacilityOwnerShare");

            entity.Property(e => e.FacilityShareName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FacilitySpaceKeyNavigation).WithMany(p => p.XFacilityOwnerShares)
                .HasForeignKey(d => d.FacilitySpaceKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityOwnerShare_FacilitySpace");

            entity.HasOne(d => d.OrganizationKeyNavigation).WithMany(p => p.XFacilityOwnerShares)
                .HasForeignKey(d => d.OrganizationKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityOwnerShare_Organization");
        });

        modelBuilder.Entity<XFacilityOwnerShareToOrg>(entity =>
        {
            entity.HasKey(e => e.FacilityOwnerShareToOrgKey).HasName("PK_FacilityOwnerShareOrg");

            entity.ToTable("xFacilityOwnerShareToOrg");

            entity.Property(e => e.ShareToOrgStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.FacilityOwnerShareKeyNavigation).WithMany(p => p.XFacilityOwnerShareToOrgs)
                .HasForeignKey(d => d.FacilityOwnerShareKey)
                .HasConstraintName("FK_FacilityOwnerShareToOrg_FacilityOwnerShare");

            entity.HasOne(d => d.SharedToOrgNavigation).WithMany(p => p.XFacilityOwnerShareToOrgs)
                .HasForeignKey(d => d.SharedToOrg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FacilityOwnerShareToOrg_Organization");
        });

        modelBuilder.Entity<XFacilityShareGroup>(entity =>
        {
            entity.HasKey(e => e.FacilityShareGroupKey).HasName("PK_FacilityShareGroup");

            entity.ToTable("xFacilityShareGroup");

            entity.Property(e => e.FacilityShareGroupName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XLeagueSchedulerDh>(entity =>
        {
            entity.HasKey(e => e.LeagueSchedulerDhkey).HasName("PK_LeagueSchedulerDH");

            entity.ToTable("xLeagueSchedulerDH");

            entity.Property(e => e.LeagueSchedulerDhkey).HasColumnName("LeagueSchedulerDHKey");
            entity.Property(e => e.GameEndTime).HasColumnType("datetime");
            entity.Property(e => e.GameStartTime).HasColumnType("datetime");
            entity.Property(e => e.NewGameEndTime).HasColumnType("datetime");
            entity.Property(e => e.NewGameStartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<XLeagueShare>(entity =>
        {
            entity.HasKey(e => e.LeagueShareKey).HasName("PK_TeamShare");

            entity.ToTable("xLeagueShare");

            entity.Property(e => e.LastUpdatedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.LeagueDivision)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ShareStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SportName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XSalesUser>(entity =>
        {
            entity.HasKey(e => e.SalesUserKey).HasName("PK_SalesUser");

            entity.ToTable("xSalesUser");

            entity.Property(e => e.FullName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SalesUserId)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UserPassword)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XSeasonPassAdjustment>(entity =>
        {
            entity.HasKey(e => e.SeasonPassAdjustmentKey).HasName("PK_SeasonPassAdjustment");

            entity.ToTable("xSeasonPassAdjustment");

            entity.Property(e => e.AdjustedBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.AdjustmentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AdjustmentDate).HasColumnType("datetime");
            entity.Property(e => e.AdjustmentReason)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.SeasonPassKeyNavigation).WithMany(p => p.XSeasonPassAdjustments)
                .HasForeignKey(d => d.SeasonPassKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SeasonPassAdjustment_SeasonPass");
        });

        modelBuilder.Entity<XTextMessageSentLogArchived>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("xTextMessageSentLogArchived");

            entity.Property(e => e.AddlInfo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DateSent).HasColumnType("datetime");
            entity.Property(e => e.ScreenSentFrom)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.SentBy)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TextMessage).HasColumnType("text");
            entity.Property(e => e.TextSubject)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfSend)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<XTextMessageSentLogDetailArchived>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("xTextMessageSentLogDetailArchived");

            entity.Property(e => e.CellPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MessageId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Recipient)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Smsreturn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SMSReturn");
            entity.Property(e => e.TextMessage).HasColumnType("text");
        });

        modelBuilder.Entity<Z00c2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("z00c2");

            entity.Property(e => e.Amount)
                .HasColumnType("money")
                .HasColumnName("amount");
            entity.Property(e => e.AuthCode)
                .HasMaxLength(50)
                .HasColumnName("authCode");
            entity.Property(e => e.Reference)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("reference");
            entity.Property(e => e.TenderType)
                .HasMaxLength(50)
                .HasColumnName("tenderType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
