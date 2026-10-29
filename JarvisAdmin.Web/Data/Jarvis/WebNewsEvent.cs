using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebNewsEvent
{
    public int NewsEventsKey { get; set; }

    public int OrganizationKey { get; set; }

    public string NewsEventsSubject { get; set; } = null!;

    public DateTime NewsStartDate { get; set; }

    public DateTime? NewsEndDate { get; set; }

    public string NewsEventsContent { get; set; } = null!;

    public DateTime? DateAdded { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
