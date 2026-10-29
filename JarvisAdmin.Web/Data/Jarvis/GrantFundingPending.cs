using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class GrantFundingPending
{
    public int GrantFundingPendingKey { get; set; }

    public int RegistrantToLeagueKey { get; set; }

    public string RacialBackground { get; set; } = null!;

    public string Hispanic { get; set; } = null!;

    public string HouseholdIncome { get; set; } = null!;

    public int PeopleInFamily { get; set; }

    public string HouseholdMakeup { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Housing { get; set; } = null!;

    public string GradeLevel { get; set; } = null!;
}
