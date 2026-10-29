using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityTieredRate
{
    public int FacilityTieredRatesKey { get; set; }

    public int OrganizationKey { get; set; }

    public int FacilitySpaceKey { get; set; }

    public int MinimumNumber { get; set; }

    public int MaximumNumber { get; set; }

    public decimal AdditionalFee { get; set; }

    public string FacilityTieredRatesStatus { get; set; } = null!;

    public string LastUpdatedBy { get; set; } = null!;

    public virtual FacilitySpace FacilitySpaceKeyNavigation { get; set; } = null!;
}
