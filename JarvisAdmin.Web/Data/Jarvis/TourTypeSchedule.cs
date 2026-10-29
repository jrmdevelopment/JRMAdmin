using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TourTypeSchedule
{
    public int TourTypeScheduleKey { get; set; }

    public int TourTypeKey { get; set; }

    public DateOnly SeasonStart { get; set; }

    public DateOnly SeasonEnd { get; set; }

    public string ScheduleDescription { get; set; } = null!;

    public string TourTypeScheduleStatus { get; set; } = null!;

    public virtual ICollection<TourTypeScheduleSlot> TourTypeScheduleSlots { get; set; } = new List<TourTypeScheduleSlot>();
}
