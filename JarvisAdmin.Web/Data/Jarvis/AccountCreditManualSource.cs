using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountCreditManualSource
{
    public int AccountCreditManualSourceKey { get; set; }

    public int OrganizationKey { get; set; }

    public int AccountKey { get; set; }

    public string? CreditDescription { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string? PaymentType { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentToken { get; set; }

    public string? PaymentId { get; set; }

    public string? ValorTxnId { get; set; }

    public string? RevenueCode { get; set; }

    public string? PaymentComments { get; set; }

    public string? PaymentPostedBy { get; set; }

    public int? ShiftKey { get; set; }

    public string? CclastFour { get; set; }

    public string? Ccexpiration { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }
}
