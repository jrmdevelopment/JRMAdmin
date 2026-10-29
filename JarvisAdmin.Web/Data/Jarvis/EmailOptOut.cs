using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class EmailOptOut
{
    public int EmailOptOutKey { get; set; }

    public int OrganizationKey { get; set; }

    public string EmailAddress { get; set; } = null!;

    public DateTime OptOutDate { get; set; }

    public string? LastUpdatedBy { get; set; }
}
