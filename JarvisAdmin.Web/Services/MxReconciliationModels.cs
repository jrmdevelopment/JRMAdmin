namespace JarvisAdmin.Web.Services;

public record OrganizationOption(int OrganizationKey, string OrganizationName);

public record BatchOption(
    int MxmerchantBatchKey,
    int OrganizationKey,
    string OrganizationName,
    string BatchId,
    long? BatchNumber,
    DateTime? BatchOpenDate)
{
    public string DisplayLabel => $"{OrganizationName} - {BatchId} ({BatchOpenDate:MM/dd/yyyy h:mm tt})";
}

public record MxReconciliationFilter(
    IReadOnlyList<int> OrganizationKeys,
    DateOnly? Date,
    int? BatchKey);

public record BatchSummaryRow(
    int MxmerchantBatchKey,
    int OrganizationKey,
    string OrganizationName,
    string BatchId,
    long? BatchNumber,
    DateTime? BatchOpenDate,
    DateTime? BatchCloseDate,
    decimal MxmerchantAmount,
    decimal JarvisAmount,
    string? DiscrepancyComments)
{
    public decimal Variance => MxmerchantAmount - JarvisAmount;
}

internal record RegistrationNbrAmountRow(string RegistrationNbr, decimal Amount, string? MerchantBatchId);

public record VarianceRow(string ReferenceNbr, decimal? MxAmount, decimal? JarvisAmount);

public record BatchVarianceDetail(
    List<VarianceRow> MxOnly,
    List<VarianceRow> JarvisOnly,
    List<VarianceRow> Mismatched);

public record CreditCardBatchComparison(
    decimal MxTotal,
    decimal JarvisTotal,
    decimal MxPrincipalTotal,
    decimal MxFeeTotal,
    decimal JarvisPrincipalTotal,
    decimal JarvisFeeTotal,
    List<VarianceRow> MxOnly,
    List<VarianceRow> JarvisOnly,
    List<VarianceRow> Mismatched,
    List<SplitVarianceRow> SplitMismatched);

// A transaction where MX total and Jarvis total agree, but the principal/fee split between the two
// doesn't - invisible to the grand-total or Mismatched comparisons since the totals match.
public record SplitVarianceRow(
    string ReferenceNbr,
    decimal MxPrincipal,
    decimal MxFee,
    decimal JarvisPrincipal,
    decimal JarvisFee);

public class PaidByCreditCardRow
{
    public string? ParticipantName { get; set; }
    public string? ContactName { get; set; }
    public string? LeagueName { get; set; }
    public string OrganizationName { get; set; } = null!;
    public string? ProgramName { get; set; }
    public string? RegistrationNbr { get; set; }
    public string? ConfirmationNbr { get; set; }
    public string? PaymentType { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal? ConvenienceFee { get; set; }
}

public record ReferenceNbrDetailRow(
    string SourceTable,
    decimal PaymentAmount,
    string? ConfirmationNbr,
    string? MerchantBatchId,
    long? MerchantBatchIdNum,
    DateTime? PaymentDate);

public record BlankMerchantIdRow(
    string RowId,
    string SourceTable,
    string OrganizationName,
    string? RegistrationNbr,
    decimal Amount,
    DateTime? TransactionDate,
    string? PaymentType);

public record PosTransactionDetail(
    int PostransactionKey,
    int OrganizationKey,
    string? OrganizationName,
    int? PoslocationKey,
    string? LocationName,
    string TransactionStatus,
    DateTime DateTimeEntered,
    string EnteredByUser,
    decimal SubtotalAmount,
    decimal DiscountAmount,
    int? DiscountCodeKey,
    decimal TotalTaxAmount,
    decimal ConvenienceFee,
    decimal TotalDue,
    decimal TotalPaid,
    string? RefundReason,
    int? XOriginalTransactionId,
    List<PosTransactionItemRow> Items,
    List<PosTransactionPaymentRow> Payments,
    // Organization.MerchantPctToRegistrant - null or 0 means the organization charges no convenience fee.
    decimal? MerchantPctToRegistrant);

public record PosTransactionPaymentRow(
    int PostransactionPaymentKey,
    DateTime PaymentDate,
    decimal PaymentAmount,
    decimal? ConvenienceFee,
    string PaymentType,
    string? RegistrationNbr,
    string? ConfirmationNbr,
    int? ShiftKey,
    string PaymentPostedBy,
    string? PaymentNotes);

// The MX Merchant batch transaction(s) for a reference nbr - the source of the amount and
// authorization code when inserting a payment MX has but Jarvis doesn't.
public record MxBatchTxnRow(
    decimal Amount,
    string Authcode,
    string? PaymentId,
    DateTime DateAdded,
    long BatchId,
    string? TransactionStatus,
    // From the MxmerchantBatch it belongs to (same org, MxmerchantBatchTxn.BatchId = MxmerchantBatch.BatchNumber) -
    // the values stamped as a payment's MerchantBatchId / MerchantBatchIdNum.
    string? MerchantBatchId,
    long? MerchantBatchIdNum);

// A POSTransactionPayment row to record for an EMV payment MX has but Jarvis doesn't.
public record PosPaymentInsert(
    int PostransactionKey,
    int OrganizationKey,
    decimal PaymentAmount,
    decimal ConvenienceFee,
    DateTime PaymentDate,
    string RegistrationNbr,
    string ConfirmationNbr,
    int? ShiftKey,
    string? PaymentNotes,
    string? MerchantBatchId,
    long? MerchantBatchIdNum,
    string PostedBy);

public record ShiftOption(int ShiftKey, DateTime ShiftStartDate, DateTime? ShiftEndDate, string ShiftStartName);

public record PosTransactionItemRow(
    int TransactionItemId,
    string ItemDescription,
    string? CustomerName,
    int? PositemKey,
    int? PosproductKey,
    decimal UnitPrice,
    int Quantity,
    decimal SubtotalAmount,
    decimal ConvenienceFeeAmount,
    decimal TaxAmount,
    decimal TotalDue,
    string? RevenueCode,
    DateTime DateTimeAdded);
