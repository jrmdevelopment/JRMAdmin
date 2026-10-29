using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PostransactionRefundLine
{
    public int RefundLineId { get; set; }

    public int PostransactionKey { get; set; }

    public int TransactionItemId { get; set; }

    public int QuantityRefunded { get; set; }

    public decimal SubtotalRefunded { get; set; }

    public decimal TaxRefunded { get; set; }

    public decimal ConvenienceFeeRefunded { get; set; }

    public decimal LineRefundTotal { get; set; }

    public DateTime DateTimeEntered { get; set; }

    public string EnteredByUser { get; set; } = null!;

    public virtual Postransaction PostransactionKeyNavigation { get; set; } = null!;
}
