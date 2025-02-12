namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for retrieving building data.
/// </summary>
public class BuildingGetDto
{
    /// <summary>
    /// RegistrationNumber - registration number of building
    /// </summary>
    public int RegistrationNumber { get; set; }
    /// <summary>
    /// Address - a string that store address of building
    /// </summary>
    public string Address { get; set; } = string.Empty;
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
    public DateTime BuildDate { get; set; } = new DateTime();
}