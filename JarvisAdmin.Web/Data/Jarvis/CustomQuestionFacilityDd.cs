using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CustomQuestionFacilityDd
{
    public int CustomQuestionFacilityDdkey { get; set; }

    public int CustomQuestionFacilityKey { get; set; }

    public string DropdownText { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public virtual CustomQuestionFacility CustomQuestionFacilityKeyNavigation { get; set; } = null!;
}
