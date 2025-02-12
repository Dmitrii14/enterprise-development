namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for representing the connection between a building and an auction from the building's perspective.
/// </summary>
public class BuildingAuctionConnectionForBuildingDto
{
    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>
    public int AuctionId { get; set; }
}