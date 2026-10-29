using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountToDocument
{
    public int AccountToDocumentKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? AccountKey { get; set; }

    public int? RegistrantKey { get; set; }

    public string? DocumentName { get; set; }

    public string DocumentFileName { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public string AddedBy { get; set; } = null!;

    public byte[]? DocumentEncrypted { get; set; }

    public int? DocumentTypeKey { get; set; }

    public byte[]? Pdfencrypted { get; set; }

    public bool? VerifiedByOrg { get; set; }

    public virtual Account? AccountKeyNavigation { get; set; }

    public virtual DocumentType? DocumentTypeKeyNavigation { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual Registrant? RegistrantKeyNavigation { get; set; }
}
