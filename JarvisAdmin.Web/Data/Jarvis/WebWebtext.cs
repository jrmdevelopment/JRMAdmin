using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebWebtext
{
    public int WebtextUniqueKey { get; set; }

    public string WebtextKey { get; set; } = null!;

    public int OrganizationKey { get; set; }

    public string? WebtextVerbiage { get; set; }

    public string? WebtextCategory { get; set; }

    public string WebtextStatus { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
