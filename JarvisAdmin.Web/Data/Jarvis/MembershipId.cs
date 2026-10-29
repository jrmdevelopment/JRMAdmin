using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipId
{
    public int MembershipIdKey { get; set; }

    public int OrganizationKey { get; set; }

    public int MembershipId1 { get; set; }

    public int? MembershipKey { get; set; }

    public int? MembershipAddlPersonKey { get; set; }

    public string MembershipIdStatus { get; set; } = null!;

    public string? LastUpdatedBy { get; set; }

    public string? BarcodeNumber { get; set; }

    public virtual Membership? MembershipKeyNavigation { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
