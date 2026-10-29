using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class TextMessageOptIn
{
    public int TextMessageOptInKey { get; set; }

    public int OrganizationKey { get; set; }

    public DateTime? OptInDate { get; set; }

    public string CellPhone { get; set; } = null!;

    public int? AccountKey { get; set; }

    public DateTime? OptOutDate { get; set; }

    public bool CoachCell { get; set; }

    public int VerificationCode { get; set; }

    public bool CellPhoneValidated { get; set; }

    public string? CellPhoneDescription { get; set; }

    public bool OptInGameReminders { get; set; }

    public bool OptInPracticeReminders { get; set; }

    public virtual Account? AccountKeyNavigation { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<TextMessageOptInTeam> TextMessageOptInTeams { get; set; } = new List<TextMessageOptInTeam>();
}
