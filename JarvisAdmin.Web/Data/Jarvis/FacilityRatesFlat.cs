using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityRatesFlat
{
    public int FacilityRatesFlatKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public int OrganizationKey { get; set; }

    public string FlatRateDescription { get; set; } = null!;

    public decimal FlatRate { get; set; }

    public int? MaxNbrOfMinutes { get; set; }

    public string FlatRateStatus { get; set; } = null!;

    public string LastUpdatedBy { get; set; } = null!;
}
