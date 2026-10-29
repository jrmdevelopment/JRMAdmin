using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class PostransactionWaiver
{
    public int PostransactionWaiverKey { get; set; }

    public int OrganizationKey { get; set; }

    public int PostransactionKey { get; set; }

    public string RequiredWaiverType { get; set; } = null!;

    public bool? WaiverSigned { get; set; }

    public DateTime? SignedDateTime { get; set; }

    public string? SignedByName { get; set; }

    public string? ElectronicSignature { get; set; }
}
