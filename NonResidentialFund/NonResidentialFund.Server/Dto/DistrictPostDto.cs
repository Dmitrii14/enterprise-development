namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for creating or updating district data.
/// </summary>
public class DistrictPostDto
{
    /// <summary>
    /// DistrictName - district's name
    /// </summary>
    public string DistrictName { get; set; } = string.Empty;
}