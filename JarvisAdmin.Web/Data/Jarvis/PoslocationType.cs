using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PoslocationType
{
    public int PoslocationTypeKey { get; set; }

    public int OrganizationKey { get; set; }

    public string PoslocationTypeName { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<Poslocation> Poslocations { get; set; } = new List<Poslocation>();
}
