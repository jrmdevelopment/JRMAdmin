using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebListPage
{
    /// <summary>
    /// This table is populated manually depending on the requirements of the organizations website
    /// </summary>
    public int WebListPageKey { get; set; }

    public int OrganizationKey { get; set; }

    public string WebsitePage { get; set; } = null!;
}
