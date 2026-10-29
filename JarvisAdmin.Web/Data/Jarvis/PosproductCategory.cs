using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PosproductCategory
{
    public int PosproductCategoryKey { get; set; }

    public int? OrganizationKey { get; set; }

    public string ProductCategoryName { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public string ProductCategoryStatus { get; set; } = null!;

    public string? ButtonColor { get; set; }

    public virtual ICollection<Posproduct> Posproducts { get; set; } = new List<Posproduct>();
}
