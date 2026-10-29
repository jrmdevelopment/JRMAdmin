using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PaymentLockerRentalRefundAllocation
{
    public int RefundPaymentKey { get; set; }

    public int OriginalPaymentKey { get; set; }

    public decimal AmountRefunded { get; set; }

    public decimal ConvenienceFeeRefunded { get; set; }

    public virtual PaymentLockerRental OriginalPaymentKeyNavigation { get; set; } = null!;

    public virtual PaymentLockerRental RefundPaymentKeyNavigation { get; set; } = null!;
}
