using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XLeagueShare
{
    public int LeagueShareKey { get; set; }

    public int MainOrganization { get; set; }

    public int OrganizationKey { get; set; }

    public string SportName { get; set; } = null!;

    public int LeagueKey { get; set; }

    public string LeagueDivision { get; set; } = null!;

    public string ShareStatus { get; set; } = null!;

    public int? SharedSeasonKey { get; set; }

    public int? SharedLeagueKey { get; set; }

    public string LastUpdatedBy { get; set; } = null!;
}
