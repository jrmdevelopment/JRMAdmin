using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountRegistrantLink
{
    public int AccountRegistrantLinkKey { get; set; }

    public int PrimaryAccountKey { get; set; }

    public int LinkedAccountKey { get; set; }

    public int RegistrantKey { get; set; }

    public DateTime? PrimaryResponseDate { get; set; }
}
