using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ActivityCalendar
{
    public int ActivityCalendarKey { get; set; }

    public int OrganizationKey { get; set; }

    public string EventName { get; set; } = null!;

    public string? EventLocation { get; set; }

    public DateTime EventStartTime { get; set; }

    public DateTime EventEndTime { get; set; }

    public string? EventComments { get; set; }

    public string? RecurrenceRule { get; set; }

    public int? RecurrenceId { get; set; }

    public string? RecurrenceException { get; set; }

    public int? SeasonKey { get; set; }

    public string? AppointmentType { get; set; }

    public string? LastUpdatedBy { get; set; }
}
