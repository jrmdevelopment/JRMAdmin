using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipScanLog
{
    public int MembershipScanLogKey { get; set; }

    public int? MembershipKey { get; set; }

    public string BarcodeData { get; set; } = null!;

    public DateTime ScanTime { get; set; }

    public bool Success { get; set; }

    public string? Ipaddress { get; set; }

    public string? UserAgent { get; set; }

    public virtual Membership? MembershipKeyNavigation { get; set; }
}
