using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebListCategory
{
    /// <summary>
    /// This table is populated manually depending on the requirements of the organizations website
    /// </summary>
    public int WebListCategoryKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? WeblistPageKey { get; set; }

    public string WebsiteListCategory { get; set; } = null!;
}
