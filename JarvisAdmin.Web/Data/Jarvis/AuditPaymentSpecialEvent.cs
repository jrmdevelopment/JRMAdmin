using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditPaymentSpecialEvent
{
    public int PaymentSpecialEventKey { get; set; }

    public int SpecialEventKey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public decimal ConvenienceFee { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public int? ShiftKey { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? MerchantBatchId { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
