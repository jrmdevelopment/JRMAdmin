using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CustomQuestionProgram
{
    public int CustomQuestionProgramKey { get; set; }

    public int SeasonKey { get; set; }

    public string CustomQuestion { get; set; } = null!;

    public string QuestionType { get; set; } = null!;

    public bool QuestionRequired { get; set; }

    public string Status { get; set; } = null!;

    public int? CustomQuestionKey { get; set; }

    public string QuestionArea { get; set; } = null!;

    public int? DisplayOrder { get; set; }

    public string? LastUpdatedBy { get; set; }

    public DateTime? CustomQuestionAdded { get; set; }

    public bool? HasAssociatedCost { get; set; }

    public string? ReportLabel { get; set; }

    public virtual CustomQuestion? CustomQuestionKeyNavigation { get; set; }

    public virtual ICollection<CustomQuestionProgramDd> CustomQuestionProgramDds { get; set; } = new List<CustomQuestionProgramDd>();

    public virtual ICollection<RegistrantCustomQuestion> RegistrantCustomQuestions { get; set; } = new List<RegistrantCustomQuestion>();

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
