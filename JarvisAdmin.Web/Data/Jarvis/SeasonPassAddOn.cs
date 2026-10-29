using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPassAddOn
{
    public int SeasonPassAddOnKey { get; set; }

    public int SeasonPassAccessTypeKey { get; set; }

    public int SeasonPassKey { get; set; }

    public decimal AddOnPrice { get; set; }

    public string AddOnName { get; set; } = null!;

    public virtual SeasonPassAccessType SeasonPassAccessTypeKeyNavigation { get; set; } = null!;

    public virtual SeasonPass SeasonPassKeyNavigation { get; set; } = null!;
}
