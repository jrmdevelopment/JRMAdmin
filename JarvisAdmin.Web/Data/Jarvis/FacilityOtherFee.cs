using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityOtherFee
{
    public int FacilityOtherFeeKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? FacilitySpaceKey { get; set; }

    public string OtherFeeDescription { get; set; } = null!;

    public decimal OtherFeeAmount { get; set; }

    public bool OrderMoreThanOne { get; set; }

    public string OtherFeeStatus { get; set; } = null!;

    public string FlatOrHourly { get; set; } = null!;

    public string? TimeFeeStarts { get; set; }

    public string OptionalOrRequired { get; set; } = null!;

    public string? OtherFeeDescriptionText { get; set; }

    public bool? TimeBased { get; set; }

    public string? LastUpdatedBy { get; set; }

    public int? BlockFacilitySpaceKey { get; set; }

    public virtual ICollection<FacilityReservationOtherFee> FacilityReservationOtherFees { get; set; } = new List<FacilityReservationOtherFee>();

    public virtual FacilitySpace? FacilitySpaceKeyNavigation { get; set; }
}
