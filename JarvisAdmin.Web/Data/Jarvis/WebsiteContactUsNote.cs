using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebsiteContactUsNote
{
    public int WebsiteContactUsNoteKey { get; set; }

    public int WebsiteContactUsKey { get; set; }

    public DateTime DateNoteAdded { get; set; }

    public string NoteAddedBy { get; set; } = null!;

    public string ContactUsNote { get; set; } = null!;
}
