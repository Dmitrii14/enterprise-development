﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonResidentialFund.Domain;
/// <summary>
/// Auction - a class that describes characteristics of a auction
/// </summary>
public class Auction
{
    /// <summary>
    /// AuctionId - unique key of auction
    /// </summary>
    [Key]
    public int AuctionId { get; set; }

    /// <summary>
    /// Date - auction date
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// OrganizationId - the id of the organization that organized the auction
    /// </summary>
    [ForeignKey(nameof(Auction))]
    public int OrganizationId { get; set; }

    /// <summary>
    /// Buildings - List of buildings that were auctioned off
    /// </summary>
    [InverseProperty(nameof(Auction))]
    public List<BuildingAuctionConnection> Buildings { get; set; } = null!;

    /// <summary>
    /// Buyers - List of buyers participating in the auction
    /// </summary>
    [InverseProperty(nameof(Auction))]
    public List<BuyerAuctionConnection> Buyers { get; set; } = null!;

    /// <summary>
    /// Default constructor for the Auction class
    /// </summary>
    public Auction() { }

    /// <summary>
    /// Constructor for the Auction class, allowing initialization of all properties when creating an object
    /// </summary>
    public Auction(int auctionId, DateTime date, int organizationId, List<BuildingAuctionConnection> buildings, List<BuyerAuctionConnection> buyers)
    {
        AuctionId = auctionId;
        Date = date;
        OrganizationId = organizationId;
        Buildings = buildings;
        Buyers = buyers;
    }
}