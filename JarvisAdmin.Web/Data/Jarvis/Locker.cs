using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Locker
{
    public int LockerKey { get; set; }

    public int? OrganizationKey { get; set; }

    public int LockerNumber { get; set; }

    public int LockerTypeKey { get; set; }

    public int LockerRangeKey { get; set; }

    public string LockerStatus { get; set; } = null!;

    public virtual LockerRange LockerRangeKeyNavigation { get; set; } = null!;

    public virtual ICollection<LockerRental> LockerRentals { get; set; } = new List<LockerRental>();

    public virtual LockerType LockerTypeKeyNavigation { get; set; } = null!;
}
