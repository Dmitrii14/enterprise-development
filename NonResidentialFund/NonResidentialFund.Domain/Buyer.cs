﻿namespace NonResidentialFund.Domain;
/// <summary>
/// Buyer - a class that describes characteristics of a buyer
/// </summary>
public class Buyer
{
    /// <summary>
    /// BuyerId - the id of the buyer
    /// </summary>
    public int BuyerId { get; set; }
    /// <summary>
    /// LastName - buyer's last name
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// FirstName - buyer's first name
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// MiddleName - buyer's middle name
    /// </summary>
    public string MiddleName { get; set; }
    /// <summary>
    /// PassportSeries - buyer's passport series
    /// </summary>
    public string PassportSeries { get; set; }
    /// <summary>
    /// PassportNumber - buyer's passpoer number
    /// </summary>
    public string PassportNumber { get; set; }
    /// <summary>
    /// Address - buyer's residence address 
    /// </summary>
    public string Address { get; set; }
    /// <summary>
    /// Auctions - List of auctions in which the buyer participated
    /// </summary>
    public List<BuyerAuctionConnection> Auctions;

    public Buyer(int buyerId, string lastName, string firstName, string middleName,
        string passportSeries, string passportNumber, string address, List<BuyerAuctionConnection> auctions)
    {
        BuyerId = buyerId;
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        PassportSeries = passportSeries;
        PassportNumber = passportNumber;
        Address = address;
        Auctions = auctions;
    }
}