﻿namespace NonResidentialFund.Domain;
/// <summary>
/// BuildingAuctionConnection - class that describes the relationship between the auction and the buildings offered at that auction
/// </summary>
public class BuildingAuctionConnection
{
    /// <summary>
    /// BuildingId - The id of the building being auctioned off
    /// </summary>
    public int BuildingId { get; set; }
    /// <summary>
    /// AuctionId - The id of auction
    /// </summary>
    public int AuctionId { get; set; }

    public BuildingAuctionConnection(int buildingId, int auctionId)
    {
        BuildingId = buildingId;
        AuctionId = auctionId;
    }
}