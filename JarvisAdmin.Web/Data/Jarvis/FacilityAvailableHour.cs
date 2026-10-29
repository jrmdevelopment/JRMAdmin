using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityAvailableHour
{
    public int FacilityAvailableHoursKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? FacilitySpaceKey { get; set; }

    public bool Sunday { get; set; }

    public bool Monday { get; set; }

    public bool Tuesday { get; set; }

    public bool Wednesday { get; set; }

    public bool Thursday { get; set; }

    public bool Friday { get; set; }

    public bool Saturday { get; set; }

    public string? SundayStart { get; set; }

    public string? SundayEnd { get; set; }

    public int? SundayStartTimeInterval { get; set; }

    public int? SundayInterval { get; set; }

    public string? MondayStart { get; set; }

    public string? MondayEnd { get; set; }

    public int? MondayStartTimeInterval { get; set; }

    public int? MondayInterval { get; set; }

    public string? TuesdayStart { get; set; }

    public string? TuesdayEnd { get; set; }

    public int? TuesdayStartTimeInterval { get; set; }

    public int? TuesdayInterval { get; set; }

    public string? WednesdayStart { get; set; }

    public string? WednesdayEnd { get; set; }

    public int? WednesdayStartTimeInterval { get; set; }

    public int? WednesdayInterval { get; set; }

    public string? ThursdayStart { get; set; }

    public string? ThursdayEnd { get; set; }

    public int? ThursdayStartTimeInterval { get; set; }

    public int? ThursdayInterval { get; set; }

    public string? FridayStart { get; set; }

    public string? FridayEnd { get; set; }

    public int? FridayStartTimeInterval { get; set; }

    public int? FridayInterval { get; set; }

    public string? SaturdayStart { get; set; }

    public string? SaturdayEnd { get; set; }

    public int? SaturdayStartTimeInterval { get; set; }

    public int? SaturdayInterval { get; set; }

    public string? LightFeeStart { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual FacilitySpace? FacilitySpaceKeyNavigation { get; set; }
}
