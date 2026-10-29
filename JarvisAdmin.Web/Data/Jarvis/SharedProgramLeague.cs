using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SharedProgramLeague
{
    public int SharedProgramLeagueKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SharedToOrganizationKey { get; set; }

    public int SeasonKey { get; set; }

    public int LeagueKey { get; set; }
}
