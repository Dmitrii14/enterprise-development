using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

/// <summary>
/// Controller for handling buyer-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BuyerController : ControllerBase
{
    private readonly NonResidentialFundContext _context;
    private readonly ILogger<BuyerController> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the BuyerController class using dependency injection to set up logger, repository, and mapper instances.
    /// </summary>
    public BuyerController(NonResidentialFundContext context, ILogger<BuyerController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all buyers
    /// </summary>
    /// <returns>List of buyers</returns>
    [HttpGet]
    public async Task<IEnumerable<BuyerGetDto>> Get()
    {
        _logger.LogInformation("Get all buyers");
        var buyers = await _context.Buyers.ToListAsync();
        return _mapper.Map<IEnumerable<BuyerGetDto>>(buyers);
    }

    /// <summary>
    /// Returns the buyer by the specified id
    /// </summary>
    /// <param name="id">id of the buyer</param>
    /// <returns>Result of operation and buyer object</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<BuyerGetDto>> Get(int id)
    {
        var buyer = await _context.Buyers.FirstOrDefaultAsync(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get buyer with id: {id}", id);
            return Ok(_mapper.Map<BuyerGetDto>(buyer));
        }
    }

    /// <summary>
    /// Creates new buyer
    /// </summary>
    /// <param name="buyer">Buyer to be created</param>
    [HttpPost]
    public async Task<ActionResult<BuyerGetDto>> Post([FromBody] BuyerPostDto buyer)
    {
        _logger.LogInformation("Created new buyer");
        var buyerToAdd = _mapper.Map<Buyer>(buyer);
        await _context.Buyers.AddAsync(buyerToAdd);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<BuyerGetDto>(buyerToAdd));
    }

    /// <summary>
    /// Changes the buyer by the specified id
    /// </summary>
    /// <param name="id">Id of the buyer to be changed</param>
    /// <param name="buyerToPut">New buyer data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<BuyerGetDto>> Put(int id, [FromBody] BuyerPostDto buyerToPut)
    {
        var buyer = await _context.Buyers.FirstOrDefaultAsync(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(buyerToPut, buyer);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<BuyerGetDto>(buyer));
        }
    }

    /// <summary>
    /// Removes the buyer by the specified id
    /// </summary>
    /// <param name="id">Id of the buyer to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var buyer = await _context.Buyers.FirstOrDefaultAsync(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Returns auctions in which the specified buyer participated
    /// </summary>
    /// <param name="id">Id of the buyer</param>
    /// <returns>List of auctions, in which the specified buyer participated</returns>
    [HttpGet("{id}/Auctions")]
    public async Task<ActionResult<IEnumerable<BuyerAuctionConnectionForBuyerDto>>> GetAuctions(int id)
    {
        var buyer = await _context.Buyers
        .Include(buyer => buyer.Auctions)
        .FirstOrDefaultAsync(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get auctions in which the buyer with id {id} participated", id);
            return Ok(_mapper.Map<IEnumerable<BuyerAuctionConnectionForBuyerDto>>(buyer.Auctions));
        }
    }

    /// <summary>
    /// Adds a new auction to the list of auctions in which the specified buyer participated
    /// </summary>
    /// <param name="id">Id of the buyer</param>
    /// <param name="connection">Auction to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{id}/Auctions")]
    public async Task<ActionResult<BuyerAuctionConnectionForBuyerDto>> PostAuction(int id, [FromBody] BuyerAuctionConnectionForBuyerDto connection)
    {
        var buyer = await _context.Buyers
        .Include(buyer => buyer.Auctions)
        .FirstOrDefaultAsync(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.AuctionId == connection.AuctionId);
        if (auction != null && buyer.Auctions.FirstOrDefault(conn => conn.AuctionId == connection.AuctionId) == null)
        {
            var connectionToAdd = new BuyerAuctionConnection(id, connection.AuctionId);
            buyer.Auctions.Add(connectionToAdd);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<BuyerAuctionConnectionForBuyerDto>(connectionToAdd));
        }
        else
            return BadRequest();
    }

    /// <summary>
    /// Removes a auction from the list of auctions in which the specified buyer participated
    /// </summary>
    /// <param name="id">Id of the buyer</param>
    /// <param name="connection">Auction to be remove</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}/Auctions")]
    public async Task<IActionResult> DeleteAuction(int id, [FromBody] BuyerAuctionConnectionForBuyerDto connection)
    {
        var buyer = await _context.Buyers
        .Include(buyer => buyer.Auctions)
        .FirstOrDefaultAsync(buyer => buyer.BuyerId == id);
        if (buyer == null)
        {
            _logger.LogInformation("Not found buyer with id: {id}", id);
            return NotFound();
        }
        var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.AuctionId == connection.AuctionId);
        var connectionToDelete = buyer.Auctions.FirstOrDefault(conn => conn.AuctionId == connection.AuctionId);
        if (connectionToDelete != null)
        {
            buyer.Auctions.Remove(connectionToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }
        else
            return BadRequest();
    }
}