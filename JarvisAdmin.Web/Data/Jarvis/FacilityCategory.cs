using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityCategory
{
    public int FacilityCategoryKey { get; set; }

    public int OrganizationKey { get; set; }

    public string FacilityCategoryName { get; set; } = null!;

    public string FacilityCategoryStatus { get; set; } = null!;
}
