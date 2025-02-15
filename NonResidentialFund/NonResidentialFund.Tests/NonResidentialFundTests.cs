﻿namespace NonResidentialFund.Tests;
public class NonResidentialFundTests
{
    private NonResidentialFundFixture _fixture = new();

    /// <summary>
    /// First request: display information about all customers
    /// </summary>
    [Fact]
    public void AllCustomersRequestTest()
    {
        var fixtureBuyers = _fixture.FixtureBuyers;
        var buyers = (from buyer in fixtureBuyers select buyer).ToList();

        Assert.Equal(8, fixtureBuyers.Count);
        Assert.Contains(buyers, buyer => buyer.BuyerId == 1);
        Assert.Contains(buyers, buyer => buyer.BuyerId == 2);
        Assert.Contains(buyers, buyer => buyer.BuyerId == 3);
        Assert.Contains(buyers, buyer => buyer.BuyerId == 4);
        Assert.Contains(buyers, buyer => buyer.BuyerId == 5);
        Assert.Contains(buyers, buyer => buyer.BuyerId == 6);
        Assert.Contains(buyers, buyer => buyer.BuyerId == 7);
        Assert.Contains(buyers, buyer => buyer.BuyerId == 8);
    }

    /// <summary>
    /// Second request: Output information on auctions in which all auctioned buildings were not sold.
    /// </summary>
    [Fact]
    public void AuctionsNotAllLotsSoldRequestTest()
    {
        var result = (from auction in _fixture.FixtureAuctions
                      join countBoughtInAuction in (
                            from privatized in _fixture.FixturePrivatized
                            group privatized by privatized.AuctionId into privGroup
                            select new
                            {
                                privGroup.First().AuctionId,
                                countBought = privGroup.Count()
                            })
                            on auction.AuctionId equals countBoughtInAuction.AuctionId
                      where countBoughtInAuction.countBought != auction.Buildings.Count
                      select auction.AuctionId).ToList();

        Assert.Equal(2, result.Count);
        Assert.Contains(result, auctionId => auctionId == 1);
        Assert.Contains(result, auctionId => auctionId == 5);
    }

    /// <summary>
    /// Third request: Output the information about the buyers who received the nonresidential fund for a certain the district of the city, 
    /// and the total amount of privatized fund of the district. Arrange by full name
    /// </summary>
    [Fact]
    public void BuyersInSpecifiedDistrictRequestTest()
    {
        var result = (from buyer in _fixture.FixtureBuyers
                      join privatized in _fixture.FixturePrivatized on buyer.BuyerId equals privatized.BuyerId
                      join building in _fixture.FixtureBuildings on privatized.RegistrationNumber equals building.RegistrationNumber
                      join districtCountSold in (
                            from building in _fixture.FixtureBuildings
                            join privatized in _fixture.FixturePrivatized on building.RegistrationNumber equals privatized.RegistrationNumber
                            group new { privatized, building } by building.DistrictId into privGroupByDistrict
                            select new
                            {
                                privGroupByDistrict.First().building.DistrictId,
                                CountSold = privGroupByDistrict.Count()
                            }
                      ).ToList() on building.DistrictId equals districtCountSold.DistrictId
                      where building.DistrictId == 1
                      orderby buyer.LastName, buyer.FirstName
                      select new { buyer.BuyerId, buyer.LastName, buyer.FirstName, buyer.MiddleName, districtCountSold.CountSold }).ToList();

        Assert.Equal(3, result.Count);
        Assert.Equal(3, result.First().CountSold);
        Assert.Equal("Аскерова", result.First().LastName);
        Assert.Contains(result, buyer => buyer.BuyerId == 1);
        Assert.Contains(result, buyer => buyer.BuyerId == 4);
        Assert.Contains(result, buyer => buyer.BuyerId == 8);
    }

    /// <summary>
    /// Fourth request: Find the addresses of all buyers participating in the auction of the specified date
    /// </summary>
    [Fact]
    public void AddressesOfAuctionParticipantsInSpecifiedDateRequestTest()
    {
        var result = (from auction in _fixture.FixtureAuctions
                      from participant in auction.Buyers
                      join buyer in _fixture.FixtureBuyers on participant.BuyerId equals buyer.BuyerId
                      where auction.Date == new DateTime(2022, 3, 21)
                      select new { buyer.BuyerId, buyer.Address }).ToList();
        Assert.Equal(5, result.Count);
        Assert.Contains(result, buyer => buyer.BuyerId == 1);
        Assert.Contains(result, buyer => buyer.BuyerId == 3);
        Assert.Contains(result, buyer => buyer.BuyerId == 4);
        Assert.Contains(result, buyer => buyer.BuyerId == 7);
        Assert.Contains(result, buyer => buyer.BuyerId == 8);
    }

    /// <summary>
    /// Fifth request: Find the top 5 buyers who spent the most money
    /// </summary>
    [Fact]
    public void TopBuyersByExpensesRequestTest()
    {
        var result = (from privatized in _fixture.FixturePrivatized
                      join buyer in _fixture.FixtureBuyers on privatized.BuyerId equals buyer.BuyerId
                      group privatized by privatized.BuyerId into privGroup
                      orderby privGroup.Sum(privatized => privatized.EndPrice) descending
                      select new
                      {
                          privGroup.First().BuyerId,
                          expenses = privGroup.Sum(privatized => privatized.EndPrice)
                      }).Take(5).ToList();

        Assert.Equal(4, result.Count);
        Assert.Equal(8, result.First().BuyerId);
        Assert.Equal(19028350.17, result.First().expenses);
    }

    /// <summary>
    /// Sixth request: Output the data on the auctions that brought the most profit
    /// </summary>
    [Fact]
    public void AuctionsWithHighestIncomeRequestTest()
    {
        var result = (from privatized in _fixture.FixturePrivatized
                      join auction in _fixture.FixtureAuctions on privatized.AuctionId equals auction.AuctionId
                      group privatized by privatized.AuctionId into privGRoup
                      orderby privGRoup.Sum(privatized => privatized.EndPrice - privatized.StartPrice) descending
                      select new
                      {
                          privGRoup.First().AuctionId,
                          income = privGRoup.Sum(privatized => privatized.EndPrice - privatized.StartPrice)
                      }).ToList();

        Assert.Equal(6, result.Count);
        Assert.Equal(13239763.17, result[0].income);
        Assert.Equal(3, result[0].AuctionId);
        Assert.Equal(2069090.07, result[1].income, 0.01);
        Assert.Equal(7, result[1].AuctionId);
    }
}