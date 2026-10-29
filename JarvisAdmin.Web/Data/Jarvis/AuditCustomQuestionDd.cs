using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditCustomQuestionDd
{
    public int AuditCustomQuestionDdkey { get; set; }

    public int CustomQuestionDdkey { get; set; }

    public int CustomQuestionKey { get; set; }

    public string DropdownText { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }

    public decimal? AssociatedCost { get; set; }
}
