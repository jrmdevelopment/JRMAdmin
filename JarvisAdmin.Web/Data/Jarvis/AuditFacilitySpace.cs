using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditFacilitySpace
{
    public int AuditFacilitySpaceKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? FacilityComplexKey { get; set; }

    public string? FacilityName { get; set; }

    public int? FacilityCategoryKey { get; set; }

    public string? FacilityAddress { get; set; }

    public int? CityKey { get; set; }

    public string? FacilityState { get; set; }

    public string? FacilityZipCode { get; set; }

    public string ActiveInactive { get; set; } = null!;

    public string? FacilityStatus { get; set; }

    public string? RevenueCode { get; set; }

    public string? DepositRevenueCode { get; set; }

    public bool AllowToReserveOnline { get; set; }

    public bool GameFacility { get; set; }

    public bool PracticeFacility { get; set; }

    public bool ShowOnWebsite { get; set; }

    public string? DirectionsToFacility { get; set; }

    public string LastUpdatedBy { get; set; } = null!;

    public bool? XRentalFacility { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
