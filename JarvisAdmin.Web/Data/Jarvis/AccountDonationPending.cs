using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountDonationPending
{
    public int AccountDonationPendingKey { get; set; }

    public int? RegistrantToLeaguePendingKey { get; set; }

    public decimal DonationAmount { get; set; }

    public string? DonationRecipient { get; set; }

    public string? RevenueCode { get; set; }

    public int? AccountDonationKey { get; set; }

    public DateTime? DonationDate { get; set; }

    public int? AccountKey { get; set; }

    public virtual RegistrantToLeaguePending? RegistrantToLeaguePendingKeyNavigation { get; set; }
}
