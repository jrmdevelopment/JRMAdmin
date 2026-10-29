using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipVisit
{
    public int MembershipVisitKey { get; set; }

    public int OrganizationKey { get; set; }

    public int MembershipDetailKey { get; set; }

    public DateTime VisitDate { get; set; }
}
