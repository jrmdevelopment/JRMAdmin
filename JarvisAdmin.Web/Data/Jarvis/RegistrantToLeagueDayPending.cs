using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class RegistrantToLeagueDayPending
{
    public int RegistrantToLeagueDayPendingKey { get; set; }

    public int RegistrantToLeaguePendingKey { get; set; }

    public byte DayOfWeek { get; set; }

    public virtual RegistrantToLeaguePending RegistrantToLeaguePendingKeyNavigation { get; set; } = null!;
}
