using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Poscategory
{
    public int PoscategoryKey { get; set; }

    public int? OrganizationKey { get; set; }

    public string CategoryName { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public string CategoryStatus { get; set; } = null!;

    public string? ButtonColor { get; set; }

    public virtual ICollection<Po> Pos { get; set; } = new List<Po>();

    public virtual ICollection<Positem> Positems { get; set; } = new List<Positem>();
}
