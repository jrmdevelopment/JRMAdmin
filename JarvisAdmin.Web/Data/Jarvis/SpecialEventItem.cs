using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SpecialEventItem
{
    public int SpecialEventItemKey { get; set; }

    public int SpecialEventConfigureKey { get; set; }

    public string EventItemDescription { get; set; } = null!;

    public decimal EventItemPrice { get; set; }

    public decimal? EventItemPriceNon { get; set; }

    public bool OrderMoreThanOne { get; set; }

    public string? AdditionalQuestion { get; set; }

    public string EventItemStatus { get; set; } = null!;

    public int? MaximumRegistrations { get; set; }

    public int DisplayOrder { get; set; }

    public virtual SpecialEventConfigure SpecialEventConfigureKeyNavigation { get; set; } = null!;

    public virtual ICollection<SpecialEventItemPurchase> SpecialEventItemPurchases { get; set; } = new List<SpecialEventItemPurchase>();
}
