using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipCheckin
{
    public int MembershipCheckInKey { get; set; }

    public int OrganizationKey { get; set; }

    public int MembershipKey { get; set; }

    public int? MembershipAddlPersonKey { get; set; }

    public string? MemberName { get; set; }

    public int MembershipId { get; set; }

    public DateTime CheckinDateTime { get; set; }

    public int? MembershipDetailKey { get; set; }

    /// <summary>
    /// Manual or Scan
    /// </summary>
    public string? CheckinSource { get; set; }
}
