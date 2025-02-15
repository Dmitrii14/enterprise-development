﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonResidentialFund.Domain;
/// <summary>
/// Privatized - a class that describes characteristics of a privatized building 
/// </summary>
public class Privatized
{
    /// <summary>
    /// RegistrationNumber - registration number of privatized building
    /// </summary>
    [Key]
    public int RegistrationNumber { get; set; }

    /// <summary>
    /// BuyerId - The buyer's id of building
    /// </summary>
    [ForeignKey(nameof(Building))]
    public int BuyerId { get; set; }

    /// <summary>
    /// Buyer - The navigation property is a link to the Buyer object
    /// </summary>
    public Buyer? Buyer { get; set; }
    /// <summary>
    /// AuctionId - The id of the auction at which the building was sold
    /// </summary>
    [ForeignKey(nameof(Auction))]
    public int AuctionId { get; set; }

    /// <summary>
    /// Auction - The navigation property is a link to the Auction object
    /// </summary>
    public Auction? Auction { get; set; }

    /// <summary>
    /// SaleDate - Date of sale of the building 
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// StartPrice - The starting price for this building at the auction
    /// </summary>
    public double StartPrice { get; set; }

    /// <summary>
    /// EndPrice - The final price of this building at the auction
    /// </summary>
    public double EndPrice { get; set; }

    /// <summary>
    /// Default constructor for the Privatized class.
    /// </summary>
    public Privatized() { }

    /// <summary>
    /// Constructor for the Privatized class, allowing initialization of privatization details.
    /// </summary>
    public Privatized(int registrationNumber, int buyerId, int auctionId, DateTime saleDate, double startPrice, double endPrice)
    {
        RegistrationNumber = registrationNumber;
        BuyerId = buyerId;
        AuctionId = auctionId;
        SaleDate = saleDate;
        StartPrice = startPrice;
        EndPrice = endPrice;
    }
}