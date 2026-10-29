using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditPaymentSponsor
{
    public int PaymentSponsorKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SponsorKey { get; set; }

    public int? SponsorPledgeTypeKey { get; set; }

    public decimal SponsorAmount { get; set; }

    public DateTime? SponsorshipExpiration { get; set; }

    public string? PersonSponsoring { get; set; }

    public string? ChildsAgeGroup { get; set; }

    public string? FirstChoiceUniformColor { get; set; }

    public string? SecondChoiceUniformColor { get; set; }

    public DateTime SponsorshipAdded { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? PaymentAmount { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string? PaymentType { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string? PaymentPostedBy { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public int? ShiftKey { get; set; }

    public string? MerchantBatchId { get; set; }

    public DateTime? DateOfRefund { get; set; }

    public string? RefundedBy { get; set; }

    public decimal? RefundAmount { get; set; }

    public string? RefundInformation { get; set; }

    public string? RefundMerchantBatchId { get; set; }

    public int? RefundShiftKey { get; set; }

    public string? RefundNotes { get; set; }

    public string? RefundPaymentType { get; set; }

    public string? RevenueCode { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
