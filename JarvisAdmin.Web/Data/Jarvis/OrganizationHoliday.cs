using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class OrganizationHoliday
{
    public int OrganizationHolidayKey { get; set; }

    public int OrganizationKey { get; set; }

    public int HolidayKey { get; set; }

    public virtual Holiday HolidayKeyNavigation { get; set; } = null!;
}
