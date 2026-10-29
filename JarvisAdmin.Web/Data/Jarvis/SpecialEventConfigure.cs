using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SpecialEventConfigure
{
    public int SpecialEventConfigureKey { get; set; }

    public int OrganizationKey { get; set; }

    public string EventName { get; set; } = null!;

    public string EventDescription { get; set; } = null!;

    public bool UseResidentNonresident { get; set; }

    public string EventStatus { get; set; } = null!;

    public DateTime EventStartDate { get; set; }

    public DateTime EventEndDate { get; set; }

    public string? RevenueCode { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<SpecialEventItem> SpecialEventItems { get; set; } = new List<SpecialEventItem>();

    public virtual ICollection<SpecialEvent> SpecialEvents { get; set; } = new List<SpecialEvent>();
}
