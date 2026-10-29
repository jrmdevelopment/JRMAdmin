using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityReservationOtherFee
{
    public int FacilityReservationOtherFeesKey { get; set; }

    public int FacilityReservationKey { get; set; }

    public int? FacilityOtherFeeKey { get; set; }

    public decimal OtherFeeAmount { get; set; }

    public string? TimeFeeStarts { get; set; }

    public int? OtherFeeQuantity { get; set; }

    public string? OptionalOrRequiredStatus { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual FacilityOtherFee? FacilityOtherFeeKeyNavigation { get; set; }

    public virtual FacilityReservation FacilityReservationKeyNavigation { get; set; } = null!;
}
