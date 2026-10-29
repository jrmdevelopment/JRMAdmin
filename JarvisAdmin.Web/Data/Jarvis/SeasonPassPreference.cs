using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPassPreference
{
    public int SeasonPassPreferencesKey { get; set; }

    public int OrganizationKey { get; set; }

    public bool GenerateBarcodedCard { get; set; }

    public decimal LostCardCharge { get; set; }

    /// <summary>
    /// Pool, None, Manual
    /// </summary>
    public string NumberAssignmentMethod { get; set; } = null!;

    /// <summary>
    /// ThirdParty, Jarvis
    /// </summary>
    public string? BarcodedCardCreation { get; set; }

    public string? CardHtmlfileName { get; set; }

    public bool RequireFullContactInfo { get; set; }

    public int? FreePassMaxAge { get; set; }

    public bool OptionToMailPass { get; set; }

    public decimal? FlatPostageRate { get; set; }

    public DateTime? FreePassMaxAgeAsOfDate { get; set; }

    public string SeasonPassIdAssignment { get; set; } = null!;

    public bool? RequireIdverification { get; set; }

    public bool? RequirePhoto { get; set; }
}
