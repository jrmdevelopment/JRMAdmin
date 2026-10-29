using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebPageAccess
{
    public int WebPageAccessKey { get; set; }

    public int OrganizationKey { get; set; }

    public bool HomePage { get; set; }

    public bool WebText { get; set; }

    public bool NewsEvents { get; set; }

    public bool WebForms { get; set; }

    public bool WebFaqs { get; set; }

    public bool WebActivityCalendar { get; set; }

    public bool WebParks { get; set; }

    public bool WebContact { get; set; }

    public bool? WebList { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
