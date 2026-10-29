using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class WebTestimonial
{
    public int WebTestimonialKey { get; set; }

    public int OrganizationKey { get; set; }

    public string? SubmitterName { get; set; }

    public DateTime DateSubmitted { get; set; }

    /// <summary>
    /// (U)nread, (R)ead
    /// </summary>
    public string? TestimonialStatus { get; set; }

    public string? TestimonialContent { get; set; }
}
