using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AuditFacilityAvailableHour
{
    public int AuditFacilityAvailableHoursKey { get; set; }

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

    public string? MondayStart { get; set; }

    public string? MondayEnd { get; set; }

    public int? MondayStartTimeInterval { get; set; }

    public string? TuesdayStart { get; set; }

    public string? TuesdayEnd { get; set; }

    public int? TuesdayStartTimeInterval { get; set; }

    public string? WednesdayStart { get; set; }

    public string? WednesdayEnd { get; set; }

    public int? WednesdayStartTimeInterval { get; set; }

    public string? ThursdayStart { get; set; }

    public string? Thursdayend { get; set; }

    public int? ThursdayStartTimeInterval { get; set; }

    public string? FridayStart { get; set; }

    public string? FridayEnd { get; set; }

    public int? FridayStartTimeInterval { get; set; }

    public string? SaturdayStart { get; set; }

    public string? SaturdayEnd { get; set; }

    public int? SaturdayStartTimeInterval { get; set; }

    public string? LightFeeStart { get; set; }

    public string? AuditUser { get; set; }

    public string? AuditAction { get; set; }

    public DateTime? AuditTimestamp { get; set; }

    public int? SundayMin { get; set; }

    public int? SundayMax { get; set; }

    public int? SundayInterval { get; set; }

    public int? MondayMin { get; set; }

    public int? MondayMax { get; set; }

    public int? MondayInterval { get; set; }

    public int? TuesdayMin { get; set; }

    public int? TuesdayMax { get; set; }

    public int? TuesdayInterval { get; set; }

    public int? WednesdayMin { get; set; }

    public int? WednesdayMax { get; set; }

    public int? WednesdayInterval { get; set; }

    public int? ThursdayMin { get; set; }

    public int? ThursdayMax { get; set; }

    public int? ThursdayInterval { get; set; }

    public int? FridayMin { get; set; }

    public int? FridayMax { get; set; }

    public int? FridayInterval { get; set; }

    public int? SaturdayMin { get; set; }

    public int? SaturdayMax { get; set; }

    public int? SaturdayInterval { get; set; }
}
