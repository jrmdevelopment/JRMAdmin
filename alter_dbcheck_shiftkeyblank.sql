-- Run against the live database to deploy changes to dbcheck_ShiftKeyBlank:
--   1) Org 128 does not store ShiftKey on refund transactions, so blank-shiftkey
--      rows are only flagged for org 128 when ConfirmationNbr <> 'REFUND'.
--   2) Every block now excludes rows older than 30 days (rolling window), matching
--      the 30-day cutoff applied to the other Shift-area checks in DatabaseChecksService.
--   3) Field2 now returns the source table name instead of PaymentDate, so it's clear
--      which table DatabaseKey belongs to. PaymentDate is still tracked internally
--      (in the #TempPayments temp table only) so the Lansing cutover filter still works.
--   4) PaymentType = 'CREDIT' rows are paid from account credit, not a drawer, and
--      legitimately carry a null ShiftKey - excluded from every block.
-- jarvisdb.sql (schema reference dump) has already been updated to match.

ALTER PROCEDURE [dbo].[dbcheck_ShiftKeyBlank]

AS

	SET NOCOUNT ON;

	CREATE TABLE #TempPayments (OrganizationName varchar(50), SystemArea varchar(30), DatabaseCheck varchar(50), DatabaseKey int,
		Field1 varchar(50), Field2 varchar(50), PaymentDate date)

	-- brandon turns on and off so exclude from these checks
	-- hernando, eufaula does not add shift key on facility, team, program refunds
	-- horn lake does not add shift on program refunds
	-- trego does not add shift on program refunds

	-- individual registrations (not horn lake, trego)
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Individual Registrations', 'Blank ShiftKey', PaymentKey, RegistrantToLeague.RegistrantToLeagueKey,
		'Payment', PaymentDate
	FROM Payment
	LEFT JOIN RegistrantToLeague ON RegistrantToLeague.RegistrantToLeagueKey = Payment.RegistrantToLeagueKey
	LEFT JOIN Season ON RegistrantToLeague.SeasonKey = Season.SeasonKey
	LEFT JOIN Organization ON Season.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND Payment.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND Season.OrganizationKey Not In (32,75,136,55,149,103)
	AND (Season.OrganizationKey <> 128 OR coalesce(ConfirmationNbr,'') <> 'REFUND')
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	-- moved from scholarship donation and did not carry shift over; manual post that did not record shift
	-- refunds done manually in MXMerchant
	and paymentkey not in (649497,649498,648840,705922,705923,705924)
	AND PaymentDate >= '05/23/2024'
	AND Organization.Status = 'A'

	-- individual registrations (horn lake, trego)
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Individual Registrations', 'Blank ShiftKey', PaymentKey, RegistrantToLeague.RegistrantToLeagueKey,
		'Payment', PaymentDate
	FROM Payment
	LEFT JOIN RegistrantToLeague ON RegistrantToLeague.RegistrantToLeagueKey = Payment.RegistrantToLeagueKey
	LEFT JOIN Season ON RegistrantToLeague.SeasonKey = Season.SeasonKey
	LEFT JOIN Organization ON Season.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND Payment.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND (Season.OrganizationKey in (136,55, 103) AND coalesce(ConfirmationNbr,'') <> 'REFUND')
	AND PaymentDate >= '05/23/2024'
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	AND Organization.Status = 'A'

	-- team registrations (not hernando)
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Team Registrations', 'Blank ShiftKey', PaymentTeamKey, Team.TeamKey,
		'PaymentTeam', PaymentDate
	FROM PaymentTeam
	LEFT JOIN Team ON PaymentTeam.TeamKey = Team.TeamKey
	LEFT JOIN League ON Team.LeagueKey = League.LeagueKey
	LEFT JOIN Season ON League.SeasonKey = Season.SeasonKey
	LEFT JOIN Organization ON Season.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND PaymentTeam.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND Season.OrganizationKey Not In (32,75,55)
	AND (Season.OrganizationKey <> 128 OR coalesce(ConfirmationNbr,'') <> 'REFUND')
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	AND PaymentDate >= '10/11/2023'
	AND Organization.Status = 'A'

	-- team registrations (hernando)
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Team Registrations', 'Blank ShiftKey', PaymentTeamKey, Team.TeamKey,
		'PaymentTeam', PaymentDate
	FROM PaymentTeam
	LEFT JOIN Team ON PaymentTeam.TeamKey = Team.TeamKey
	LEFT JOIN League ON Team.LeagueKey = League.LeagueKey
	LEFT JOIN Season ON League.SeasonKey = Season.SeasonKey
	LEFT JOIN Organization ON Season.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND PaymentTeam.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND (Season.OrganizationKey = 55 AND coalesce(ConfirmationNbr,'') <> 'REFUND')
	AND PaymentDate >= '10/11/2023'
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	AND Organization.Status = 'A'

	-- facility reservations (not hernando)
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Facility Reservations', 'Blank ShiftKey', PaymentFacilityKey, FacilityReservation.FacilityReservationKey,
		'PaymentFacility', PaymentDate
	FROM PaymentFacility
	LEFT JOIN FacilityReservation ON PaymentFacility.FacilityReservationKey = FacilityReservation.FacilityReservationKey
	LEFT JOIN FacilityRates ON FacilityReservation.FacilitySpaceKey = FacilityRates.FacilitySpaceKey
	LEFT JOIN Organization ON FacilityReservation.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND PaymentFacility.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND FacilityReservation.OrganizationKey Not In (32,75,55,79,149)
	AND (FacilityReservation.OrganizationKey <> 128 OR coalesce(ConfirmationNbr,'') <> 'REFUND')
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	AND ConfirmationNbr <> 'VOID'
	AND PaymentDate >= '04/09/2024'
	AND Organization.Status = 'A'

	-- facility reservations - hernando, eufaula excluding refunds
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Facility Reservations', 'Blank ShiftKey', PaymentFacilityKey, FacilityReservation.FacilityReservationKey,
		'PaymentFacility', PaymentDate
	FROM PaymentFacility
	LEFT JOIN FacilityReservation ON PaymentFacility.FacilityReservationKey = FacilityReservation.FacilityReservationKey
	LEFT JOIN FacilityRates ON FacilityReservation.FacilitySpaceKey = FacilityRates.FacilitySpaceKey
	LEFT JOIN Organization ON FacilityReservation.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND PaymentFacility.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND ((FacilityReservation.OrganizationKey = 55 AND coalesce(ConfirmationNbr,'') <> 'REFUND')
		OR (FacilityReservation.OrganizationKey = 79 AND coalesce(ConfirmationNbr,'') <> 'REFUND'))
	AND PaymentDate >= '04/09/2024'
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	AND Organization.Status = 'A'

	-- account donations
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Scholarship Donations', 'Blank ShiftKey', AccountDonationKey, null,
		'AccountDonation', PaymentDate
	FROM AccountDonation
	LEFT JOIN Organization ON AccountDonation.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND AccountDonation.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND AccountDonation.OrganizationKey Not In (32,75)
	AND (AccountDonation.OrganizationKey <> 128 OR coalesce(ConfirmationNbr,'') <> 'REFUND')
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	AND PaymentDate >= '10/01/2025'
	AND Organization.Status = 'A'

	-- memberships
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Memberships', 'Blank ShiftKey', PaymentMembershipKey, MembershipDetail.MembershipDetailKey,
		'PaymentMembership', PaymentDate
	FROM PaymentMembership
	LEFT JOIN MembershipDetail ON PaymentMembership.MembershipDetailKey = MembershipDetail.MembershipDetailKey
	LEFT JOIN Membership ON MembershipDetail.MembershipKey = Membership.MembershipKey
	LEFT JOIN Organization ON Membership.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND PaymentMembership.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND Membership.OrganizationKey Not In (32,75)
	AND (Membership.OrganizationKey <> 128 OR coalesce(ConfirmationNbr,'') <> 'REFUND')
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	-- check for Eufaula
	AND (CheckNbr Is Null OR CheckNbr <> 'Bank Draft')
	and (paymenttype <> 'SCH')
	AND PaymentDate >= '01/01/2024'
	AND Organization.Status = 'A'

	-- season passes
	INSERT INTO #TempPayments
	SELECT OrganizationName, 'Season Pass', 'Blank ShiftKey', PaymentSeasonPassKey, SeasonPass.SeasonPassKey,
		'PaymentSeasonPass', PaymentDate
	FROM PaymentSeasonPass
	LEFT JOIN SeasonPass ON SeasonPass.SeasonPassKey = PaymentSeasonPass.SeasonPassKey
	LEFT JOIN Organization ON SeasonPass.OrganizationKey = Organization.OrganizationKey
	WHERE UseShifts = 1
	AND PaymentSeasonPass.ShiftKey Is Null
	AND coalesce(PaymentType,'') <> 'CREDIT'
	AND SeasonPass.OrganizationKey Not In (32,75)
	AND (SeasonPass.OrganizationKey <> 128 OR coalesce(ConfirmationNbr,'') <> 'REFUND')
	AND PaymentDate >= DATEADD(day, -30, GETDATE())
	AND PaymentDate >= '01/01/2023'
	AND Organization.Status = 'A'


	-- Lansing did not start shifts until mid-may
	DELETE FROM #TempPayments
	WHERE OrganizationName = 'Lansing Parks & Recreation'
		AND PaymentDate < '2026-05-20';


	SELECT OrganizationName, SystemArea, DatabaseCheck, DatabaseKey, Field1, Field2
	FROM #TempPayments
	ORDER BY Field1
GO
