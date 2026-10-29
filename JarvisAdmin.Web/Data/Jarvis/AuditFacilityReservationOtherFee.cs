using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditFacilityReservationOtherFee
{
    public int AuditFacilityReservationOtherFeesKey { get; set; }

    public int FacilityReservationOtherFeesKey { get; set; }

    public int FacilityReservationKey { get; set; }

    public int? FacilityOtherFeeKey { get; set; }

    public decimal OtherFeeAmount { get; set; }

    public string? TimeFeeStarts { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
