using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RevenueCode
{
    public int RevenueCodeKey { get; set; }

    public int OrganizationKey { get; set; }

    public string RevenueCode1 { get; set; } = null!;

    public string RevenueCodeDescription { get; set; } = null!;

    public string BudgetCategory { get; set; } = null!;

    public string RevenueCodeStatus { get; set; } = null!;

    public string? Glaccount { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
