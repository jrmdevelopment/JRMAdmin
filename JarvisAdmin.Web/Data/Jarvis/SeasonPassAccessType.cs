using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPassAccessType
{
    public int SeasonPassAccessTypeKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? SeasonPassSetupKey { get; set; }

    public string AccessTypeName { get; set; } = null!;

    public decimal AccessTypePrice { get; set; }

    public bool FreeWithPass { get; set; }

    public string AccessTypeStatus { get; set; } = null!;

    /// <summary>
    /// This must match a LocationName in table ShiftLocation
    /// </summary>
    public string? LocationName { get; set; }

    public virtual ICollection<SeasonPassAddOn> SeasonPassAddOns { get; set; } = new List<SeasonPassAddOn>();
}
