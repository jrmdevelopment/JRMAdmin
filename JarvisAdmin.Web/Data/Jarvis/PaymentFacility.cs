using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentFacility
{
    public int PaymentFacilityKey { get; set; }

    public int FacilityReservationKey { get; set; }

    public string PaymentType { get; set; } = null!;

    public decimal PaymentAmount { get; set; }

    public DateTime PaymentDate { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public int? ShiftKey { get; set; }

    public string? RevenueCode { get; set; }

    public decimal ConvenienceFee { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string? PaymentComments { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public string? PaymentId { get; set; }

    public string? PaymentToken { get; set; }

    public string? ValorTxnId { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public int? GroupId { get; set; }

    public bool SecurityDepositPayment { get; set; }

    public bool SecurityDepositRefund { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public virtual FacilityReservation FacilityReservationKeyNavigation { get; set; } = null!;

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
