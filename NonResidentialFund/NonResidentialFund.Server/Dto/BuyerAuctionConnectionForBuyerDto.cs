namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for representing the connection between a buyer and an auction from the buyer's perspective.
/// </summary>
public class BuyerAuctionConnectionForBuyerDto
{
    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>
    public int AuctionId { get; set; }
}