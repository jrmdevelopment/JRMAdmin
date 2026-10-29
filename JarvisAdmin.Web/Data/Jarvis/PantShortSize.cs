using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PantShortSize
{
    public int PantShortSizeKey { get; set; }

    public int SeasonKey { get; set; }

    public string PantShortSize1 { get; set; } = null!;

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
