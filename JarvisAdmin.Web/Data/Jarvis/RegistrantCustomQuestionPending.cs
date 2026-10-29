using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantCustomQuestionPending
{
    public int RegistrantCustomQuestionPendingKey { get; set; }

    public int RegistrantToLeaguePendingKey { get; set; }

    public int CustomQuestionProgramKey { get; set; }

    public string Answer { get; set; } = null!;

    public string IndividualOrTeam { get; set; } = null!;

    public int? RegistrantToLeagueKey { get; set; }

    public decimal? AssociatedCost { get; set; }
}
