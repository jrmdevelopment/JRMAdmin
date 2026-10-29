using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SponsorPreference
{
    public int SponsorPreferenceKey { get; set; }

    public int OrganizationKey { get; set; }

    public string SponsorVerbiageOnline { get; set; } = null!;

    public bool ShowUniformColor { get; set; }

    public bool ShowChildSponsoring { get; set; }

    public bool ShowAgeGroup { get; set; }

    public string? OnlineEmailNotification { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
