using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

/// <summary>
/// A sponsor pledge (sponsor pledge multi-payment redesign, 2026-10). Its payments, refunds and
/// NSF reversals are PaymentSponsor rows. BalanceDue = SponsorAmount + NSF fees - PledgePaid,
/// where PledgePaid = SUM(PaymentAmount - ConvenienceFee) over the non-'Declined' rows.
/// </summary>
public partial class SponsorPledgeDetail
{
    public int SponsorPledgeDetailKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SponsorKey { get; set; }

    public int? SponsorPledgeTypeKey { get; set; }

    public decimal SponsorAmount { get; set; }

    public DateTime? SponsorshipExpiration { get; set; }

    public string? PersonSponsoring { get; set; }

    public string? ChildsAgeGroup { get; set; }

    public string? FirstChoiceUniformColor { get; set; }

    public string? SecondChoiceUniformColor { get; set; }

    public string? RevenueCode { get; set; }

    public DateTime SponsorshipAdded { get; set; }

    public string? AddedBy { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual Sponsor SponsorKeyNavigation { get; set; } = null!;

    public virtual SponsorPledgeType? SponsorPledgeTypeKeyNavigation { get; set; }

    public virtual ICollection<PaymentSponsor> PaymentSponsors { get; set; } = new List<PaymentSponsor>();
}
