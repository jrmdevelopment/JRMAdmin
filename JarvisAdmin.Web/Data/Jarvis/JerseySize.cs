using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class JerseySize
{
    public int JerseySizeKey { get; set; }

    public int SeasonKey { get; set; }

    public string JerseySize1 { get; set; } = null!;

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
