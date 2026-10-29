using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class GrantFunding
{
    public int GrantFundingKey { get; set; }

    public int RegistrantToLeagueKey { get; set; }

    public string? RacialBackground { get; set; }

    public string? Hispanic { get; set; }

    public string? HouseholdIncome { get; set; }

    public int? PeopleInFamily { get; set; }

    public string? HouseholdMakeup { get; set; }

    public string? Gender { get; set; }

    public string? Housing { get; set; }

    public string? GradeLevel { get; set; }
}
