using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentLockerRental
{
    public int PaymentLockerRentalKey { get; set; }

    public int LockerRentalKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal ConvenienceFee { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? ValorTxnId { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public int? ShiftKey { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public int? GroupId { get; set; }

    public string? PaymentToken { get; set; }

    public string? PaymentId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string? RefundCheckName { get; set; }

    public string? RefundCheckAddress { get; set; }

    public string? RefundCheckCityStZip { get; set; }

    public virtual LockerRental LockerRentalKeyNavigation { get; set; } = null!;

    public virtual ICollection<PaymentLockerRentalRefundAllocation> PaymentLockerRentalRefundAllocationOriginalPaymentKeyNavigations { get; set; } = new List<PaymentLockerRentalRefundAllocation>();

    public virtual ICollection<PaymentLockerRentalRefundAllocation> PaymentLockerRentalRefundAllocationRefundPaymentKeyNavigations { get; set; } = new List<PaymentLockerRentalRefundAllocation>();

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
