using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityToCustomQuestion
{
    public int FacilityToCustomQuestionKey { get; set; }

    public int FacilityReservationKey { get; set; }

    public int? CustomQuestionFacilityKey { get; set; }

    public string Answer { get; set; } = null!;

    public string? LastUpdatedBy { get; set; }

    public virtual FacilityReservation FacilityReservationKeyNavigation { get; set; } = null!;
}
