using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class DocumentType
{
    public int DocumentTypeKey { get; set; }

    public int OrganizationKey { get; set; }

    public string DocumentType1 { get; set; } = null!;

    public string DocumentTypeStatus { get; set; } = null!;

    public bool UploadOnline { get; set; }

    public string? DocumentTypeDesc { get; set; }

    public string AppliesTo { get; set; } = null!;

    public virtual ICollection<AccountToDocument> AccountToDocuments { get; set; } = new List<AccountToDocument>();
}
