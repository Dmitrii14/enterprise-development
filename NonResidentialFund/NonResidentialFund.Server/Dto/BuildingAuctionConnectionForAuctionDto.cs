namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for representing the connection between a building and an auction.
/// </summary>
public class BuildingAuctionConnectionForAuctionDto
{
    /// <summary>
    /// BuildingId - The id of the building being auctioned off
    /// </summary>
    public int BuildingId { get; set; }
}
