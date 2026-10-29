using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditAdditionalCost
{
    public int AuditAdditionalCostKey { get; set; }

    public int AdditionalCostKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SeasonKey { get; set; }

    public string ItemDescription { get; set; } = null!;

    public decimal PricePerUnit { get; set; }

    public int DisplayOrder { get; set; }

    public string ItemStatus { get; set; } = null!;

    public bool ItemRequired { get; set; }

    public bool SizeManual { get; set; }

    public bool ShowOnRegistrationForm { get; set; }

    public bool OrderMoreThan1 { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
