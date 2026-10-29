using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class InventoryItemSize
{
    public string InventoryItemSizeDesc { get; set; } = null!;

    public int InventorySizeOrder { get; set; }

    public virtual ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
}
