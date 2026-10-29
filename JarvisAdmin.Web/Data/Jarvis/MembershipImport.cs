using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipImport
{
    public int? AccountKey { get; set; }

    public int? MembershipKey { get; set; }

    public string MembershipType { get; set; } = null!;

    public DateOnly Start { get; set; }

    public DateTime Expire { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly Dob { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string St { get; set; } = null!;

    public int Zip { get; set; }

    public string Phone { get; set; } = null!;

    public string PhoneFormatted { get; set; } = null!;

    public string? Email { get; set; }

    public int PassIdNumber { get; set; }

    public int? MembershipTypeKey { get; set; }

    public decimal? MembershipAmount { get; set; }
}
