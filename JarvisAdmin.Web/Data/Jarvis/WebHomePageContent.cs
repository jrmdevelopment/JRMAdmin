using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebHomePageContent
{
    public int WebHomePageContentKey { get; set; }

    public int OrganizationKey { get; set; }

    public string HomePageContentArea { get; set; } = null!;

    public string? HomePageContentText { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
