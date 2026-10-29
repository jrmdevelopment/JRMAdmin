using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Positem
{
    public int PositemKey { get; set; }

    public int PoscategoryKey { get; set; }

    public string ItemDescription { get; set; } = null!;

    public decimal? ItemPrice { get; set; }

    public int? DisplayOrder { get; set; }

    public string ItemStatus { get; set; } = null!;

    public string ItemButtonColor { get; set; } = null!;

    public string? RevenueCode { get; set; }

    public bool EnterTotalOnly { get; set; }

    public bool CustomerNameReqd { get; set; }

    public bool IsItemTaxable { get; set; }

    public string? PoswaiverForm { get; set; }

    public virtual ICollection<Po> Pos { get; set; } = new List<Po>();

    public virtual Poscategory PoscategoryKeyNavigation { get; set; } = null!;

    public virtual ICollection<PostransactionItem> PostransactionItems { get; set; } = new List<PostransactionItem>();
}
