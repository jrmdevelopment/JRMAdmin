using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CreditCardPost
{
    public int CreditCardPostKey { get; set; }

    public int OrganizationKey { get; set; }

    public string CreditCardPost1 { get; set; } = null!;

    public string PostSource { get; set; } = null!;

    public DateTime PostDate { get; set; }

    public string PostResponse { get; set; } = null!;
}
