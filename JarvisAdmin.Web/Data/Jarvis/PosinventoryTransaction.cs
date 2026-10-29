using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PosinventoryTransaction
{
    public int PosinventoryTransactionKey { get; set; }

    public int OrganizationKey { get; set; }

    public int PosinventoryKey { get; set; }

    public int PoslocationKey { get; set; }

    public int PosproductKey { get; set; }

    /// <summary>
    /// Receive, Sale, Adjustment
    /// </summary>
    public string TransactionType { get; set; } = null!;

    public int QuantityChange { get; set; }

    public string? AdjustmentReason { get; set; }

    public string? StaffNotes { get; set; }

    public string EnteredBy { get; set; } = null!;

    public virtual Posinventory PosinventoryKeyNavigation { get; set; } = null!;

    public virtual Poslocation PoslocationKeyNavigation { get; set; } = null!;

    public virtual Posproduct PosproductKeyNavigation { get; set; } = null!;
}
