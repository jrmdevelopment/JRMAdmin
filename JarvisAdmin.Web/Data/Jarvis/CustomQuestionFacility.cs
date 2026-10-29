using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CustomQuestionFacility
{
    public int CustomQuestionFacilityKey { get; set; }

    public int? OrganizationKey { get; set; }

    public int? FacilitySpaceKey { get; set; }

    public string CustomQuestion { get; set; } = null!;

    public string QuestionType { get; set; } = null!;

    public bool QuestionRequired { get; set; }

    public string QuestionStatus { get; set; } = null!;

    public int? BlockFacility { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual ICollection<CustomQuestionFacilityDd> CustomQuestionFacilityDds { get; set; } = new List<CustomQuestionFacilityDd>();

    public virtual FacilitySpace? FacilitySpaceKeyNavigation { get; set; }
}
