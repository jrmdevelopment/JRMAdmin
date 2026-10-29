using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TeamToCoach
{
    public int TeamToCoachKey { get; set; }

    public int TeamKey { get; set; }

    /// <summary>
    /// The key to the coach application for youth coaches. Will not be populated for adult coach/managers, only the &apos;AccountKey&apos;.
    /// </summary>
    public int? CoachKey { get; set; }

    /// <summary>
    /// &apos;Adult Team&apos;, &apos;Youth Team&apos;, &apos;Youth Full&apos; or &apos;Individual&apos;. Indicates the type of team the coach is for. &apos;Youth Team&apos; is for the invite process, while &apos;Youth Full&apos; is for those programs registering only youth teams.
    /// </summary>
    public string ProgramType { get; set; } = null!;

    /// <summary>
    /// Name of the coach. For coach&apos;s with applications (youth) will keep from having to join to get name. For adult teams, the record is linked to the account so it tells which account holder is the coach/manager.
    /// </summary>
    public string CoachName { get; set; } = null!;

    /// <summary>
    /// This is the &apos;Volunteer Capacity - &apos;Head Coach&apos;, &apos;Assistant Coach&apos; or the actual volunteer capacity value
    /// </summary>
    public string CoachType { get; set; } = null!;

    /// <summary>
    /// The account holder record the coach is tied to.
    /// </summary>
    public int AccountKey { get; set; }

    public string? CoachEmailAddr { get; set; }

    public virtual Account AccountKeyNavigation { get; set; } = null!;

    public virtual CoachApplication? CoachKeyNavigation { get; set; }

    public virtual Team TeamKeyNavigation { get; set; } = null!;
}
