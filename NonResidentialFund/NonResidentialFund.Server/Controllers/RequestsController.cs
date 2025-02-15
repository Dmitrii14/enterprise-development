﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

/// <summary>
/// Controller for handling requests related to non-residential fund operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly NonResidentialFundContext _context;
    private readonly ILogger<RequestsController> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Gets or sets the factory for creating instances of NonResidentialFundContext.
    /// </summary>
    public RequestsController(NonResidentialFundContext context, ILogger<RequestsController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns information about all customers
    /// </summary>
    /// <returns>List of buyers</returns>
    [HttpGet("GetAllCustomers")]
    public async Task<IEnumerable<BuyerGetDto>> GetAllCustomers()
    {
        _logger.LogInformation("Get all buyers");
        var buyers = await _context.Buyers.ToListAsync();
        return _mapper.Map<IEnumerable<BuyerGetDto>>(buyers);
    }

    /// <summary>
    /// Output information on auctions in which all auctioned buildings were not sold
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAuctionsNotAllLotsSold")]
    public async Task<IEnumerable<AuctionGetDto>> GetAuctionsNotAllLotsSold()
    {
        _logger.LogInformation("Get information on auctions in which all auctioned buildings were not sold");
        var result = await (from auction in _context.Auctions
                            join countBoughtInAuction in (
                                  from privatized in _context.Privatized
                                  group privatized by privatized.AuctionId into privGroup
                                  select new
                                  {
                                      privGroup.First().AuctionId,
                                      countBought = privGroup.Count()
                                  })
                                  on auction.AuctionId equals countBoughtInAuction.AuctionId
                            where countBoughtInAuction.countBought != auction.Buildings.Count
                            select auction).ToListAsync();
        return _mapper.Map<IEnumerable<AuctionGetDto>>(result);
    }

    /// <summary>
    /// Output the information about the buyers who received the nonresidential fund for a certain the district of the city, and the total amount of privatized fund of the district. Arrange by full name
    /// </summary>
    /// <param name="id">District id</param>
    /// <returns>List of buyers</returns>
    [HttpGet("GetBuyersInSpecifiedDistrict/{id}")]
    public async Task<IEnumerable<BuyerGetDto>> GetBuyersInSpecifiedDistrict(int id)
    {
        var result = await (from buyer in _context.Buyers
                            join privatized in _context.Privatized on buyer.BuyerId equals privatized.BuyerId
                            join building in _context.Buildings on privatized.RegistrationNumber equals building.RegistrationNumber
                            join districtCountSold in (
                                  from building in _context.Buildings
                                  join privatized in _context.Privatized on building.RegistrationNumber equals privatized.RegistrationNumber
                                  group new { privatized, building } by building.DistrictId into privGroupByDistrict
                                  select new
                                  {
                                      privGroupByDistrict.First().building.DistrictId,
                                      CountSold = privGroupByDistrict.Count()
                                  }
                            ) on building.DistrictId equals districtCountSold.DistrictId
                            where building.DistrictId == id && districtCountSold.CountSold > 0
                            orderby buyer.LastName, buyer.FirstName ascending
                            select buyer).ToListAsync();
        return _mapper.Map<IEnumerable<BuyerGetDto>>(result);
    }

    /// <summary>
    /// Find the addresses of all buyers participating in the auction of the specified date (Date format: 2022-03-21)
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAddressesOfAuctionParticipantsInSpecifiedDate/{date:DateTime}")]
    public async Task<IEnumerable<BuyerAddressDto>> AddressesOfAuctionParticipantsInSpecifiedDate(DateTime date)
    {
        var result = await (from auction in _context.Auctions
                            from participant in auction.Buyers
                            join buyer in _context.Buyers on participant.BuyerId equals buyer.BuyerId
                            where auction.Date == date
                            select buyer).ToListAsync();
        return _mapper.Map<IEnumerable<BuyerAddressDto>>(result);
    }

    /// <summary>
    /// Returns the top 5 buyers who spent the most money
    /// </summary>
    /// <returns>List of buyers ids and their expenses </returns>
    [HttpGet("GetTopBuyersByExpenses")]
    public async Task<IEnumerable<BuyerExpensesDto>> GetTopBuyersByExpenses()
    {
        var result = await (from privatized in _context.Privatized
                            join buyer in _context.Buyers on privatized.BuyerId equals buyer.BuyerId
                            group privatized by privatized.BuyerId into privGroup
                            orderby privGroup.Sum(privatized => privatized.EndPrice) descending
                            select new BuyerExpensesDto()
                            {
                                BuyerId = privGroup.Key,
                                Expenses = privGroup.Sum(privatized => privatized.EndPrice)
                            }).Take(5).ToListAsync();
        return result;
    }

    /// <summary>
    /// Returns the data on the auctions that brought the most profit
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAuctionsWithHighestIncome")]
    public async Task<IEnumerable<AuctionIncomeDto>> GetAuctionsWithHighestIncome()
    {
        var result = await (from privatized in _context.Privatized
                            join auction in _context.Auctions on privatized.AuctionId equals auction.AuctionId
                            group privatized by privatized.AuctionId into privGroup
                            orderby privGroup.Sum(privatized => privatized.EndPrice - privatized.StartPrice) descending
                            select new AuctionIncomeDto
                            {
                                AuctionId = privGroup.Key, // Используем Key вместо First().AuctionId для корректного получения ID аукциона.
                                Income = privGroup.Sum(privatized => privatized.EndPrice - privatized.StartPrice)
                            }).ToListAsync();
        return result;
    }
}