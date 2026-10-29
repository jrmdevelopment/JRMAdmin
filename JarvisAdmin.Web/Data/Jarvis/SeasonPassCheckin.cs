using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPassCheckin
{
    public int SeasonPassCheckinKey { get; set; }

    public int OrganizationKey { get; set; }

    public int? SeasonPassKey { get; set; }

    public DateTime CheckInDate { get; set; }

    public string? CheckinSource { get; set; }

    public string? DeviceId { get; set; }

    public int? SeasonPassAddlPersonKey { get; set; }

    public string? BarcodeNumber { get; set; }

    public virtual SeasonPassAddlPerson? SeasonPassAddlPersonKeyNavigation { get; set; }

    public virtual SeasonPass? SeasonPassKeyNavigation { get; set; }
}
