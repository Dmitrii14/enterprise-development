using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

/// <summary>
/// Controller for handling district-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DistrictController : ControllerBase
{
    private readonly NonResidentialFundContext _context;
    private readonly ILogger<DistrictController> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the DistrictController class using dependency injection to set up logger, repository, and mapper instances.
    /// </summary>
    public DistrictController(NonResidentialFundContext context, ILogger<DistrictController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all districts
    /// </summary>
    /// <returns>List of districts</returns>
    [HttpGet]
    public async Task<IEnumerable<DistrictGetDto>> Get()
    {
        _logger.LogInformation("Get all districts");
        var districts = await _context.Districts.ToListAsync();
        return _mapper.Map<IEnumerable<DistrictGetDto>>(districts);
    }

    /// <summary>
    /// Returns the district by the specified id
    /// </summary>
    /// <param name="id">id of the district</param>
    /// <returns>Result of operation and district object</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DistrictGetDto>> Get(int id)
    {
        var district = await _context.Districts.FirstOrDefaultAsync(district => district.DistrictId == id);
        if (district == null)
        {
            _logger.LogInformation("Not found district with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get district with id: {id}", id);
            return Ok(_mapper.Map<DistrictGetDto>(district));
        }
    }

    /// <summary>
    /// Creates new district
    /// </summary>
    /// <param name="district">District to be created</param>
    [HttpPost]
    public async Task<ActionResult<DistrictGetDto>> Post([FromBody] DistrictPostDto district)
    {
        _logger.LogInformation("Created new district");
        var districtToAdd = _mapper.Map<District>(district);
        await _context.Districts.AddAsync(districtToAdd);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<DistrictGetDto>(districtToAdd));
    }

    /// <summary>
    /// Changes the district by the specified id
    /// </summary>
    /// <param name="id">Id of the district to be changed</param>
    /// <param name="districtToPut">New district data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<DistrictGetDto>> Put(int id, [FromBody] DistrictPostDto districtToPut)
    {
        var district = await _context.Districts.FirstOrDefaultAsync(district => district.DistrictId == id);
        if (district == null)
        {
            _logger.LogInformation("Not found district with id: {id}", id);
            return NotFound();
        }
        else
        {
             _mapper.Map(districtToPut, district);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<DistrictGetDto>(district));
        }
    }

    /// <summary>
    /// Removes the district by the specified id
    /// </summary>
    /// <param name="id">Id of the district to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var district = await _context.Districts.FirstOrDefaultAsync(district => district.DistrictId == id);
        if (district == null)
        {
            _logger.LogInformation("Not found district with id: {id}", id);
            return NotFound();
        }
        else
        {
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}