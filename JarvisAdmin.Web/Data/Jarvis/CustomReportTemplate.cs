using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CustomReportTemplate
{
    public int CustomReportTemplateKey { get; set; }

    public int OrganizationKey { get; set; }

    public string TemplateName { get; set; } = null!;

    public string FieldList { get; set; } = null!;

    public string TemplateType { get; set; } = null!;
}
