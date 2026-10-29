using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditPaymentMembership
{
    public int AuditPaymentMembershipKey { get; set; }

    public int PaymentMembershipKey { get; set; }

    public int MembershipDetailKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal? PaymentAmount { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentNotes { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public string? PaymentToken { get; set; }

    public string? PaymentId { get; set; }

    public string? RevenueCode { get; set; }

    public int? ShiftKey { get; set; }

    public string? MerchantBatchId { get; set; }

    public int? StatementKey { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
