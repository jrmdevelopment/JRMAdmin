using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class DonationItemDropdown
{
    public int DonationItemDropdownKey { get; set; }

    public int DonationItemKey { get; set; }

    public decimal DonationDropdownText { get; set; }

    public virtual DonationItem DonationItemKeyNavigation { get; set; } = null!;
}
