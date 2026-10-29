using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class InvoiceHistory
{
    public int InvoiceHistoryKey { get; set; }

    public int OrganizationKey { get; set; }

    public int AccountKey { get; set; }

    public DateTime DateInvoiceSent { get; set; }

    public string InvoiceSentBy { get; set; } = null!;

    public decimal BalanceDue { get; set; }
}
