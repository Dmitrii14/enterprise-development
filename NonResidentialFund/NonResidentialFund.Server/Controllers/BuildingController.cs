using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

/// <summary>
/// Controller for handling building-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BuildingController : ControllerBase
{
    private readonly NonResidentialFundContext _context;
    private readonly ILogger<BuildingController> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the BuildingController class using dependency injection to set up logger, repository, and mapper instances.
    /// </summary>
    public BuildingController(NonResidentialFundContext context, ILogger<BuildingController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all buildings
    /// </summary>
    /// <returns>List of buildings</returns>
    [HttpGet]
    public async Task<IEnumerable<BuildingGetDto>> Get()
    {
        _logger.LogInformation("Get all buildings");
        var buildings = await _context.Buildings.ToListAsync();
        return _mapper.Map<IEnumerable<BuildingGetDto>>(buildings);
    }

    /// <summary>
    /// Returns the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">registration number of the building</param>
    /// <returns>Result of operation and building object</returns>
    [HttpGet("{registrationNumber}")]
    public async Task<ActionResult<BuildingGetDto>> Get(int registrationNumber)
    {
        var building = await _context.Buildings.FirstOrDefaultAsync(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get building with registration number: {registrationNumber}", registrationNumber);
            return Ok(_mapper.Map<BuildingGetDto>(building));
        }
    }

    /// <summary>
    /// Creates new building
    /// </summary>
    /// <param name="building">Building to be created</param>
    [HttpPost]
    public async Task<ActionResult<BuildingGetDto>> Post([FromBody] BuildingPostDto building)
    {
        _logger.LogInformation("Created new building");
        var buildingToAdd = _mapper.Map<Building>(building);
        await _context.Buildings.AddAsync(buildingToAdd);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<BuildingGetDto>(buildingToAdd));
    }

    /// <summary>
    /// Changes the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building to be changed</param>
    /// <param name="buildingToPut">New building data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{registrationNumber}")]
    public async Task<ActionResult<BuildingGetDto>> Put(int registrationNumber, [FromBody] BuildingPostDto buildingToPut)
    {
        var building = await _context.Buildings.FirstOrDefaultAsync(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Updated building with registration number {registrationNumber}", registrationNumber);
            _mapper.Map(buildingToPut, building);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<BuildingGetDto>(building));
        }
    }

    /// <summary>
    /// Removes the building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}")]
    public async Task<IActionResult> Delete(int registrationNumber)
    {
        var building = await _context.Buildings.FirstOrDefaultAsync(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Deleted building with registration number {registrationNumber}", registrationNumber);
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    /// <summary>
    /// Returning auctions, in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building</param>
    /// <returns>List of auctions, in which the building was put up for sale</returns>
    [HttpGet("{registrationNumber}/Auctions")]
    public async Task<ActionResult<IEnumerable<BuildingAuctionConnectionForBuildingDto>>> GetAuctions(int registrationNumber)
    {
        var building = await _context.Buildings
        .Include(building => building.Auctions)
        .FirstOrDefaultAsync(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get auctions in which the building with registration number {registrationNumber} was put up for sale", registrationNumber);
            return Ok(_mapper.Map<IEnumerable<BuildingAuctionConnectionForBuildingDto>>(building.Auctions));
        }
    }

    /// <summary>
    /// Adds a new auction to the list of auctions in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of the building</param>
    /// <param name="connection">Auction to be add</param>
    /// <returns>Result of operation</returns>
    [HttpPost("{registrationNumber}/Auctions")]
    public async Task<ActionResult<BuildingAuctionConnectionForBuildingDto>> PostAuction(int registrationNumber, [FromBody] BuildingAuctionConnectionForBuildingDto connection)
    {
        var building = await _context.Buildings
        .Include(building => building.Auctions)
        .FirstOrDefaultAsync(building => building.RegistrationNumber == registrationNumber);   
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.AuctionId == connection.AuctionId);
        if (auction != null && building.Auctions.FirstOrDefault(conn => conn.AuctionId == connection.AuctionId) == null)
        {
            _logger.LogInformation("Added auction with id {connection.AuctionId} to the list of auctions in which the building with " +
                "registration number {registrationNumber} was put up for sale", connection.AuctionId, registrationNumber);
            var connectionToAdd = new BuildingAuctionConnection(registrationNumber, connection.AuctionId);
            building.Auctions.Add(connectionToAdd);        
            await _context.SaveChangesAsync();       
            return Ok(_mapper.Map<BuildingAuctionConnectionForBuildingDto>(connectionToAdd));
        }
        else
        {
		    return BadRequest();
	    }
    }

    /// <summary>
    /// Removes a auction from the list of auctions in which the building was put up for sale
    /// </summary>
    /// <param name="registrationNumber">Registration number of building</param>
    /// <param name="connection">Auction to be remove</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}/Auctions")]
    public async Task<IActionResult> DeleteAuction(int registrationNumber, [FromBody] BuildingAuctionConnectionForBuildingDto connection)
    {
        var building = await _context.Buildings
        .Include(building => building.Auctions)
        .FirstOrDefaultAsync(building => building.RegistrationNumber == registrationNumber);
        if (building == null)
        {
            _logger.LogInformation("Not found building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        var auction = await _context.Auctions.FirstOrDefaultAsync(a => a.AuctionId == connection.AuctionId);
        _logger.LogInformation("Removed auction with id {connection.AuctionId} from the list of auctions in which the building with " +
                    "registration number {registrationNumber} was put up for sale", connection.AuctionId, registrationNumber);
        var connectionToDelete = building.Auctions.FirstOrDefault(conn => conn.AuctionId == connection.AuctionId);

        if (connectionToDelete != null)
        {
            _context.Buildings.Local.First(b => b.RegistrationNumber == registrationNumber).Auctions.Remove(connectionToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }
        else
            return BadRequest();
    }
}