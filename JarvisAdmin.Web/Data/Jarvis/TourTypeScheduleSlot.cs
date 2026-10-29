using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TourTypeScheduleSlot
{
    public int TourTypeScheduleSlotKey { get; set; }

    public int TourTypeScheduleKey { get; set; }

    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public string TourScheduleSlotStatus { get; set; } = null!;

    public virtual TourTypeSchedule TourTypeScheduleKeyNavigation { get; set; } = null!;
}
