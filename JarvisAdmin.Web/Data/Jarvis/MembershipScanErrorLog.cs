using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipScanErrorLog
{
    public int MembershipScanErrorLogKey { get; set; }

    public string Source { get; set; } = null!;

    public string ErrorMessage { get; set; } = null!;

    public string? BarcodeData { get; set; }

    public DateTime ErrorTime { get; set; }

    public string? Ipaddress { get; set; }
}
