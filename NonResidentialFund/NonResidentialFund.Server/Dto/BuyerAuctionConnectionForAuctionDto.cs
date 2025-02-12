namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for representing the connection between a buyer and an auction from the auction's perspective.
/// </summary>
public class BuyerAuctionConnectionForAuctionDto
{
    /// <summary>
    /// BuyerId - the id of the buyer participating in the auction
    /// </summary>
    public int BuyerId { get; set; }
}