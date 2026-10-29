using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class EmailBounceLog
{
    public int EmailBounceLogKey { get; set; }

    public int OrganizationKey { get; set; }

    public string BounceType { get; set; } = null!;

    public string BounceEmailAddress { get; set; } = null!;

    public string? BounceMessage { get; set; }

    public DateTime DateAdded { get; set; }

    public string? EmailData { get; set; }

    public DateTime? SendgridVerified { get; set; }

    public string? FullBounceReason { get; set; }
}
