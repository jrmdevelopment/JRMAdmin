using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

/// <summary>
/// One sponsor payment row - a payment, a refund (ConfirmationNbr 'REFUND', negative amount)
/// or an NSF reversal (ConfirmationNbr 'NSF', negative amount). The pledge itself is
/// SponsorPledgeDetail (sponsor pledge multi-payment redesign, 2026-10). PaymentAmount
/// includes ConvenienceFee.
/// </summary>
public partial class PaymentSponsor
{
    public int PaymentSponsorKey { get; set; }

    public int SponsorPledgeDetailKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal ConvenienceFee { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentNotes { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public int? ShiftKey { get; set; }

    public string? MerchantBatchId { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public int? GroupId { get; set; }

    public string? PaymentToken { get; set; }

    public string? PaymentId { get; set; }

    public string? ValorTxnId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string? LastUpdatedBy { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public virtual SponsorPledgeDetail SponsorPledgeDetailKeyNavigation { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
