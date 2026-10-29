using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipNote
{
    public int MembershipNotesKey { get; set; }

    public int OrganizationKey { get; set; }

    public int MembershipKey { get; set; }

    public string MembershipNote1 { get; set; } = null!;

    public DateTime? MembershipNoteDate { get; set; }

    public string MembershipNoteStatus { get; set; } = null!;

    public string NoteAddedBy { get; set; } = null!;
}
