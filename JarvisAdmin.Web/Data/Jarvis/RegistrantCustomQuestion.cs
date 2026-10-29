using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantCustomQuestion
{
    public int RegistrantCustomQuestionKey { get; set; }

    public int RegistrantToLeagueKey { get; set; }

    public int CustomQuestionProgramKey { get; set; }

    public string Answer { get; set; } = null!;

    public string IndividualOrTeam { get; set; } = null!;

    public decimal AssociatedCost { get; set; }

    public virtual CustomQuestionProgram CustomQuestionProgramKeyNavigation { get; set; } = null!;
}
