using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class EmailTemplate
{
    public int EmailTemplateKey { get; set; }

    public int OrganizationKey { get; set; }

    public string EmailTemplateName { get; set; } = null!;

    public string EmailTemplateText { get; set; } = null!;

    public string? TemplateType { get; set; }

    public string SystemTemplate { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
