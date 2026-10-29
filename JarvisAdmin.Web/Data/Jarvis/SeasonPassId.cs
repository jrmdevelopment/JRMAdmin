using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPassId
{
    public int SeasonPassIdKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SeasonPassId1 { get; set; }

    public int? SeasonPassKey { get; set; }

    public string SeasonPassIdStatus { get; set; } = null!;

    public virtual SeasonPass? SeasonPassKeyNavigation { get; set; }
}
