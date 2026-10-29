using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentPo
{
    public int PaymentPoskey { get; set; }

    public int Poskey { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal SalesTax { get; set; }

    public decimal ConvenienceFee { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string? RevenueCode { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public int? ShiftKey { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public int? MerchantBatchId { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public virtual Po PoskeyNavigation { get; set; } = null!;
}
