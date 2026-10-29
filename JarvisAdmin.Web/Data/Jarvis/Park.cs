using System;
using System.Collections.Generic;

namespace JarvisAdmin.Web.Data.Jarvis;

public partial class Park
{
    public int ParkKey { get; set; }

    public int OrganizationKey { get; set; }

    public string ParkName { get; set; } = null!;

    public string ParkCity { get; set; } = null!;

    public string? DirectionsToPark { get; set; }

    public string? ParkMapLink { get; set; }

    public string? DescriptionOfPark { get; set; }

    public bool? PlaygroundEquipment { get; set; }

    public bool? WalkingPath { get; set; }

    public int? NbrOfShelters { get; set; }

    public bool? Restrooms { get; set; }

    public bool? ConcessionsBldg { get; set; }

    public int? NbrOfBallFields { get; set; }

    public bool? BasketballGoals { get; set; }

    public bool? PicnicTables { get; set; }

    public bool? OutsideGrills { get; set; }

    public bool? VolleyballCourt { get; set; }

    public bool? Horseshoes { get; set; }

    public bool? Gazebo { get; set; }

    public bool? ElectricityAvailable { get; set; }

    public bool? WaterAvailable { get; set; }

    public bool? Benches { get; set; }

    public string? ParkImageName { get; set; }

    public string? ParkImageNameLg { get; set; }

    public string? ParkStatus { get; set; }

    public int? XCityKey { get; set; }

    public string? XParkSt { get; set; }

    public string? XParkZipcode { get; set; }

    public virtual Organization OrganizationKeyNavigation { get; set; } = null!;

    public virtual City? XCityKeyNavigation { get; set; }
}
