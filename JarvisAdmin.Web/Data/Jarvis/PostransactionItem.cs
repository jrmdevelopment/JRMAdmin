using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PostransactionItem
{
    public int TransactionItemId { get; set; }

    public int PostransactionKey { get; set; }

    public int? PositemKey { get; set; }

    public int? PosproductKey { get; set; }

    public string ItemDescription { get; set; } = null!;

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public decimal SubtotalAmount { get; set; }

    public decimal ConvenienceFeeAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal TotalDue { get; set; }

    public string? RevenueCode { get; set; }

    public string? CustomerName { get; set; }

    public DateTime DateTimeAdded { get; set; }

    public virtual Positem? PositemKeyNavigation { get; set; }

    public virtual Posproduct? PosproductKeyNavigation { get; set; }

    public virtual Postransaction PostransactionKeyNavigation { get; set; } = null!;
}
