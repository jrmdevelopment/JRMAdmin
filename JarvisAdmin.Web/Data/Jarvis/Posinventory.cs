using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Posinventory
{
    public int PosinventoryKey { get; set; }

    public int OrganizationKey { get; set; }

    public int PoslocationKey { get; set; }

    public int PosproductKey { get; set; }

    public string? RevenueCode { get; set; }

    public int? QuantityOnHand { get; set; }

    public int? ReorderThreshold { get; set; }

    public bool IsActive { get; set; }

    public int? DisplayOrder { get; set; }

    public virtual ICollection<PosinventoryTransaction> PosinventoryTransactions { get; set; } = new List<PosinventoryTransaction>();

    public virtual Poslocation PoslocationKeyNavigation { get; set; } = null!;

    public virtual Posproduct PosproductKeyNavigation { get; set; } = null!;
}
