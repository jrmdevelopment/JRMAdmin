using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class DonationConfigure
{
    public int DonationConfigureKey { get; set; }

    public int OrganizationKey { get; set; }

    public string DonationPurpose { get; set; } = null!;

    public string? DonationDescription { get; set; }

    public string DonationStatus { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public string? RevenueCode { get; set; }

    public string? NotifyEmail { get; set; }

    public virtual ICollection<DonationItem> DonationItems { get; set; } = new List<DonationItem>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
