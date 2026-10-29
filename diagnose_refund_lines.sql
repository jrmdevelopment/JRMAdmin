-- Diagnostic: find exactly which join is dropping the 3 refund lines for
-- POSTransactionKey 25573 on 2026-07-02. Run this whole batch, then look at
-- which columns are NULL for each RefundLineId (73, 74, 102) in the final
-- result - that's the join responsible.

DECLARE @OrganizationKey int = 164;
DECLARE @StartDate datetime = '2026-07-02';
DECLARE @EndDate datetime = '2026-07-02';

SELECT
    rl.RefundLineId,
    rl.TransactionItemId,
    rl.POSTransactionKey,
    rl.DateTimeEntered,

    ti.TransactionItemId          AS ti_TransactionItemId,   -- NULL here => rl->ti join is the problem
    ti.POSProductKey              AS ti_POSProductKey,

    t.POSTransactionKey           AS t_POSTransactionKey,     -- NULL here => rl->t join is the problem
    t.OrganizationKey             AS t_OrganizationKey,
    t.TransactionStatus           AS t_TransactionStatus,

    p.POSTransactionPaymentKey    AS p_Key,                   -- NULL here => the rn=1 payment subquery is the problem
    p.RegistrationNbr             AS p_RegistrationNbr,
    p.PaymentType                 AS p_PaymentType,
    p.rn                          AS p_rn,

    pp.POSProductKey              AS pp_POSProductKey,        -- NULL here => POSProduct join is the problem
    pp.POSProductCategoryKey      AS pp_CategoryKey,

    ppc.POSProductCategoryKey     AS ppc_CategoryKey,         -- NULL here => POSProductCategory join is the problem (e.g. product has no/mismatched category)

    o.OrganizationKey             AS o_OrganizationKey        -- NULL here => organization join is the problem

FROM POSTransactionRefundLine rl
LEFT JOIN POSTransactionItem ti ON ti.TransactionItemId = rl.TransactionItemId
LEFT JOIN POSTransaction t ON t.POSTransactionKey = rl.POSTransactionKey
LEFT JOIN (
    SELECT *, ROW_NUMBER() OVER (PARTITION BY POSTransactionKey ORDER BY PaymentAmount DESC, PaymentDate DESC, POSTransactionPaymentKey DESC) AS rn
    FROM POSTransactionPayment
    WHERE ISNULL(Upper(ConfirmationNbr),'') NOT IN ('REFUND','VOID')
) p ON p.POSTransactionKey = t.POSTransactionKey AND p.rn = 1
LEFT JOIN POSProduct pp ON ti.POSProductKey = pp.POSProductKey
LEFT JOIN POSProductCategory ppc ON pp.POSProductCategoryKey = ppc.POSProductCategoryKey
LEFT JOIN organization o ON t.organizationkey = o.organizationkey
WHERE rl.POSTransactionKey = 25573;

-- Once you find the NULL column above, this confirms whether the WHERE clause
-- (the part that's still an inner-join-equivalent filter) is also a factor:
SELECT
    rl.RefundLineId,
    p.PaymentType,
    t.OrganizationKey,
    t.TransactionStatus,
    rl.DateTimeEntered,
    CASE WHEN Upper(p.PaymentType) IN ('VISA','MC','DISC','SWIPE','AMEX','EMV') THEN 'PASS' ELSE 'FAIL' END AS PaymentTypeFilter,
    CASE WHEN t.OrganizationKey = @OrganizationKey THEN 'PASS' ELSE 'FAIL' END AS OrgFilter,
    CASE WHEN t.TransactionStatus IN ('COMPLETED','REFUNDED') THEN 'PASS' ELSE 'FAIL' END AS StatusFilter,
    CASE WHEN rl.DateTimeEntered >= @StartDate AND rl.DateTimeEntered < DATEADD(DAY,1,@EndDate) THEN 'PASS' ELSE 'FAIL' END AS DateFilter
FROM POSTransactionRefundLine rl
LEFT JOIN POSTransaction t ON t.POSTransactionKey = rl.POSTransactionKey
LEFT JOIN (
    SELECT *, ROW_NUMBER() OVER (PARTITION BY POSTransactionKey ORDER BY PaymentAmount DESC, PaymentDate DESC, POSTransactionPaymentKey DESC) AS rn
    FROM POSTransactionPayment
    WHERE ISNULL(Upper(ConfirmationNbr),'') NOT IN ('REFUND','VOID')
) p ON p.POSTransactionKey = t.POSTransactionKey AND p.rn = 1
WHERE rl.POSTransactionKey = 25573;
