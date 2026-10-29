using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ResidentAddress
{
    public int ResidentAddressKey { get; set; }

    public int OrganizationKey { get; set; }

    public string ResidentAddress1 { get; set; } = null!;
}
