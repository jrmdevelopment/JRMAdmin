using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SkillLevel
{
    public int SkillLevelKey { get; set; }

    public int SeasonKey { get; set; }

    public string SkillLevel1 { get; set; } = null!;

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
