﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonResidentialFund.Domain;
/// <summary>
/// Building - a class that describes characteristics of a building
/// </summary>
public class Building
{
    /// <summary>
    /// RegistrationNumber - registration number of building
    /// </summary>
    [Key]
    public int RegistrationNumber { get; set; }

    /// <summary>
    /// Address - a string that store address of building
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// DistrictId - id of the district in which the building is located
    /// </summary>
    [ForeignKey(nameof(District))]
    public int DistrictId { get; set; }

    /// <summary>
    /// District - the navigation property is a link to the District object 
    /// </summary>
    public District? District { get; set; }

    /// <summary>
    /// Area - Building area
    /// </summary>
    public double Area { get; set; }

    /// <summary>
    /// FloorCount - count of floors in building
    /// </summary>
    public int FloorCount { get; set; } = 1;

    /// <summary>
    /// BuildDate - date of building construction
    /// </summary>
    public DateTime BuildDate { get; set; }

    /// <summary>
    /// Auctions - list of auctions for which the building was offered
    /// </summary>
    [InverseProperty(nameof(Building))]
    public List<BuildingAuctionConnection> Auctions { get; set; } = null!;

    /// <summary>
    /// Default constructor for the Building class.
    /// </summary>
    public Building() { }

    /// <summary>
    /// Constructor for the Building class, allowing initialization of all properties when creating an object.
    /// </summary>
    public Building(int regNum, string address, int districtId, double area, int flourCount, DateTime buildDate, List<BuildingAuctionConnection> auctions)
    {
        RegistrationNumber = regNum;
        Address = address;
        DistrictId = districtId;
        Area = area;
        FloorCount = flourCount;
        BuildDate = buildDate;
        Auctions = auctions;
    }
}