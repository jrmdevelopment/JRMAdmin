using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class LockerRange
{
    public int LockerRangeKey { get; set; }

    public int? OrganizationKey { get; set; }

    public int LockerTypeKey { get; set; }

    public int RangeStart { get; set; }

    public int RangeEnd { get; set; }

    public virtual LockerType LockerTypeKeyNavigation { get; set; } = null!;

    public virtual ICollection<Locker> Lockers { get; set; } = new List<Locker>();
}
