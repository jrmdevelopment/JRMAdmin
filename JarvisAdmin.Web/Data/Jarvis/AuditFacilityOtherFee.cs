using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditFacilityOtherFee
{
    public int AuditFacilityOtherFeeKey { get; set; }

    public int FacilityOtherFeeKey { get; set; }

    public int OrganizationKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public string OtherFeeDescription { get; set; } = null!;

    public decimal OtherFeeAmount { get; set; }

    public bool OrderMoreThanOne { get; set; }

    public string OtherFeeStatus { get; set; } = null!;

    public string FlatOrHourly { get; set; } = null!;

    public string? TimeFeeStarts { get; set; }

    public string OptionalOrRequired { get; set; } = null!;

    public string? OtherFeeDescriptionText { get; set; }

    public bool? TimeBased { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }

    public int? BlockFacilitySpaceKey { get; set; }
}
