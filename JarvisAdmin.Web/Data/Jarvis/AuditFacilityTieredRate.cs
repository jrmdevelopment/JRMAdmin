using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditFacilityTieredRate
{
    public int AuditFacilityTieredRatesKey { get; set; }

    public int FacilityTieredRatesKey { get; set; }

    public int OrganizationKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public int MinimumNumber { get; set; }

    public int MaximumNumber { get; set; }

    public decimal AdditionalFee { get; set; }

    public string FacilityTieredRatesStatus { get; set; } = null!;

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
