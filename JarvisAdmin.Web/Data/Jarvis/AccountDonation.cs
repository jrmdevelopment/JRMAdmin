using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountDonation
{
    public int AccountDonationKey { get; set; }

    public int OrganizationKey { get; set; }

    public int AccountKey { get; set; }

    public DateTime DonationDate { get; set; }

    public decimal DonationAmount { get; set; }

    public decimal DonationBalanceRemaining { get; set; }

    public string? DonationRecipient { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentType { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? DonationComments { get; set; }

    public string? PaymentPostedBy { get; set; }

    public string? RevenueCode { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public int? ShiftKey { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public decimal? Nsffee { get; set; }

    public string? Nsfcheck { get; set; }

    public int? GroupId { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public int? RegistrantToLeagueKey { get; set; }

    /// <summary>
    /// R(eady) to Award, A(warded) in full, (I)nactive-not going to award
    /// </summary>
    public string? AccountDonationStatus { get; set; }

    public virtual ICollection<AccountDonationAward> AccountDonationAwards { get; set; } = new List<AccountDonationAward>();

    public virtual Account AccountKeyNavigation { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
