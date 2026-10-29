using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilitySpace
{
    public int FacilitySpaceKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? FacilityComplexKey { get; set; }

    public string? FacilityName { get; set; }

    public int? FacilityCategoryKey { get; set; }

    public string? FacilityAddress { get; set; }

    public int? CityKey { get; set; }

    public string? FacilityState { get; set; }

    public string? FacilityZipCode { get; set; }

    /// <summary>
    /// (A)ctive or (I)nactive. Inactive will not show up as a choice
    /// </summary>
    public string ActiveInactive { get; set; } = null!;

    /// <summary>
    /// (O)pen or (C)losed. This is only used for games/practices when closing/opening for weather or other issues where facility is temporarily unavailable
    /// </summary>
    public string? FacilityStatus { get; set; }

    public string? RevenueCode { get; set; }

    public string? DepositRevenueCode { get; set; }

    /// <summary>
    /// Could allow online reservation with no rates attached. Just have to reserve to use.
    /// </summary>
    public bool AllowToReserveOnline { get; set; }

    public bool GameFacility { get; set; }

    public bool PracticeFacility { get; set; }

    public bool ShowOnWebsite { get; set; }

    public string? DirectionsToFacility { get; set; }

    public string? MapLink { get; set; }

    public string LastUpdatedBy { get; set; } = null!;

    /// <summary>
    /// Should have rates attached.
    /// </summary>
    public bool? XRentalFacility { get; set; }

    public virtual ICollection<CustomQuestionFacility> CustomQuestionFacilities { get; set; } = new List<CustomQuestionFacility>();

    public virtual ICollection<FacilityAvailableHour> FacilityAvailableHours { get; set; } = new List<FacilityAvailableHour>();

    public virtual ICollection<FacilityOtherFee> FacilityOtherFees { get; set; } = new List<FacilityOtherFee>();

    public virtual ICollection<FacilityRate> FacilityRates { get; set; } = new List<FacilityRate>();

    public virtual ICollection<FacilityReservation> FacilityReservations { get; set; } = new List<FacilityReservation>();

    public virtual ICollection<FacilityShare> FacilityShares { get; set; } = new List<FacilityShare>();

    public virtual ICollection<FacilityTieredRate> FacilityTieredRates { get; set; } = new List<FacilityTieredRate>();

    public virtual ICollection<FacilityToSport> FacilityToSports { get; set; } = new List<FacilityToSport>();

    public virtual ICollection<XFacilityOwnerShare> XFacilityOwnerShares { get; set; } = new List<XFacilityOwnerShare>();
}
