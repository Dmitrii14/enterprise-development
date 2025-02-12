namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for retrieving organization data.
/// </summary>
public class OrganizationGetDto
{
    /// <summary>
    /// OrganizationId - the id of the organization
    /// </summary>
    public int OrganizationId { get; set; }
    /// <summary>
    /// OrganizationName - organization's name
    /// </summary>
    public string OrganizationName { get; set; } = string.Empty;
}