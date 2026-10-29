using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CustomQuestionProgramDd
{
    public int CustomQuestionProgramDdkey { get; set; }

    public int CustomQuestionProgramKey { get; set; }

    public string DropdownText { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public string? LastUpdatedBy { get; set; }

    public decimal? AssociatedCost { get; set; }

    public virtual CustomQuestionProgram CustomQuestionProgramKeyNavigation { get; set; } = null!;
}
