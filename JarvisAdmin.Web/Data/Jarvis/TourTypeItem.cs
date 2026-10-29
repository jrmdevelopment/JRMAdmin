using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TourTypeItem
{
    public int TourTypeItemKey { get; set; }

    public int TourTypeKey { get; set; }

    public string TourItemDescription { get; set; } = null!;

    public decimal TourPrice { get; set; }

    public string PriceType { get; set; } = null!;

    public int? NbrOfPersons { get; set; }

    public virtual ICollection<TourRegistration> TourRegistrations { get; set; } = new List<TourRegistration>();

    public virtual TourType TourTypeKeyNavigation { get; set; } = null!;
}
