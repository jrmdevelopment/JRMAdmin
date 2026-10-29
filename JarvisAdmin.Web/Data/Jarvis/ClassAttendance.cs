using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ClassAttendance
{
    public int ClassAttendanceKey { get; set; }

    public int RegistrantToLeagueKey { get; set; }

    public int? ActivityDateKey { get; set; }

    public DateTime? CheckInDateTime { get; set; }

    public DateTime? CheckOutDateTime { get; set; }

    public string? CheckInBy { get; set; }

    public string? CheckOutBy { get; set; }

    public string? CheckedOutTo { get; set; }

    public string? CheckedOutRelationship { get; set; }

    public string? SignatureData { get; set; }
}
