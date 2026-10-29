using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentRefundAllocation
{
    public int RefundPaymentKey { get; set; }

    public int OriginalPaymentKey { get; set; }

    public decimal AmountRefunded { get; set; }

    public decimal ConvenienceFeeRefunded { get; set; }

    public virtual Payment OriginalPaymentKeyNavigation { get; set; } = null!;

    public virtual Payment RefundPaymentKeyNavigation { get; set; } = null!;
}
