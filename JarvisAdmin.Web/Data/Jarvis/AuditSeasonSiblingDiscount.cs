using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditSeasonSiblingDiscount
{
    public int AuditSeasonSiblingDiscountKey { get; set; }

    public int SeasonSiblingDiscountKey { get; set; }

    public int SeasonKey { get; set; }

    public int ParticipatingSeasonKey { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }
}
