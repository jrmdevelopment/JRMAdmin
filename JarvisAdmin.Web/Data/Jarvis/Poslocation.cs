using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Poslocation
{
    public int PoslocationKey { get; set; }

    public int OrganizationKey { get; set; }

    /// <summary>
    /// Concession, Retail, Recreation, Admissions, Maintenance, Storage
    /// </summary>
    public int PoslocationTypeKey { get; set; }

    public string LocationName { get; set; } = null!;

    public bool IsActive { get; set; }

    public int? ValorDeviceKey { get; set; }

    public virtual ICollection<Posinventory> Posinventories { get; set; } = new List<Posinventory>();

    public virtual ICollection<PosinventoryTransaction> PosinventoryTransactions { get; set; } = new List<PosinventoryTransaction>();

    public virtual PoslocationType PoslocationTypeKeyNavigation { get; set; } = null!;
}
