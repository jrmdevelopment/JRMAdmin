using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditFacilityToCustomQuestion
{
    public int AuditFacilityToCustomQuestionKey { get; set; }

    public int FacilityToCustomQuestionKey { get; set; }

    public int FacilityReservationKey { get; set; }

    public int? CustomQuestionFacilityKey { get; set; }

    public string Answer { get; set; } = null!;

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }
}
