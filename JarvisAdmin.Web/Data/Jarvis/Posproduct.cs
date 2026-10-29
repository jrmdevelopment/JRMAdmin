using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Posproduct
{
    public int PosproductKey { get; set; }

    public int OrganizationKey { get; set; }

    public int PosproductCategoryKey { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal DefaultPrice { get; set; }

    public bool IsProductTaxable { get; set; }

    public string ProductStatus { get; set; } = null!;

    public bool ProduceBarcodeTicket { get; set; }

    public bool EnterTotalOnly { get; set; }

    public virtual ICollection<Posinventory> Posinventories { get; set; } = new List<Posinventory>();

    public virtual ICollection<PosinventoryTransaction> PosinventoryTransactions { get; set; } = new List<PosinventoryTransaction>();

    public virtual PosproductCategory PosproductCategoryKeyNavigation { get; set; } = null!;

    public virtual ICollection<PostransactionItem> PostransactionItems { get; set; } = new List<PostransactionItem>();
}
