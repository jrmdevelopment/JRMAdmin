using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipCategory
{
    public int MembershipCategoryKey { get; set; }

    public int OrganizationKey { get; set; }

    public string MembershipCategory1 { get; set; } = null!;
}
