using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebsiteContactU
{
    public int WebsiteContactUsKey { get; set; }

    public int OrganizationKey { get; set; }

    public string SubmitterName { get; set; } = null!;

    public string SubmitterEmail { get; set; } = null!;

    public string MessageSubject { get; set; } = null!;

    public DateTime DateSubmitted { get; set; }

    public string MessageStatus { get; set; } = null!;

    public string? MessageContent { get; set; }
}
