﻿namespace NonResidentialFund.Domain;
/// <summary>
/// BuyerAuctionConnection - class that describes the relationship between the auction and the buyers participating in the auction
/// </summary>
public class BuyerAuctionConnection
{
    /// <summary>
    /// BuyerId - the id of the buyer participating in the auction
    /// </summary>
    public int BuyerId { get; set; }
    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>
    public int AuctionId { get; set; }

    public BuyerAuctionConnection(int buyerId, int auctionId)
    {
        BuyerId = buyerId;
        AuctionId = auctionId;
    }
}