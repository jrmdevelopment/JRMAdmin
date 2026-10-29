using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class LockerType
{
    public int LockerTypeKey { get; set; }

    public int OrganizationKey { get; set; }

    public string LockerTypeName { get; set; } = null!;

    public decimal RentalRate { get; set; }

    public decimal DepositAmount { get; set; }

    public string LockerTypeStatus { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public virtual ICollection<LockerRange> LockerRanges { get; set; } = new List<LockerRange>();

    public virtual ICollection<Locker> Lockers { get; set; } = new List<Locker>();
}
