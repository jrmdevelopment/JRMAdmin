using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ValorDevice
{
    public int ValorDeviceKey { get; set; }

    public int OrganizationKey { get; set; }

    public string AppKey { get; set; } = null!;

    public string Epiid { get; set; } = null!;

    public string SerialNumber { get; set; } = null!;

    public string DeviceName { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string DeviceStatus { get; set; } = null!;

    public virtual ICollection<ShiftLocation> ShiftLocations { get; set; } = new List<ShiftLocation>();
}
