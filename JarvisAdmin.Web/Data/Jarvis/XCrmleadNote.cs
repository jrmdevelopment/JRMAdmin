using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class XCrmleadNote
{
    public int CrmleadNoteKey { get; set; }

    public int CrmleadKey { get; set; }

    public DateTime NoteDate { get; set; }

    public string? NoteText { get; set; }

    public string? CallOutcome { get; set; }
}
