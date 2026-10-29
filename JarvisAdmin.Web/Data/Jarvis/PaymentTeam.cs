using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentTeam
{
    public int PaymentTeamKey { get; set; }

    public int TeamKey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public int? ShiftKey { get; set; }

    public int? StatementKey { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentToken { get; set; }

    public virtual Shift? ShiftKeyNavigation { get; set; }

    public virtual Team TeamKeyNavigation { get; set; } = null!;
}
