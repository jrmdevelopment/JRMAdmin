using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class SeasonPassAddlPerson
{
    public int SeasonPassAddlPersonKey { get; set; }

    public int SeasonPassKey { get; set; }

    public string AddlPersonFirstName { get; set; } = null!;

    public string AddlPersonLastName { get; set; } = null!;

    public virtual ICollection<SeasonPassCheckin> SeasonPassCheckins { get; set; } = new List<SeasonPassCheckin>();

    public virtual SeasonPass SeasonPassKeyNavigation { get; set; } = null!;
}
