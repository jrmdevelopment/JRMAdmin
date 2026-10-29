using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class DiscountCode
{
    public int DiscountCodeKey { get; set; }

    public int OrganizationKey { get; set; }

    public string DiscountCode1 { get; set; } = null!;

    public string DiscountCodeDesc { get; set; } = null!;

    public decimal? DiscountCodeAmount { get; set; }

    public decimal? DiscountCodePercentage { get; set; }

    public bool OneTimeUse { get; set; }

    public DateTime? DiscountStartDate { get; set; }

    public DateTime? DiscountEndDate { get; set; }

    public int? SeasonKey { get; set; }

    public string DiscountCodeStatus { get; set; } = null!;
}
