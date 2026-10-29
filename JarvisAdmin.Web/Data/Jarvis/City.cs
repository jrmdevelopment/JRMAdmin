using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class City
{
    public int CityKey { get; set; }

    public int OrganizationKey { get; set; }

    public string CityName { get; set; } = null!;

    public string HomeCity { get; set; } = null!;

    public string CityStatus { get; set; } = null!;

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<Park> Parks { get; set; } = new List<Park>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
