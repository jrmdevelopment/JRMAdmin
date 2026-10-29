using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ResidentZipCode
{
    public int ResidentZipCodeKey { get; set; }

    public int OrganizationKey { get; set; }

    public string ResidentZipCode1 { get; set; } = null!;
}
