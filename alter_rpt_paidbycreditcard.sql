-- Run against the live database to deploy changes to rpt_paidbycreditcard:
--   Adds an "Account Credit Return" section. When a card payment (Payment,
--   PaymentFacility, or PaymentMembership) is later refunded into account credit
--   instead of back to the card, AccountCreditReturnSource records that refund and
--   the origin row's PaymentAmount is reduced by ReturnAmount + ConvenienceFee (or the
--   origin row is deleted entirely for a full refund). The report was only reading
--   the (now reduced) origin row, so its credit card total came in lower than what
--   MX actually charged the card on the original swipe date.
--   AccountCreditReturnSource.OriginPaymentDate is used for the date filter (the
--   date MX actually charged the card), not ReturnDate.
-- jarvisdb.sql (schema reference dump) has already been updated to match.

ALTER PROCEDURE [dbo].[rpt_paidbycreditcard]
	@OrganizationKey	int,
	@SeasonKey			int = 0,
	@StartDate			datetime,
	@EndDate			datetime

AS

	SET NOCOUNT ON;

	-- Get the POS screen name for this organization
    DECLARE @POSScreenName varchar(100);

    SELECT @POSScreenName = POSScreenName
    FROM Organization
    WHERE OrganizationKey = @OrganizationKey;

	CREATE TABLE #Temp (ParticipantName varchar(100), ContactName varchar(80), LeagueName varchar(75),
		OrganizationName varchar(50), ProgramName varchar(50), RegistrationNbr varchar(50),
		ConfirmationNbr varchar(50), PaymentType varchar(6), PaymentDate datetime, PaymentAmount decimal(18,2),
		ConvenienceFee decimal(18,2))

	-------------------------------------------------
	-- Individual Registrations
	-------------------------------------------------
	INSERT INTO #Temp
	SELECT FirstName + ' ' + LastName,
		CASE
			WHEN Account2First Is Null THEN Account1First + ' ' + Account1Last
			ELSE Account1First + ' ' + Account1Last + ' and ' + Account2First + ' ' + Account2Last
		END, LeagueName, OrganizationName, ProgramName, RegistrationNbr, ConfirmationNbr,
		PaymentType, PaymentDate, PaymentAmount-Coalesce(Payment.ConvenienceFee,0), Payment.ConvenienceFee
	FROM RegistrantToLeague
	LEFT JOIN Registrant ON RegistrantToLeague.RegistrantKey = Registrant.RegistrantKey
	LEFT JOIN Account ON Registrant.AccountKey = Account.AccountKey
	LEFT JOIN League ON RegistrantToLeague.LeagueKey = League.LeagueKey
	LEFT JOIN Season ON League.SeasonKey = Season.SeasonKey
	LEFT JOIN Organization ON Season.OrganizationKey = Organization.OrganizationKey
	LEFT JOIN Payment ON RegistrantToLeague.RegistrantToLeagueKey = Payment.RegistrantToLeagueKey
	WHERE Season.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))
	AND
	(
		(@SeasonKey = 0)
		OR (
		((@SeasonKey > 0) AND (RegistrantToLeague.SeasonKey = @SeasonKey))
		)
	)


	-----------------------------------------------------
	---- Team Registrations
	-----------------------------------------------------
	INSERT INTO #Temp
	SELECT TeamName, CoachName, LeagueName, OrganizationName, ProgramName,
		RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate, PaymentAmount-Coalesce(PaymentTeam.ConvenienceFee,0), PaymentTeam.ConvenienceFee
	FROM PaymentTeam
	LEFT JOIN Team ON PaymentTeam.TeamKey = Team.TeamKey
	LEFT JOIN TeamToCoach ON Team.TeamKey = TeamToCoach.TeamKey
	LEFT JOIN League ON Team.LeagueKey = League.LeagueKey
	LEFT JOIN Season ON League.SeasonKey = Season.SeasonKey
	LEFT JOIN Organization ON Season.OrganizationKey = Organization.OrganizationKey
	WHERE Season.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))
	AND
	(
		(@SeasonKey = 0)
		OR (
		((@SeasonKey > 0) AND (League.SeasonKey = @SeasonKey))
		)
	)


	-----------------------------------------------------
	---- Merchandise
	-----------------------------------------------------
	IF @SeasonKey = 0
	BEGIN
		INSERT INTO #Temp
		SELECT InventoryItemName, ChargedTo, null, OrganizationName, 'Merchandise', RegistrationNbr, ConfirmationNbr,
			PaymentType, PaymentDate, PaymentAmount, ConvenienceFee
		FROM PaymentMerchandise
		LEFT JOIN Organization ON PaymentMerchandise.OrganizationKey = Organization.OrganizationKey
		WHERE PaymentMerchandise.OrganizationKey = @OrganizationKey
		AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
		AND Upper(ConfirmationNbr) <> 'DECLINED'
		and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))
	END


	-------------------------------------------------
	-- Vendor
	-------------------------------------------------
	INSERT INTO #Temp
	SELECT VendorName, VendorContactName, ChargeItemDescription, OrganizationName, 'Vendor',
		RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate, PaymentAmount - coalesce(conveniencefee,0),
		ConvenienceFee
	FROM PaymentVendor
	LEFT JOIN Vendor ON PaymentVendor.VendorKey = Vendor.VendorKey
	LEFT JOIN Organization ON Vendor.OrganizationKey = Organization.OrganizationKey
	LEFT JOIN VendorChargeItem ON PaymentVendor.VendorChargeItemKey = VendorChargeItem.VendorChargeItemKey
	WHERE Vendor.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))

	-- vendor refunds
	INSERT INTO #Temp
	SELECT VendorName, VendorContactName, ChargeItemDescription, OrganizationName, 'Vendor',
		RefundInformation, null, RefundPaymentType, DateOfRefund, RefundAmount, ConvenienceFee
	FROM PaymentVendor
	LEFT JOIN Vendor ON PaymentVendor.VendorKey = Vendor.VendorKey
	LEFT JOIN Organization ON Vendor.OrganizationKey = Organization.OrganizationKey
	LEFT JOIN VendorChargeItem ON PaymentVendor.VendorChargeItemKey = VendorChargeItem.VendorChargeItemKey
	WHERE Vendor.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) = 'REFUND'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))


	-------------------------------------------------
	-- POS
	-------------------------------------------------
	IF @POSScreenName = 'pos.aspx'
	BEGIN
		INSERT INTO #Temp
		SELECT CustomerName, null, CategoryName, OrganizationName,
			'POS', RegistrationNbr,	ConfirmationNbr, PaymentType, PaymentDate,
			POSTransactionItem.TotalDue - Coalesce(POSTransactionItem.ConvenienceFeeAmount,0), POSTransactionItem.ConvenienceFeeAmount
		FROM POSTransactionPayment
		INNER JOIN POSTransaction ON POSTransactionPayment.POSTransactionKey = POSTransaction.POSTransactionKey
		INNER JOIN POSTransactionItem ON POSTransactionItem.POSTransactionKey = POSTransaction.POSTransactionKey
		INNER JOIN POSItem on POSTransactionItem.POSItemKey = POSItem.POSItemKey
		INNER JOIN POSCategory ON POSItem.POSCategoryKey = POSCategory.POSCategoryKey
		INNER JOIN organization on POSTransaction.organizationkey = organization.organizationkey
		WHERE POSTransaction.OrganizationKey = @OrganizationKey
		AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
		AND Upper(ConfirmationNbr) <> 'DECLINED'
		and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))
	END


	-------------------------------------------------
	-- POS REGISTER
	-------------------------------------------------
	IF @POSScreenName = 'posregister.aspx'
	BEGIN
		-- Original sale line items (POSTransactionItem is never adjusted when a refund is issued,
		-- so this is always the item's full original amount).
		INSERT INTO #Temp
		SELECT ti.CustomerName, null, ppc.ProductCategoryName, o.OrganizationName,
			'POS', p.RegistrationNbr,	p.ConfirmationNbr, p.PaymentType, p.PaymentDate,
			ti.TotalDue - Coalesce(ti.ConvenienceFeeAmount,0), ti.ConvenienceFeeAmount
		FROM POSTransaction t
		INNER JOIN POSTransactionItem ti ON ti.POSTransactionKey = t.POSTransactionKey
		INNER JOIN (
			SELECT *, ROW_NUMBER() OVER (PARTITION BY POSTransactionKey ORDER BY PaymentAmount DESC, PaymentDate DESC, POSTransactionPaymentKey DESC) AS rn
			FROM POSTransactionPayment
			WHERE ISNULL(Upper(ConfirmationNbr),'') NOT IN ('REFUND','VOID')
		) p ON p.POSTransactionKey = t.POSTransactionKey AND p.rn = 1
		INNER JOIN POSProduct pp on ti.POSProductKey = pp.POSProductKey
		INNER JOIN POSProductCategory ppc ON pp.POSProductCategoryKey = ppc.POSProductCategoryKey
		INNER JOIN organization o on t.organizationkey = o.organizationkey
		WHERE t.OrganizationKey = @OrganizationKey
		AND Upper(p.PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
		AND t.TransactionStatus IN ('COMPLETED','REFUNDED')
		and (p.PaymentDate >=  @StartDate and p.PaymentDate < DATEADD(DAY,1,@EndDate))

		-- Refund lines, one row per POSTransactionRefundLine record (covers partial refunds,
		-- unlike the old TransactionStatus = 'REFUNDED' check), shown as a negative under the
		-- item's real product category instead of a generic 'Refund/Void' bucket.
		INSERT INTO #Temp
		SELECT ti.CustomerName, null, ppc.ProductCategoryName, o.OrganizationName,
			'POS', p.RegistrationNbr,	p.ConfirmationNbr, p.PaymentType, rl.DateTimeEntered,
			-(rl.SubtotalRefunded + rl.TaxRefunded), -rl.ConvenienceFeeRefunded
		FROM POSTransactionRefundLine rl
		INNER JOIN POSTransactionItem ti ON ti.TransactionItemId = rl.TransactionItemId
		INNER JOIN POSTransaction t ON t.POSTransactionKey = rl.POSTransactionKey
		INNER JOIN (
			SELECT *, ROW_NUMBER() OVER (PARTITION BY POSTransactionKey ORDER BY PaymentAmount DESC, PaymentDate DESC, POSTransactionPaymentKey DESC) AS rn
			FROM POSTransactionPayment
			WHERE ISNULL(Upper(ConfirmationNbr),'') NOT IN ('REFUND','VOID')
		) p ON p.POSTransactionKey = t.POSTransactionKey AND p.rn = 1
		INNER JOIN POSProduct pp on ti.POSProductKey = pp.POSProductKey
		INNER JOIN POSProductCategory ppc ON pp.POSProductCategoryKey = ppc.POSProductCategoryKey
		INNER JOIN organization o on t.organizationkey = o.organizationkey
		WHERE t.OrganizationKey = @OrganizationKey
		AND Upper(p.PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
		AND t.TransactionStatus IN ('COMPLETED','REFUNDED')
		and (rl.DateTimeEntered >=  @StartDate and rl.DateTimeEntered < DATEADD(DAY,1,@EndDate))
	END


	-------------------------------------------------
	-- Donations
	-------------------------------------------------
	INSERT INTO #Temp
	SELECT ContributorName, null, DonationItem, OrganizationName,
		'Donations', RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate,
		DonationAmount, ConvenienceFee
	FROM Donation
	LEFT JOIN DonationItem ON Donation.DonationItemKey = DonationItem.DonationItemKey
	LEFT JOIN organization on donation.organizationkey = organization.organizationkey
	WHERE donation.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))

	-------------------------------------------------
	-- Account Donation
	-------------------------------------------------
	INSERT INTO #Temp
	SELECT Account1First + ' ' + Account1Last, null, null, OrganizationName,
		'Scholarship Donation', RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate,
		DonationAmount, ConvenienceFee
	FROM AccountDonation
	LEFT JOIN AccountDonationAward ON AccountDonation.AccountDonationKey = AccountDonationAward.AccountDonationKey
	LEFT JOIN organization on AccountDonation.organizationkey = organization.organizationkey
	LEFT JOIN Account ON AccountDonation.AccountKey = Account.AccountKey
	WHERE AccountDonation.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))
	AND PaymentDate Is Not Null
	AND AwardedDate Is Null

	-------------------------------------------------
	-- Sponsors
	-------------------------------------------------
	INSERT INTO #Temp
	SELECT SponsorName, Sponsor.ContactName, null, OrganizationName,
		'Sponsorships', RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate,
		PaymentAmount - coalesce(conveniencefee,0), ConvenienceFee
	FROM PaymentSponsor
	LEFT JOIN Sponsor ON PaymentSponsor.SponsorKey = Sponsor.SponsorKey
	LEFT JOIN organization on Sponsor.organizationkey = organization.organizationkey
	WHERE Sponsor.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))

	-- sponsor refunds
	INSERT INTO #Temp
	SELECT SponsorName, Sponsor.ContactName, null, OrganizationName,
		'Sponsorships', '', RefundInformation, RefundPaymentType, DateOfRefund,
		RefundAmount, 0
	FROM PaymentSponsor
	LEFT JOIN Sponsor ON PaymentSponsor.SponsorKey = Sponsor.SponsorKey
	LEFT JOIN Organization ON Sponsor.OrganizationKey = Organization.OrganizationKey
	WHERE Sponsor.OrganizationKey = @OrganizationKey
	AND Upper(RefundPaymentType) IN ('VISA','MC','DISC', 'SWIPE','AMEX','EMV')
	and (DateOfRefund >=  @StartDate and DateOfRefund < DATEADD(DAY,1,@EndDate))

	-------------------------------------------------
	-- Special Events
	-------------------------------------------------
	INSERT INTO #Temp
	SELECT FirstName + ' ' + LastName, null, null, OrganizationName,
		EventName, RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate, PaymentAmount-coalesce(PaymentSpecialEvent.conveniencefee,0), PaymentSpecialEvent.ConvenienceFee
	FROM PaymentSpecialEvent
	LEFT JOIN SpecialEvent ON PaymentSpecialEvent.SpecialEventKey = SpecialEvent.SpecialEventKey
	LEFT JOIN organization on Specialevent.organizationkey = organization.organizationkey
	LEFT JOIN SpecialEventConfigure ON SpecialEvent.SpecialEventConfigureKey = SpecialEventConfigure.SpecialEventConfigureKey
	WHERE specialevent.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))


	-------------------------------------------------
	-- Memberships
	-------------------------------------------------
	INSERT INTO #Temp
	SELECT MemberFirstName + ' ' + MemberLastName, MemberFirstName + ' ' + MemberLastName, MembershipTypeDesc, OrganizationName,
		'Memberships', RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate,
		PaymentAmount - Coalesce(PaymentMembership.ConvenienceFee,0), PaymentMembership.ConvenienceFee
	FROM PaymentMembership
	LEFT JOIN MembershipDetail ON PaymentMembership.MembershipDetailKey = MembershipDetail.MembershipDetailKey
	LEFT JOIN Membership ON MembershipDetail.MembershipKey = Membership.MembershipKey
	LEFT JOIN organization on Membership.organizationkey = organization.organizationkey
	LEFT JOIN MembershipType ON MembershipDetail.MembershipTypeKey = MembershipType.MembershipTypeKey
	LEFT JOIN MembershipTypeDescription ON MembershipType.MembershipTypeDescKey = MembershipTYpeDescription.MembershipTypeDescKey
	WHERE Membership.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))


	-------------------------------------------------
	-- Facilities
	-------------------------------------------------
	INSERT INTO #Temp
	SELECT ApplicantName, null, FacilityName, OrganizationName,
		'Facility Rental', RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate,
		PaymentAmount-Coalesce(PaymentFacility.ConvenienceFee,0), PaymentFacility.ConvenienceFee
	FROM FacilityReservation
	LEFT JOIN PaymentFacility ON FacilityReservation.FacilityReservationKey = PaymentFacility.FacilityReservationKey
	LEFT JOIN FacilitySpace ON FacilityReservation.FacilitySpaceKey = FacilitySpace.FacilitySpaceKey
	LEFT JOIN organization on FacilityReservation.organizationkey = organization.organizationkey
	WHERE FacilityReservation.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))


	-------------------------------------------------------
	---- Season Pass
	-------------------------------------------------------
	INSERT INTO #Temp
	SELECT PassHolderFirstName + ' ' + PassHolderLastName, null, SeasonPassDescription, OrganizationName,
		'SeasonPass', RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate, PaymentAmount - PaymentSeasonPass.ConvenienceFee,
		PaymentSeasonPass.ConvenienceFee
	FROM SeasonPass
	LEFT JOIN SeasonPassSetup ON SeasonPass.SeasonPassSetupKey = SeasonPassSetup.SeasonPassSetupKey
	LEFT JOIN PaymentSeasonPass ON SeasonPass.SeasonPassKey = PaymentSeasonPass.SeasonPassKey
	LEFT JOIN Organization ON SeasonPass.OrganizationKey = Organization.OrganizationKey
	WHERE SeasonPass.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))


	-------------------------------------------------------
	---- Account Credit
	-------------------------------------------------------
	INSERT INTO #Temp
	SELECT Account1First + ' ' + Account1Last, null, null, OrganizationName,
		'Account Credit', RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate,
		CreditBalanceAmount, 0
		--PaymentAmount - Coalesce(ConvenienceFee,0), ConvenienceFee
	FROM AccountCredit
	LEFT JOIN Account ON AccountCredit.AccountKey = Account.AccountKey
	LEFT JOIN Organization ON Account.OrganizationKey = Organization.OrganizationKey
	WHERE Account.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))
	-- 1/7/25 added this. if give credit and use credit on same day, then it is reported twice
	-- believe that the creditbalanceamount must also be > 0
	and CreditBalanceAmount > 0

	-------------------------------------------------------
	---- Account Credit Return
	-------------------------------------------------------
	-- A card payment (Payment, PaymentFacility, or PaymentMembership) that was later
	-- refunded into account credit instead of back to the card has its origin row's
	-- PaymentAmount reduced by ReturnAmount + ConvenienceFee (or the origin row deleted outright for a
	-- full refund) - AccountCreditReturnSource is the only remaining record of that
	-- difference, so it has to be added back in here or the report understates what
	-- MX actually charged the card. OriginPaymentDate (the original swipe date), not
	-- ReturnDate, is what lines this up with the rest of the report. A handful of
	-- rows point at an AccountCreditLedgerHeaderKey that doesn't actually exist (a
	-- failed/retried credit operation) - the join to AccountCreditLedgerHeader
	-- excludes those since they never moved any money.
	INSERT INTO #Temp
	SELECT Account1First + ' ' + Account1Last, null, null, OrganizationName,
		'Account Credit Return', AccountCreditReturnSource.RegistrationNbr, AccountCreditReturnSource.ConfirmationNbr,
		AccountCreditReturnSource.PaymentType, AccountCreditReturnSource.OriginPaymentDate,
		AccountCreditReturnSource.ReturnAmount, AccountCreditReturnSource.ConvenienceFee
	FROM AccountCreditReturnSource
	INNER JOIN AccountCreditLedgerHeader ON AccountCreditReturnSource.AccountCreditLedgerHeaderKey = AccountCreditLedgerHeader.AccountCreditLedgerHeaderKey
	LEFT JOIN Account ON AccountCreditLedgerHeader.AccountKey = Account.AccountKey
	LEFT JOIN Organization ON AccountCreditReturnSource.OrganizationKey = Organization.OrganizationKey
	WHERE AccountCreditReturnSource.OrganizationKey = @OrganizationKey
	AND Upper(AccountCreditReturnSource.PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(Coalesce(AccountCreditReturnSource.ConfirmationNbr,'')) <> 'DECLINED'
	and (AccountCreditReturnSource.OriginPaymentDate >=  @StartDate and AccountCreditReturnSource.OriginPaymentDate < DATEADD(DAY,1,@EndDate))

	-------------------------------------------------------
	---- Tour Registration
	-------------------------------------------------------
	INSERT INTO #Temp
	SELECT '', FirstName + ' ' + LastName,
		TourTypeDescription, OrganizationName, TourTypeDescription, RegistrationNbr, ConfirmationNbr,
		PaymentType, PaymentDate, PaymentAmount-Coalesce(PaymentTourRegistration.ConvenienceFee,0), PaymentTourRegistration.ConvenienceFee
	FROM TourRegistration
	LEFT JOIN Organization ON TourRegistration.OrganizationKey = Organization.OrganizationKey
	LEFT JOIN PaymentTourRegistration ON PaymentTourRegistration.TourRegistrationKey = TourRegistration.TourRegistrationKey
	LEFT JOIN TourTypeItem ON TourRegistration.TourTypeItemKey = TourTypeItem.TourTypeItemKey
	LEFT JOIN TourType ON TourTypeItem.TourTypeKey = TourType.TourTypeKey
	WHERE TourRegistration.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))


	-------------------------------------------------------
	---- Locker Rental
	-------------------------------------------------------
	INSERT INTO #Temp
	SELECT RenterFirstName + ' ' + RenterLastName, null, LockerTypeName + ' - #' + convert(char,LockerNumber), OrganizationName,
		'LockerRental', RegistrationNbr, ConfirmationNbr, PaymentType, PaymentDate, PaymentAmount - plr.ConvenienceFee,
		plr.ConvenienceFee
	FROM LockerRental lr
	LEFT JOIN Locker l ON lr.LockerKey = l.LockerKey
	LEFT JOIN LockerType lt ON l.LockerTypeKey = lt.LockerTypeKey
	LEFT JOIN PaymentLockerRental plr ON lr.LockerRentalKey = plr.LockerRentalKey
	LEFT JOIN Organization ON lr.OrganizationKey = Organization.OrganizationKey
	WHERE lr.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (PaymentDate >=  @StartDate and PaymentDate < DATEADD(DAY,1,@EndDate))


	-------------------------------------------------------
	---- Daily Ticket
	-------------------------------------------------------
	INSERT INTO #Temp
	SELECT '', null, '', OrganizationName,
		'DailyTicket', RegistrationNbr, ConfirmationNbr, PaymentType, IssuedAt, PaymentAmount - dbt.ConvenienceFee,
		dbt.ConvenienceFee
	FROM DailyBarcodeTicket dbt
	LEFT JOIN Organization ON dbt.OrganizationKey = Organization.OrganizationKey
	WHERE dbt.OrganizationKey = @OrganizationKey
	AND Upper(PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
	AND Upper(ConfirmationNbr) <> 'DECLINED'
	and (IssuedAt >=  @StartDate and IssuedAt < DATEADD(DAY,1,@EndDate))
	AND POSTransactionKey Is Null

	SELECT * FROM #Temp
	ORDER BY LeagueName, ContactName

GO
