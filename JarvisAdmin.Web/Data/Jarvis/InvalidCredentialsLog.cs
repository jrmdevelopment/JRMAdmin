using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class InvalidCredentialsLog
{
    public int InvalidCredentialsLogId { get; set; }

    public int? OrganizationKey { get; set; }

    public string UserName { get; set; } = null!;

    public bool? IsApproved { get; set; }

    public bool? IsLockedOut { get; set; }

    public string? Ipaddress { get; set; }

    public DateTime LoginAttemptDate { get; set; }

    public string? FailureReason { get; set; }
}
