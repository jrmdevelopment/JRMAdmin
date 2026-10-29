using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipTypeDescription
{
    public int MembershipTypeDescKey { get; set; }

    public int OrganizationKey { get; set; }

    public string MembershipTypeDesc { get; set; } = null!;

    public string MembershipTypeStatus { get; set; } = null!;

    public int? MembershipCategoryKey { get; set; }

    public bool BankDraftEligible { get; set; }

    public bool RecurringBillingEligible { get; set; }

    public bool RenewalOnly { get; set; }

    public bool RecurringOnly { get; set; }

    public virtual ICollection<MembershipType> MembershipTypes { get; set; } = new List<MembershipType>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
