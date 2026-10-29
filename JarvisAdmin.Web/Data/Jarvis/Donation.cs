using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Donation
{
    public int DonationKey { get; set; }

    public int OrganizationKey { get; set; }

    public int DonationItemKey { get; set; }

    public string ContributorName { get; set; } = null!;

    public string ContributorAddress { get; set; } = null!;

    public string ContributorCity { get; set; } = null!;

    public string ContributorState { get; set; } = null!;

    public string ContributorZip { get; set; } = null!;

    public string ContributorEmail { get; set; } = null!;

    public string ContributorPhone { get; set; } = null!;

    public DateTime DonationDate { get; set; }

    public decimal DonationAmount { get; set; }

    public string DonationPostedBy { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public decimal? PaymentAmount { get; set; }

    public string? PaymentType { get; set; }

    public string? RegistrationNbr { get; set; }

    public string? ConfirmationNbr { get; set; }

    public string? CheckNbr { get; set; }

    public string? PaymentComments { get; set; }

    public string? PaymentPostedBy { get; set; }

    public string? Nsfcheck { get; set; }

    public decimal? Nsffee { get; set; }

    public string? RevenueCode { get; set; }

    public decimal? ConvenienceFee { get; set; }

    public int? ShiftKey { get; set; }

    public string? MerchantBatchId { get; set; }

    public long? MerchantBatchIdNum { get; set; }

    public int? GroupId { get; set; }

    public string? OrganizationComments { get; set; }

    public DateTime? PaymentReleaseDate { get; set; }

    public byte[]? CclastFour { get; set; }

    public byte[]? Ccexpiration { get; set; }

    public virtual DonationItem DonationItemKeyNavigation { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual Shift? ShiftKeyNavigation { get; set; }
}
