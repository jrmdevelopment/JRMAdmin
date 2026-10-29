using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentSeasonPass
{
    public int PaymentSeasonPassKey { get; set; }

    public int SeasonPassKey { get; set; }

    public string PaymentType { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// reference field from processor
    /// </summary>
    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public int? ShiftKey { get; set; }

    public string? RevenueCode { get; set; }

    public decimal ConvenienceFee { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string? PaymentComments { get; set; }

    public string? PaymentPostedBy { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentToken { get; set; }

    public int? RefundedPaymentSeasonPassKey { get; set; }

    public string? RefundCheckName { get; set; }

    public string? RefundCheckAddress { get; set; }

    public string? RefundCheckCityStZip { get; set; }

    public virtual ICollection<PaymentSeasonPassRefundAllocation> PaymentSeasonPassRefundAllocationOriginalPaymentKeyNavigations { get; set; } = new List<PaymentSeasonPassRefundAllocation>();

    public virtual ICollection<PaymentSeasonPassRefundAllocation> PaymentSeasonPassRefundAllocationRefundPaymentKeyNavigations { get; set; } = new List<PaymentSeasonPassRefundAllocation>();

    public virtual SeasonPass SeasonPassKeyNavigation { get; set; } = null!;

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
