namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for creating or updating organization data.
/// </summary>
public class OrganizationPostDto
{
    /// <summary>
    /// OrganizationName - organization's name
    /// </summary>
    public string OrganizationName { get; set; } = string.Empty;
}