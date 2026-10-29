using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class DailyBarcodeTicket
{
    public int DailyBarcodeTicketKey { get; set; }

    public int OrganizationKey { get; set; }

    public string DailyBarcode { get; set; } = null!;

    public DateTime IssuedAt { get; set; }

    public DateTime? UsedAt { get; set; }

    public bool IsUsed { get; set; }

    public string? EmailAddress { get; set; }

    public decimal? PaymentAmount { get; set; }

    public string? PaymentType { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? RevenueCode { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public int? ShiftKey { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public int? GroupId { get; set; }

    public string? CountyResideIn { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentToken { get; set; }

    public int? PostransactionKey { get; set; }

    public string? PosproductLabel { get; set; }

    /// <summary>
    /// Online, POS
    /// </summary>
    public string? SourceOfPurchase { get; set; }
}
