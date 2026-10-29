using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonSiblingDiscount
{
    public int SeasonSiblingDiscountKey { get; set; }

    public int SeasonKey { get; set; }

    public int ParticipatingSeasonKey { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
