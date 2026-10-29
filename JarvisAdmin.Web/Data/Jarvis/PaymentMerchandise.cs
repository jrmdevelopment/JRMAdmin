using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentMerchandise
{
    public int PaymentMerchandiseKey { get; set; }

    public int OrganizationKey { get; set; }

    public int InventoryItemKey { get; set; }

    public string InventoryItemName { get; set; } = null!;

    public string? InventoryItemSize { get; set; }

    public string? InventoryItemColor { get; set; }

    public int QuantityPurchased { get; set; }

    public decimal SalesPrice { get; set; }

    public string? RevenueCode { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string PaymentPostedBy { get; set; } = null!;

    public decimal? ConvenienceFee { get; set; }

    public int? ShiftKey { get; set; }

    public int? StatementKey { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public int? MerchantBatchId { get; set; }

    public bool HaveItem { get; set; }

    public string? ChargedTo { get; set; }

    public int GroupId { get; set; }

    public int? Refunded { get; set; }

    public decimal? Nsffee { get; set; }

    public string Nsfcheck { get; set; } = null!;

    public string? ContactNumber { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
