using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditMembershipId
{
    public int AuditMembershipIdKey { get; set; }

    public int MembershipIdKey { get; set; }

    public int OrganizationKey { get; set; }

    public int MembershipId { get; set; }

    public int? MembershipKey { get; set; }

    public string MembershipIdStatus { get; set; } = null!;

    public string? AuditUser { get; set; }

    public DateTime AuditTimestamp { get; set; }

    public string AuditAction { get; set; } = null!;
}
