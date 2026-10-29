using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class FacilityComplex
{
    public int FacilityComplexKey { get; set; }

    public int OrganizationKey { get; set; }

    public string ComplexName { get; set; } = null!;

    public string ComplexStatus { get; set; } = null!;

    public string? DirectionsToComplex { get; set; }

    public string? MapLink { get; set; }

    public string? ComplexAddress { get; set; }

    public int? CityKey { get; set; }

    public string? ComplexState { get; set; }

    public string? ComplexZipCode { get; set; }

    public string LastUpdatedBy { get; set; } = null!;
}
