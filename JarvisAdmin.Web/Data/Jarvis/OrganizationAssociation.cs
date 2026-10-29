using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

/// <summary>
/// Allows Jarvis customers to share fields with each other. Used for game management and notifications between cities.
/// </summary>
public partial class OrganizationAssociation
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    public int OrganizationAssociationKey { get; set; }

    /// <summary>
    /// This is the organization that owns the fields. They control the field configuration and field status (open/closed).
    /// </summary>
    public int MainOrganization { get; set; }

    /// <summary>
    /// This is the organization the main organization is sharing the field with. This organization cannot make any changes to the facility configuration. They can only view it&apos;s schedule and use it for scheduling.
    /// </summary>
    public int AssociatedOrganization { get; set; }

    /// <summary>
    /// when one organization sending emails on behalf of the other, who do the reply emails go to?
    /// </summary>
    public string? ReplyToEmail { get; set; }

    /// <summary>
    /// An email of someone from the associated organization that wishes to be notified if the field status changes.
    /// </summary>
    public string? NotifyEmail1 { get; set; }

    /// <summary>
    /// An email of someone from the associated organization that wishes to be notified if the field status changes.
    /// </summary>
    public string? NotifyEmail2 { get; set; }

    /// <summary>
    /// An email of someone from the associated organization that wishes to be notified if the field status changes.
    /// </summary>
    public string? NotifyEmail3 { get; set; }

    /// <summary>
    /// The cell phone number of someone from the associated organization that wishes to be notified if the field status changes. They will receive a text to this number.
    /// </summary>
    public string? NotifyText1 { get; set; }

    /// <summary>
    /// The cell phone number of someone from the associated organization that wishes to be notified if the field status changes. They will receive a text to this number.
    /// </summary>
    public string? NotifyText2 { get; set; }

    /// <summary>
    /// The cell phone number of someone from the associated organization that wishes to be notified if the field status changes. They will receive a text to this number.
    /// </summary>
    public string? NotifyText3 { get; set; }

    public bool? AllowAssociatedCity { get; set; }

    public virtual Organization AssociatedOrganizationNavigation { get; set; } = null!;

    public virtual Organization MainOrganizationNavigation { get; set; } = null!;
}
