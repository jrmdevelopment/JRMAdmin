using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Postransaction
{
    public int PostransactionKey { get; set; }

    public int OrganizationKey { get; set; }

    public decimal SubtotalAmount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public decimal ConvenienceFee { get; set; }

    public decimal TotalDue { get; set; }

    public decimal TotalPaid { get; set; }

    public string TransactionStatus { get; set; } = null!;

    public DateTime DateTimeEntered { get; set; }

    public string EnteredByUser { get; set; } = null!;

    public int? PoslocationKey { get; set; }

    public int? DiscountCodeKey { get; set; }

    public decimal DiscountAmount { get; set; }

    public string? RefundReason { get; set; }

    public int? XOriginalTransactionId { get; set; }

    public virtual ICollection<PostransactionItem> PostransactionItems { get; set; } = new List<PostransactionItem>();

    public virtual ICollection<PostransactionPayment> PostransactionPayments { get; set; } = new List<PostransactionPayment>();

    public virtual ICollection<PostransactionRefundLine> PostransactionRefundLines { get; set; } = new List<PostransactionRefundLine>();
}
