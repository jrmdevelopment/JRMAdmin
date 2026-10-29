using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class DonationItem
{
    public int DonationItemKey { get; set; }

    public int DonationConfigureKey { get; set; }

    public string DonationItem1 { get; set; } = null!;

    public decimal? DonationItemAmount { get; set; }

    public string DonationItemStatus { get; set; } = null!;

    public string? DonationItemDesc { get; set; }

    public string AmountType { get; set; } = null!;

    public virtual DonationConfigure DonationConfigureKeyNavigation { get; set; } = null!;

    public virtual ICollection<DonationItemDropdown> DonationItemDropdowns { get; set; } = new List<DonationItemDropdown>();

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}
