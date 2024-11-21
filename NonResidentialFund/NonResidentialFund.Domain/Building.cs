namespace NonResidentialFund.Domain;
/// <summary>
/// Building - a class that describes characteristics of a building
/// </summary>
public class Building
{
    /// <summary>
    /// RegistrationNumber - registration number of building
    /// </summary>
    public int RegistrationNumber { get; set; }
    /// <summary>
    /// Address - a string that store address of building
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// DistrictId - id of the district in which the building is located
    /// </summary>
    public int DistrictId { get; set; }
    /// <summary>
    /// Area - Building area
    /// </summary>
    public double Area { get; set; }
    /// <summary>
    /// FloorCount - count of floors in building
    /// </summary>
    public int FloorCount { get; set; }
    /// <summary>
    /// BuildDate - date of building construction
    /// </summary>
    public DateOnly BuildDate { get; set; }
    /// <summary>
    /// Auctions - list of auctions for which the building was offered
    /// </summary>
    public List<BuildingAuctionConnection> Auctions;
    public Building(int regNum, string address, int districtId, double area, int flourCount, DateOnly buildDate, List<BuildingAuctionConnection> auctions)
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