using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

/// <summary>
/// Controller for handling privatized-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PrivatizedController : ControllerBase
{
    private readonly NonResidentialFundContext _context;
    private readonly ILogger<PrivatizedController> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the PrivatizedController class using dependency injection to set up logger, repository, and mapper instances.
    /// </summary>
    public PrivatizedController(NonResidentialFundContext context, ILogger<PrivatizedController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all privatized buildings
    /// </summary>
    /// <returns>List of prtivatized buildings</returns>
    [HttpGet]
    public async Task<IEnumerable<PrivatizedGetDto>> Get()
    {
        _logger.LogInformation("Get all privatized buildings");
        var privatized = await _context.Privatized.ToListAsync();
        return _mapper.Map<IEnumerable<PrivatizedGetDto>>(privatized);
    }

    /// <summary>
    /// Returns the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">registration number of the privatized building</param>
    /// <returns>Result of operation and privatized building object</returns>
    [HttpGet("{registrationNumber}")]
    public async Task<ActionResult<PrivatizedGetDto>> Get(int registrationNumber)
    {
        var privatized = await _context.Privatized.FirstOrDefaultAsync(privatized => privatized.RegistrationNumber == registrationNumber);
        if (privatized == null)
        {
            _logger.LogInformation("Not found privatized building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get privatized building with registration number: {registrationNumber}", registrationNumber);
            return Ok(_mapper.Map<PrivatizedGetDto>(privatized));
        }
    }

    /// <summary>
    /// Creates new privatized building
    /// </summary>
    /// <param name="privatized">Privatized building to be created</param>
    [HttpPost]
    public async Task<ActionResult<PrivatizedGetDto>> Post([FromBody] PrivatizedPostDto privatized)
    {
        _logger.LogInformation("Created new privatized building");
        var privatizedToAdd = _mapper.Map<Privatized>(privatized);
        await _context.Privatized.AddAsync(privatizedToAdd);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<PrivatizedGetDto>(privatizedToAdd));
    }

    /// <summary>
    /// Changes the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the privatized building to be changed</param>
    /// <param name="privatizedToPut">New privatized building data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{registrationNumber}")]
    public async Task<ActionResult<PrivatizedGetDto>> Put(int registrationNumber, [FromBody] PrivatizedPostDto privatizedToPut)
    {
        var privatized = await _context.Privatized.FirstOrDefaultAsync(privatized => privatized.RegistrationNumber == registrationNumber);
        if (privatized == null)
        {
            _logger.LogInformation("Not found privatized building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            if (privatizedToPut.RegistrationNumber != privatized.RegistrationNumber)
            {
                return BadRequest();
            }
            _mapper.Map(privatizedToPut, privatized);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<PrivatizedGetDto>(privatized));
        }
    }

    /// <summary>
    /// Removes the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the privatized building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}")]
    public async Task<IActionResult> Delete(int registrationNumber)
    {
        var privatized = await _context.Privatized.FirstOrDefaultAsync(privatized => privatized.RegistrationNumber == registrationNumber);
        if (privatized == null)
        {
            _logger.LogInformation("Not found privatized building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _context.Privatized.Remove(privatized);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}