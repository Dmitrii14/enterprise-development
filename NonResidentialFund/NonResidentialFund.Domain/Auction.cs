namespace NonResidentialFund.Domain;
/// <summary>
/// Auction - a class that describes characteristics of a auction
/// </summary>
public class Auction
{
    /// <summary>
    /// AuctionId - unique key of auction
    /// </summary>
    public int AuctionId { get; set; }
    /// <summary>
    /// Date - auction date
    /// </summary>
    public DateOnly Date { get; set; }
    /// <summary>
    /// OrganizationId - the id of the organization that organized the auction
    /// </summary>
    public int OrganizationId { get; set; }
    /// <summary>
    /// Buildings - List of buildings that were auctioned off
    /// </summary>
    public List<BuildingAuctionConnection> Buildings { get; set; }
    /// <summary>
    /// Buyers - List of buyers participating in the auction
    /// </summary>
    public List<BuyerAuctionConnection> Buyers { get; set; }

    public Auction(int auctionId, DateOnly date, int organizationId, List<BuildingAuctionConnection> buildings, List<BuyerAuctionConnection> buyers)
    {
        AuctionId = auctionId;
        Date = date;
        OrganizationId = organizationId;
        Buildings = buildings;
        Buyers = buyers;
    }
}