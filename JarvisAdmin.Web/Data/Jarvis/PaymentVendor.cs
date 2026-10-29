using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentVendor
{
    public int PaymentVendorKey { get; set; }

    public int OrganizationKey { get; set; }

    public int VendorKey { get; set; }

    public int VendorChargeItemKey { get; set; }

    public decimal ChargeAmount { get; set; }

    public DateTime DateOfCharge { get; set; }

    public string? PaymentType { get; set; }

    public string? CheckNbr { get; set; }

    public decimal? PaymentAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentPostedBy { get; set; }

    public int? ShiftKey { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? VendorNotes { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string? PaymentNotes { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public DateTime? DateOfRefund { get; set; }

    public string? RefundedBy { get; set; }

    public decimal? RefundAmount { get; set; }

    public string? RefundInformation { get; set; }

    public int? RefundMerchantBatchId { get; set; }

    public string? RefundNotes { get; set; }

    public int? RefundShiftKey { get; set; }

    public string? RefundPaymentType { get; set; }

    public string? RevenueCode { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public virtual Shift? ShiftKeyNavigation { get; set; }

    public virtual Vendor VendorKeyNavigation { get; set; } = null!;
}
