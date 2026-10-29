using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentTourRefundAllocation
{
    public int RefundPaymentKey { get; set; }

    public int OriginalPaymentKey { get; set; }

    public decimal AmountRefunded { get; set; }

    public virtual PaymentTourRegistration OriginalPaymentKeyNavigation { get; set; } = null!;

    public virtual PaymentTourRegistration RefundPaymentKeyNavigation { get; set; } = null!;
}
