using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentMembershipRefundAllocation
{
    public int RefundPaymentKey { get; set; }

    public int OriginalPaymentKey { get; set; }

    public decimal AmountRefunded { get; set; }

    public decimal ConvenienceFeeRefunded { get; set; }

    public virtual PaymentMembership OriginalPaymentKeyNavigation { get; set; } = null!;

    public virtual PaymentMembership RefundPaymentKeyNavigation { get; set; } = null!;
}
