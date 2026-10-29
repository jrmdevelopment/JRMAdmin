-- Diagnostic (read-only, does not alter rpt_paidbycreditcard): shows what the new
-- "Account Credit Return" section would add for a given org/date, so you can
-- confirm it accounts for the gap before deploying alter_rpt_paidbycreditcard.sql.

DECLARE @OrganizationKey int = 0; -- fill in
DECLARE @StartDate datetime = '2026-01-01'; -- fill in
DECLARE @EndDate datetime = '2026-01-01'; -- fill in

SELECT Account1First + ' ' + Account1Last AS AccountName,
	AccountCreditReturnSource.RegistrationNbr,
	AccountCreditReturnSource.ConfirmationNbr,
	AccountCreditReturnSource.PaymentType,
	AccountCreditReturnSource.OriginPaymentDate,
	AccountCreditReturnSource.ReturnDate,
	AccountCreditReturnSource.ReturnAmount,
	AccountCreditReturnSource.ConvenienceFee,
	AccountCreditReturnSource.ReturnAmount + Coalesce(AccountCreditReturnSource.ConvenienceFee, 0) AS TotalAdded,
	AccountCreditReturnSource.SourceTable,
	AccountCreditReturnSource.SourceTableKey,
	AccountCreditReturnSource.AccountCreditLedgerHeaderKey,
	CASE WHEN AccountCreditLedgerHeader.AccountCreditLedgerHeaderKey IS NULL THEN 'EXCLUDED - no real ledger header' ELSE 'INCLUDED' END AS LedgerCheck
FROM AccountCreditReturnSource
LEFT JOIN AccountCreditLedgerHeader ON AccountCreditReturnSource.AccountCreditLedgerHeaderKey = AccountCreditLedgerHeader.AccountCreditLedgerHeaderKey
LEFT JOIN Account ON AccountCreditLedgerHeader.AccountKey = Account.AccountKey
WHERE AccountCreditReturnSource.OrganizationKey = @OrganizationKey
AND Upper(AccountCreditReturnSource.PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
AND Upper(Coalesce(AccountCreditReturnSource.ConfirmationNbr,'')) <> 'DECLINED'
AND (AccountCreditReturnSource.OriginPaymentDate >= @StartDate AND AccountCreditReturnSource.OriginPaymentDate < DATEADD(DAY,1,@EndDate))
ORDER BY AccountCreditReturnSource.RegistrationNbr;

-- Sum of what this section would add to the report's credit card total:
SELECT SUM(ReturnAmount + Coalesce(ConvenienceFee, 0)) AS WouldAddToTotal
FROM AccountCreditReturnSource
INNER JOIN AccountCreditLedgerHeader ON AccountCreditReturnSource.AccountCreditLedgerHeaderKey = AccountCreditLedgerHeader.AccountCreditLedgerHeaderKey
WHERE AccountCreditReturnSource.OrganizationKey = @OrganizationKey
AND Upper(AccountCreditReturnSource.PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV')
AND Upper(Coalesce(AccountCreditReturnSource.ConfirmationNbr,'')) <> 'DECLINED'
AND (AccountCreditReturnSource.OriginPaymentDate >= @StartDate AND AccountCreditReturnSource.OriginPaymentDate < DATEADD(DAY,1,@EndDate));
