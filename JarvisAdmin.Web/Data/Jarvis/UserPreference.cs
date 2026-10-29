using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class UserPreference
{
    public int UserPreferencesKey { get; set; }

    public int OrganizationKey { get; set; }

    public Guid UserId { get; set; }

    public string PreferenceArea { get; set; } = null!;

    public int? TableKey { get; set; }

    public string? PreferenceName { get; set; }
}
