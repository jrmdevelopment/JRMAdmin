using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebForm
{
    public int WebFormKey { get; set; }

    public int OrganizationKey { get; set; }

    public string FormSubject { get; set; } = null!;

    public string FormFilename { get; set; } = null!;

    public string FormStatus { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public string? FormCategory { get; set; }

    public DateTime? DateAdded { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;
}
