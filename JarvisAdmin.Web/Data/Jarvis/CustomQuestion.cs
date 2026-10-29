using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CustomQuestion
{
    public int CustomQuestionKey { get; set; }

    public int OrganizationKey { get; set; }

    public string CustomQuestion1 { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public string QuestionType { get; set; } = null!;

    public bool QuestionRequired { get; set; }

    public string QuestionArea { get; set; } = null!;

    public string QuestionStatus { get; set; } = null!;

    public bool HasAssociatedCost { get; set; }

    public string? ReportLabel { get; set; }

    public string LastUpdatedBy { get; set; } = null!;

    public virtual ICollection<CoachToCustomQuestion> CoachToCustomQuestions { get; set; } = new List<CoachToCustomQuestion>();

    public virtual ICollection<CustomQuestionDd> CustomQuestionDds { get; set; } = new List<CustomQuestionDd>();

    public virtual ICollection<CustomQuestionProgram> CustomQuestionPrograms { get; set; } = new List<CustomQuestionProgram>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
