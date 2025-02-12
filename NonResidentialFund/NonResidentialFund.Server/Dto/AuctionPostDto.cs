namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for creating or updating auction data.
/// </summary>
public class AuctionPostDto
{
    /// <summary>
    /// Date - auction date
    /// </summary>
    public DateTime Date { get; set; } = new DateTime();
    /// <summary>
    /// OrganizationId - the id of the organization that organized the auction
    /// </summary>
    public int OrganizationId { get; set; }
}