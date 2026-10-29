using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class InventoryItem
{
    public int InventoryItemKey { get; set; }

    public int OrganizationKey { get; set; }

    public string InventoryItemCategory { get; set; } = null!;

    public string InventoryItemName { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public string? InventoryItemDesc { get; set; }

    public decimal? CostOfItem { get; set; }

    public string? PreferredVendor { get; set; }

    public decimal SalesPrice { get; set; }

    public int? ReorderPoint { get; set; }

    public int? OnHand { get; set; }

    public string InventoryItemStatus { get; set; } = null!;

    public bool ShowOnWebstore { get; set; }

    public string? ImageFileName { get; set; }

    public string? InventoryItemSize { get; set; }

    public string? InventoryItemColor { get; set; }

    public virtual InventoryItemSize? InventoryItemSizeNavigation { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
