using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AccountNote
{
    public int AccountNoteKey { get; set; }

    public int AccountKey { get; set; }

    public string AccountNotes { get; set; } = null!;

    public string? NoteAddedBy { get; set; }

    public DateTime? NoteDateTime { get; set; }

    public string NoteStatus { get; set; } = null!;

    public virtual Account AccountKeyNavigation { get; set; } = null!;
}
