using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PostransactionPayment
{
    public int PostransactionPaymentKey { get; set; }

    public int PostransactionKey { get; set; }

    public int? OrganizationKey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? ValorTxnId { get; set; }

    public string? CheckNbr { get; set; }

    public int? ShiftKey { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string? PaymentNotes { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? PaymentToken { get; set; }

    public string? PaymentId { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public virtual Postransaction PostransactionKeyNavigation { get; set; } = null!;

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
