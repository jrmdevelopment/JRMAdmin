using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Payment
{
    public int PaymentKey { get; set; }

    public int RegistrantToLeagueKey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public decimal? ConvenienceFee { get; set; }

    public int? ShiftKey { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentToken { get; set; }

    public string? ValorTxnId { get; set; }

    public string? RefundCheckName { get; set; }

    public string? RefundCheckAddress { get; set; }

    public string? RefundCheckCityStZip { get; set; }

    public virtual ICollection<PaymentRefundAllocation> PaymentRefundAllocationOriginalPaymentKeyNavigations { get; set; } = new List<PaymentRefundAllocation>();

    public virtual ICollection<PaymentRefundAllocation> PaymentRefundAllocationRefundPaymentKeyNavigations { get; set; } = new List<PaymentRefundAllocation>();

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
