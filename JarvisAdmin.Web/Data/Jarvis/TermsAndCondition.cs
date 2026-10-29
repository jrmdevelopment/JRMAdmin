using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TermsAndCondition
{
    public int TermsAndConditionsKey { get; set; }

    public int SeasonKey { get; set; }

    public string TermsAndConditionsText { get; set; } = null!;

    public int? DisplayOrder { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
