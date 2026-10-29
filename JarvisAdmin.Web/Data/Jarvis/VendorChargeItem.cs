using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class VendorChargeItem
{
    public int VendorChargeItemKey { get; set; }

    public int VendorKey { get; set; }

    public string ChargeItemDescription { get; set; } = null!;

    public decimal? ChargeAmount { get; set; }

    public string ChargeItemStatus { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public virtual Vendor VendorKeyNavigation { get; set; } = null!;
}
