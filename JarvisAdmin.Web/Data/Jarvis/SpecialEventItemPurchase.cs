using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SpecialEventItemPurchase
{
    public int SpecialEventItemPurchaseKey { get; set; }

    public int SpecialEventKey { get; set; }

    public int SpecialEventItemKey { get; set; }

    public int QuantityPurchased { get; set; }

    public decimal PriceEach { get; set; }

    public decimal TotalPrice { get; set; }

    public string? AnswerToQuestion { get; set; }

    public virtual SpecialEventItem SpecialEventItemKeyNavigation { get; set; } = null!;

    public virtual SpecialEvent SpecialEventKeyNavigation { get; set; } = null!;
}
