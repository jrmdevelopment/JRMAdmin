using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XCrmlead
{
    public int CrmleadKey { get; set; }

    public string CompanyName { get; set; } = null!;

    public string CompanyCity { get; set; } = null!;

    public string CompanySt { get; set; } = null!;

    public string? CompanyPhone { get; set; }

    public string? CompanyExt { get; set; }

    public string? CompanyEmailAddr { get; set; }

    public int? CityPopulation { get; set; }

    public string? WebAddress { get; set; }

    public int TimeZone { get; set; }

    public string? ContactName { get; set; }

    public string? ContactTitle { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactPhoneExt { get; set; }

    public string? ContactEmailAddr { get; set; }

    public string? OtherComments { get; set; }

    public string CrmleadStatus { get; set; } = null!;

    public string? UnqualifiedReason { get; set; }

    public DateTime? UnqualifiedDate { get; set; }

    public string? CurrentlyUsing { get; set; }

    public DateTime? FirstContactedDate { get; set; }

    public DateTime? CallBackDate { get; set; }

    public DateTime? LastTouchedDate { get; set; }

    public DateTime? DemoDate { get; set; }

    public string? LeadType { get; set; }

    public DateTime? LastVerifiedDate { get; set; }
}
