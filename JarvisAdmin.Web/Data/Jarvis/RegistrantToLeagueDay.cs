using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantToLeagueDay
{
    public int RegistrantToLeagueDayKey { get; set; }

    public int RegistrantToLeagueKey { get; set; }

    public byte DayOfWeek { get; set; }

    public virtual RegistrantToLeague RegistrantToLeagueKeyNavigation { get; set; } = null!;
}
