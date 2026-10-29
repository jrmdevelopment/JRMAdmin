using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class MembershipDetail
{
    public int MembershipDetailKey { get; set; }

    public int MembershipKey { get; set; }

    public int MembershipTypeKey { get; set; }

    public DateTime MembershipStartDate { get; set; }

    public DateTime MembershipEndDate { get; set; }

    public decimal TotalDue { get; set; }

    public decimal TotalPaid { get; set; }

    public decimal MembershipAmount { get; set; }

    public decimal DiscountAmount { get; set; }

    public string? DiscountReason { get; set; }

    public decimal? AdjustmentAmount { get; set; }

    public string? AdjustmentReason { get; set; }

    public decimal AddlPersonCharge { get; set; }

    public decimal ConvenienceFee { get; set; }

    public decimal LostCardCharge { get; set; }

    public decimal? NsffeeTotal { get; set; }

    public bool? AcknowledgeOnline { get; set; }

    public DateTime? DraftReconcileDate { get; set; }

    public DateTime DateAdded { get; set; }

    public string AddedBy { get; set; } = null!;

    public string? LastUpdatedBy { get; set; }

    public virtual Membership MembershipKeyNavigation { get; set; } = null!;

    public virtual MembershipType MembershipTypeKeyNavigation { get; set; } = null!;

    public virtual ICollection<PaymentMembership> PaymentMemberships { get; set; } = new List<PaymentMembership>();
}
