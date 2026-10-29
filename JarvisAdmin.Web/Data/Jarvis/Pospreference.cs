using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Pospreference
{
    public int PospreferenceKey { get; set; }

    public int OrganizationKey { get; set; }

    public bool TakeCash { get; set; }

    public bool TakeCheck { get; set; }

    public bool TakeEmv { get; set; }

    public bool TakeCreditCard { get; set; }

    public bool TakeAccountCredit { get; set; }

    public bool UseDiscountCodes { get; set; }
}
