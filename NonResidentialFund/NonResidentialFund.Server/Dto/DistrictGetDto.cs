namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for retrieving district data.
/// </summary>
public class DistrictGetDto
{
    /// <summary>
    /// DistrictId - the id of the district
    /// </summary>
    public int DistrictId { get; set; }
    /// <summary>
    /// DistrictName - district's name
    /// </summary>
    public string DistrictName { get; set; } = string.Empty;
}