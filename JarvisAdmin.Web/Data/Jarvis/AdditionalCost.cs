using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class AdditionalCost
{
    public int AdditionalCostKey { get; set; }

    public int OrganizationKey { get; set; }

    public int SeasonKey { get; set; }

    public string ItemDescription { get; set; } = null!;

    public decimal PricePerUnit { get; set; }

    public int DisplayOrder { get; set; }

    public string ItemStatus { get; set; } = null!;

    public bool ItemRequired { get; set; }

    public bool SizeManual { get; set; }

    public bool ShowOnRegistrationForm { get; set; }

    public bool OrderMoreThan1 { get; set; }

    public string? LastUpdatedBy { get; set; }

    public virtual ICollection<AdditionalCostColor> AdditionalCostColors { get; set; } = new List<AdditionalCostColor>();

    public virtual ICollection<AdditionalCostSize> AdditionalCostSizes { get; set; } = new List<AdditionalCostSize>();

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual ICollection<RegistrantAdditionalCost> RegistrantAdditionalCosts { get; set; } = new List<RegistrantAdditionalCost>();

    public virtual Season SeasonKeyNavigation { get; set; } = null!;
}
