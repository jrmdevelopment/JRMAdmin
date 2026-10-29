using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Vendor
{
    public int VendorKey { get; set; }

    public int OrganizationKey { get; set; }

    public string VendorName { get; set; } = null!;

    public string? VendorAddress { get; set; }

    public string? VendorCity { get; set; }

    public string? VendorState { get; set; }

    public string? VendorZip { get; set; }

    public string? VendorDescription { get; set; }

    public string VendorStatus { get; set; } = null!;

    public string? VendorContactName { get; set; }

    public string? VendorContactPhone { get; set; }

    public string? VendorEmail { get; set; }

    public DateTime? ReminderEmailSent { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<PaymentVendor> PaymentVendors { get; set; } = new List<PaymentVendor>();

    public virtual ICollection<VendorChargeItem> VendorChargeItems { get; set; } = new List<VendorChargeItem>();
}
