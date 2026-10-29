using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TeamRoster
{
    public int TeamRosterKey { get; set; }

    public int TeamKey { get; set; }

    public int OrganizationKey { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string? ContactPhone { get; set; }

    public string? EmailAddress { get; set; }

    public DateTime? BirthDate { get; set; }

    public bool Over18 { get; set; }

    public DateTime RegistrationDate { get; set; }

    public int? JerseyNumber { get; set; }

    public string? JerseySize { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual Team TeamKeyNavigation { get; set; } = null!;
}
