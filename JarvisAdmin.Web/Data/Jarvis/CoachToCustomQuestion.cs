using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CoachToCustomQuestion
{
    public int CoachToCustomQuestionKey { get; set; }

    public int ApplicationKey { get; set; }

    public int? CustomQuestionKey { get; set; }

    public string Answer { get; set; } = null!;

    public string? TypeOfApplication { get; set; }

    public virtual CoachApplication ApplicationKeyNavigation { get; set; } = null!;

    public virtual CustomQuestion? CustomQuestionKeyNavigation { get; set; }
}
