using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditCustomQuestionProgram
{
    public int AuditCustomQuestionProgramKey { get; set; }

    public int CustomQuestionProgramKey { get; set; }

    public int SeasonKey { get; set; }

    public string CustomQuestion { get; set; } = null!;

    public string QuestionType { get; set; } = null!;

    public bool QuestionRequired { get; set; }

    public string Status { get; set; } = null!;

    public int? CustomQuestionKey { get; set; }

    public string QuestionArea { get; set; } = null!;

    public DateTime? CustomQuestionAdded { get; set; }

    public string? AuditUser { get; set; }

    public string AuditAction { get; set; } = null!;

    public DateTime AuditTimestamp { get; set; }

    public int? DisplayOrder { get; set; }

    public bool? HasAssociatedCost { get; set; }

    public string? LastUpdatedBy { get; set; }

    public string? ReportLabel { get; set; }
}
