using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TextMessageOptInTeam
{
    public int TextMessageOptInTeamKey { get; set; }

    public int TextMessageOptInKey { get; set; }

    public int TeamKey { get; set; }

    public DateTime OptInDate { get; set; }

    public virtual Team TeamKeyNavigation { get; set; } = null!;

    public virtual TextMessageOptIn TextMessageOptInKeyNavigation { get; set; } = null!;
}
