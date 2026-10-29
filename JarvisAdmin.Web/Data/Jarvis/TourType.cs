using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TourType
{
    public int TourTypeKey { get; set; }

    public int OrganizationKey { get; set; }

    public string TourTypeDescription { get; set; } = null!;

    public int? MaxPersons { get; set; }

    public int? NbrOfHours { get; set; }

    public string? RevenueCode { get; set; }

    public virtual ICollection<TourTypeItem> TourTypeItems { get; set; } = new List<TourTypeItem>();
}
