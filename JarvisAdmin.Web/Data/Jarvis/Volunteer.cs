using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Volunteer
{
    public int VolunteerKey { get; set; }

    public int SeasonKey { get; set; }

    public string VolunteerCapacity { get; set; } = null!;

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
