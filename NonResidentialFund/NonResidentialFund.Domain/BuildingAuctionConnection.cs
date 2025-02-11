using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonResidentialFund.Domain;

/// <summary>
/// BuildingAuctionConnection - class that describes the relationship between the auction and the buildings offered at that auction
/// </summary>
public class BuildingAuctionConnection
{
    /// <summary>
    /// Id - Id of the BuildingAuctionConnection object
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// BuildingId - The id of the building being auctioned off
    /// </summary>
    [ForeignKey(nameof(Building))]
    public int BuildingId { get; set; }

    /// <summary>
    /// Building - the building object.
    /// </summary>
    public Building? Building { get; set; } // Помечено как nullable

    /// <summary>
    /// AuctionID - is the auction ID.
    /// </summary>
    [ForeignKey(nameof(Auction))]
    public int AuctionId { get; set; }

    /// <summary>
    /// Auction - the auction object.
    /// </summary>
    public Auction? Auction { get; set; } // Помечено как nullable

    /// <summary>
    /// Empty constructor for serialization or other purposes
    /// </summary>
    public BuildingAuctionConnection() { }

    /// <summary>
    /// Constructor with parameters for creating an object
    /// </summary>
    public BuildingAuctionConnection(int buildingId, int auctionId)
    {
        BuildingId = buildingId;
        AuctionId = auctionId;
    }
}
