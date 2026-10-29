using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Holiday
{
    public int HolidayKey { get; set; }

    public string HolidayName { get; set; } = null!;

    public DateTime HolidayDate { get; set; }

    public virtual ICollection<OrganizationHoliday> OrganizationHolidays { get; set; } = new List<OrganizationHoliday>();
}
