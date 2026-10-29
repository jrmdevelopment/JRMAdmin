using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebTestimonialNote
{
    public int WebTestimonialNoteKey { get; set; }

    public int WebTestimonialKey { get; set; }

    public DateTime DateNoteAdded { get; set; }

    public string NoteAddedBy { get; set; } = null!;

    public string TestimonialNote { get; set; } = null!;
}
