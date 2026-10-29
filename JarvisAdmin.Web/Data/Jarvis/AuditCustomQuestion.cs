using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditCustomQuestion
{
    public int AuditCustomQuestionKey { get; set; }

    public int CustomQuestionKey { get; set; }

    public int OrganizationKey { get; set; }

    public string CustomQuestion { get; set; } = null!;

    public string QuestionType { get; set; } = null!;

    public bool QuestionRequired { get; set; }

    public string QuestionArea { get; set; } = null!;

    public string QuestionStatus { get; set; } = null!;

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }

    public bool? HasAssociatedCost { get; set; }

    public int? DisplayOrder { get; set; }

    public string? ReportLabel { get; set; }
}
