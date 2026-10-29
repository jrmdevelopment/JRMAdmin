using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentTourRegistration
{
    public int PaymentTourRegistrationKey { get; set; }

    public int TourRegistrationKey { get; set; }

    public string? CardFirstName { get; set; }

    public string? CardLastName { get; set; }

    public string? CardAddress { get; set; }

    public string? CardCity { get; set; }

    public string? CardState { get; set; }

    public string? CardZipCode { get; set; }

    public DateTime PaymentDate { get; set; }

    public string PaymentType { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public decimal ConvenienceFee { get; set; }

    public decimal SalesTax { get; set; }

    public string? PaymentComments { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? RevenueCode { get; set; }

    public int? ShiftKey { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentToken { get; set; }

    public int? GroupId { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public string? LastUpdatedBy { get; set; }

    public virtual ICollection<PaymentTourRefundAllocation> PaymentTourRefundAllocationOriginalPaymentKeyNavigations { get; set; } = new List<PaymentTourRefundAllocation>();

    public virtual ICollection<PaymentTourRefundAllocation> PaymentTourRefundAllocationRefundPaymentKeyNavigations { get; set; } = new List<PaymentTourRefundAllocation>();

    public virtual TourRegistration TourRegistrationKeyNavigation { get; set; } = null!;
}
