using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class CustomQuestionDd
{
    public int CustomQuestionDdkey { get; set; }

    public int CustomQuestionKey { get; set; }

    public string DropdownText { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public string? LastUpdatedBy { get; set; }

    public decimal? AssociatedCost { get; set; }

    public virtual CustomQuestion CustomQuestionKeyNavigation { get; set; } = null!;
}
