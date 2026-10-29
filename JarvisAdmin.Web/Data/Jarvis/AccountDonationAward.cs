using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountDonationAward
{
    public int AccountDonationAwardKey { get; set; }

    public int AccountDonationKey { get; set; }

    public int AwardedAccount { get; set; }

    public DateTime AwardedDate { get; set; }

    public string AwardedBy { get; set; } = null!;

    public decimal AwardedAmount { get; set; }

    public virtual AccountDonation AccountDonationKeyNavigation { get; set; } = null!;

    public virtual Account AwardedAccountNavigation { get; set; } = null!;
}
