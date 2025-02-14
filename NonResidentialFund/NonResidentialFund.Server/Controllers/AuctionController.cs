using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Domain;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

/// <summary>
/// Controller for handling auction-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly NonResidentialFundContext _context;
    private readonly ILogger<AuctionController> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the AuctionController class using dependency injection to set up logger, repository, and mapper instances.
    /// </summary>
    public AuctionController(NonResidentialFundContext context, ILogger<AuctionController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all auctions
    /// </summary>
    /// <returns>List of auctions</returns>
    [HttpGet]
    public async Task<IEnumerable<AuctionGetDto>> Get()
    {
        _logger.LogInformation("Get all auctions");
        var auctions = await _context.Auctions.FindAsync();
        return _mapper.Map<IEnumerable<AuctionGetDto>>(auctions); ;
    }

    /// <summary>
    /// Returns the auction by the specified id
    /// </summary>
    /// <param name="id">id of the auction</param>
    /// <returns>Result of operation and auction object</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<AuctionGetDto>> Get(int id)
    {
        var auction = await _context.Auctions.FindAsync(id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get auction with id: {id}", id);
            return Ok(_mapper.Map<AuctionGetDto>(auction));
        }
    }

    /// <summary>
    /// Creates new auction
    /// </summary>
    /// <param name="auction">Auction to be created</param>
    [HttpPost]
    public async Task<ActionResult<AuctionGetDto>> Post([FromBody] AuctionPostDto auction)
    {
        _logger.LogInformation("Post request auctions: create auction");
        var auctionToCreate = _mapper.Map<Auction>(auction);
        await _context.Auctions.AddAsync(auctionToCreate);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<AuctionGetDto>(auctionToCreate));
    }

    /// <summary>
    /// Changes the auction by the specified id
    /// </summary>
    /// <param name="id">Id of the auction to be changed</param>
    /// <param name="auctionToPut">New auction data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<AuctionGetDto>> Put(int id, [FromBody] AuctionPostDto auctionToPut)
    {
        var auction = await _context.Auctions.FindAsync(id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Updated auction with id {id}", id);
            _mapper.Map(auctionToPut, auction);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<AuctionGetDto>(auction));
        }
    }

    /// <summary>
    /// Removes the auction by the specified id
    /// </summary>
    /// <param name="id">Id of the auction to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var auction = await _context.Auctions.FindAsync(id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Deleted auction with id: {id}", id);
            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Returns the registration numbers of the buildings that were offered at the specified auction
    /// </summary>
    /// <param name="id">Id of the auction</param>
    /// <returns>List of buildings that were offered at the specified auction</returns>
    [HttpGet("{id}/Buildings")]
    public async Task<ActionResult<IEnumerable<BuildingAuctionConnectionForAuctionDto>>> GetBuildings(int id)
    {
        var auction = await _context.Auctions
        .Include(a => a.Buildings)
        .FirstOrDefaultAsync(a => a.AuctionId == id);

        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get building offered on auction with id: {id}", id);
            return Ok(_mapper.Map<IEnumerable<BuildingAuctionConnectionForAuctionDto>>(auction.Buildings));
        }
    }

    /// <summary>
    /// Adds a new building to the list of buildings for sale at the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Building to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{id}/Buildings")]
    public async Task<ActionResult<BuildingAuctionConnectionForAuctionDto>> PostBuilding(int id, [FromBody] BuildingAuctionConnectionForAuctionDto connection)
    {
        var auction = await _context.Auctions
        .Include(a => a.Buildings)
        .FirstOrDefaultAsync(a => a.AuctionId == id);

        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }

        var building = await _context.Buildings.FirstOrDefaultAsync(building => building.RegistrationNumber == connection.BuildingId);

        if (building != null && auction.Buildings.FirstOrDefault(conn => conn.BuildingId == connection.BuildingId) == null)
        {
            var connectionToAdd = new BuildingAuctionConnection(connection.BuildingId, id);
            auction.Buildings.Add(connectionToAdd);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<BuildingAuctionConnectionForAuctionDto>(connectionToAdd));
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Removes a building from the list of buildings for sale at the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}/Buildings")]
    public async Task<IActionResult> DeleteBuilding(int id, [FromBody] BuildingAuctionConnectionForAuctionDto connection)
    {
        var auction = await _context.Auctions
        .Include(a => a.Buildings)
        .FirstOrDefaultAsync(a => a.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        var building = await _context.Buildings.FirstOrDefaultAsync(building => building.RegistrationNumber == connection.BuildingId);
        var connectionToDelete = auction.Buildings.FirstOrDefault(conn => conn.BuildingId == connection.BuildingId);
        if (connectionToDelete != null)
        {
            auction.Buildings.Remove(connectionToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Returns the id of the buyers who participated in the specified auction
    /// </summary>
    /// <param name="id">Id of the auction</param>
    /// <returns>List of buyers who participated in the specified auction</returns>
    [HttpGet("{id}/Buyers")]
    public async Task<ActionResult<IEnumerable<BuyerAuctionConnectionForAuctionDto>>> GetBuyers(int id)
    {
        var auction = await _context.Auctions
        .Include(a => a.Buyers)
        .FirstOrDefaultAsync(a => a.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get buyers participating in auction with id: {id}", id);
            return Ok(_mapper.Map<IEnumerable<BuyerAuctionConnectionForAuctionDto>>(auction.Buyers));
        }
    }

    /// <summary>
    /// Adds a new buyer to the list of buyers who participated in the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Buyer to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{id}/Buyers")]
    public async Task<ActionResult<BuyerAuctionConnectionForAuctionDto>> PostBuilding(int id, [FromBody] BuyerAuctionConnectionForAuctionDto connection)
    {
        var auction = await _context.Auctions
        .Include(a => a.Buyers)
        .FirstOrDefaultAsync(a => a.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        var buyer = await _context.Buyers.FirstOrDefaultAsync(buyer => buyer.BuyerId == connection.BuyerId);
        if (buyer != null && auction.Buyers.FirstOrDefault(conn => conn.BuyerId == connection.BuyerId) == null)
        {
            var connectionToAdd = new BuyerAuctionConnection(connection.BuyerId, id);
            auction.Buyers.Add(connectionToAdd);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<BuyerAuctionConnectionForAuctionDto>(connectionToAdd));
        }
        else
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// Removes a buyer from the list of buyers who participated in the specified auction
    /// </summary>
    /// <param name="id">Id of auction</param>
    /// <param name="connection">Buyer to be remove</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}/Buyers")]
    public async Task<IActionResult> DeleteBuyer(int id, [FromBody] BuyerAuctionConnectionForAuctionDto connection)
    {
        var auction = await _context.Auctions
        .Include(a => a.Buyers)
        .FirstOrDefaultAsync(a => a.AuctionId == id);
        if (auction == null)
        {
            _logger.LogInformation("Not found auction with id: {id}", id);
            return NotFound();
        }
        var buyer = await _context.Buyers.FirstOrDefaultAsync(buyer => buyer.BuyerId == connection.BuyerId);
        var connectionToDelete = auction.Buyers.FirstOrDefault(conn => conn.BuyerId == connection.BuyerId);
        if (connectionToDelete != null)
        {
            auction.Buyers.Remove(connectionToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
}