using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class ApplicationPreference
{
    public int ApplicationPreferenceKey { get; set; }

    public int OrganizationKey { get; set; }

    public string ApplicationType { get; set; } = null!;

    public bool ApplicationReferences { get; set; }

    public bool ApplicationEmployment { get; set; }

    public int? BackgroundCheckMonths { get; set; }

    public bool SsnonApplication { get; set; }

    public bool DobonApplication { get; set; }

    public decimal BackgroundFeeToCoach { get; set; }

    public string? ApplicationWaiver { get; set; }

    public bool CoachVolunteerImage { get; set; }

    public string? BackgroundCheckUrl { get; set; }
}
