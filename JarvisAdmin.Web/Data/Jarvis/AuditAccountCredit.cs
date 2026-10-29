using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAccountCredit
{
    public int AuditAccountCreditKey { get; set; }

    public int AccountCreditKey { get; set; }

    public int AccountKey { get; set; }

    public decimal CreditBalanceAmount { get; set; }

    public string? CreditSource { get; set; }

    public string? CreditDescription { get; set; }

    public string? RevenueCode { get; set; }

    public DateTime? DateCreditGiven { get; set; }

    public bool CreditApproved { get; set; }

    public string? CreditApprovedBy { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? PaymentAmount { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string? PaymentType { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? PaymentPostedBy { get; set; }

    public int? ShiftKey { get; set; }

    public int? Refunded { get; set; }

    public bool Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string? MerchantBatchId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }

    public string? PaymentComments { get; set; }

    public int? TableKey { get; set; }

    public int? GroupId { get; set; }
}
