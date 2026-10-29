using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebFaq
{
    public int WebFaqkey { get; set; }

    public int OrganizationKey { get; set; }

    public string Faqquestion { get; set; } = null!;

    public string Faqanswer { get; set; } = null!;

    public string Faqstatus { get; set; } = null!;

    public int FaqdisplayOrder { get; set; }

    public string? Faqcategory { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
