using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ShiftLocation
{
    public int ShiftLocationKey { get; set; }

    public int OrganizationKey { get; set; }

    public string MainCategory { get; set; } = null!;

    public string LocationName { get; set; } = null!;

    public string SubLocationName { get; set; } = null!;

    public string StaffContact { get; set; } = null!;

    public string ShiftLocationStatus { get; set; } = null!;

    public int? ValorDeviceKey { get; set; }

    public virtual ValorDevice? ValorDeviceKeyNavigation { get; set; }
}
