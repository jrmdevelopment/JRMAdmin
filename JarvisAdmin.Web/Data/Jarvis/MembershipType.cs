using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipType
{
    public int MembershipTypeKey { get; set; }

    public int OrganizationKey { get; set; }

    public int MembershipTypeDescKey { get; set; }

    public string MembershipPeriod { get; set; } = null!;

    public decimal MembershipAmount { get; set; }

    public string MembershipTypeStatus { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public int NbrAllowedOnMembership { get; set; }

    public decimal? AddlPersonPrice { get; set; }

    public bool OnlineRenewal { get; set; }

    public int? NbrOfVisits { get; set; }

    public virtual ICollection<MembershipDetail> MembershipDetails { get; set; } = new List<MembershipDetail>();

    public virtual MembershipTypeDescription MembershipTypeDescKeyNavigation { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
