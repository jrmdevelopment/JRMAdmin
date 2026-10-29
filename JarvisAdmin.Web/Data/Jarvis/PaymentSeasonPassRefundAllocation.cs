using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentSeasonPassRefundAllocation
{
    public int RefundPaymentKey { get; set; }

    public int OriginalPaymentKey { get; set; }

    public decimal AmountRefunded { get; set; }

    public decimal ConvenienceFeeRefunded { get; set; }

    public virtual PaymentSeasonPass OriginalPaymentKeyNavigation { get; set; } = null!;

    public virtual PaymentSeasonPass RefundPaymentKeyNavigation { get; set; } = null!;
}
