using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SilverSneakersImportcsv
{
    public int? AccountKey { get; set; }

    public string FullName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FullAddress { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public int Zip { get; set; }

    public string Phone1 { get; set; } = null!;

    public string? Phone2 { get; set; }

    public string? EmailAddress { get; set; }
}
