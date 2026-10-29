using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditOnlineSession
{
    public string OnlineSessionId { get; set; } = null!;

    public int OrganizationKey { get; set; }

    public DateTime DateSessionAdded { get; set; }

    public int AccountKey { get; set; }

    public string SessionType { get; set; } = null!;

    public string? NameForLookup { get; set; }

    public string? OrganizationName { get; set; }

    public string? WebsiteDomainName { get; set; }

    public string? AccountHolderName { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
