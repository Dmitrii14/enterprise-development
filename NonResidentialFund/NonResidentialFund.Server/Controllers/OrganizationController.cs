using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server.Controllers;

/// <summary>
/// Controller for handling organization-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly NonResidentialFundContext _context;
    private readonly ILogger<OrganizationController> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the OrganizationController class using dependency injection to set up logger, repository, and mapper instances.
    /// </summary>
    public OrganizationController(NonResidentialFundContext context, ILogger<OrganizationController> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all organizations
    /// </summary>
    /// <returns>List of organizations</returns>
    [HttpGet]
    public async Task<IEnumerable<OrganizationGetDto>> Get()
    {
        _logger.LogInformation("Get all organizations");
        var organizations = await _context.Organizations.ToListAsync();
        return _mapper.Map<IEnumerable<OrganizationGetDto>>(organizations);
    }

    /// <summary>
    /// Returns the organization by the specified id
    /// </summary>
    /// <param name="id">id of the organization</param>
    /// <returns>Result of operation and organization object</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<OrganizationGetDto>> Get(int id)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _logger.LogInformation("Get organization with id: {id}", id);
            return Ok(_mapper.Map<OrganizationGetDto>(organization));
        }
    }

    /// <summary>
    /// Creates new organization
    /// </summary>
    /// <param name="organization">Organization to be created</param>
    [HttpPost]
    public async Task<ActionResult<OrganizationGetDto>> Post([FromBody] OrganizationPostDto organization)
    {
        _logger.LogInformation("Created new organization");
        var organizationToPut = _mapper.Map<Organization>(organization);
        await _context.Organizations.AddAsync(organizationToPut);
        await _context.SaveChangesAsync();
        return Ok(_mapper.Map<OrganizationGetDto>(organizationToPut));
    }

    /// <summary>
    /// Changes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be changed</param>
    /// <param name="organizationToPut">New organization data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<OrganizationGetDto>> Put(int id, [FromBody] OrganizationPostDto organizationToPut)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(organizationToPut, organization);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<OrganizationGetDto>(organization));
        }
    }

    /// <summary>
    /// Removes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var organization = await _context.Organizations.FirstOrDefaultAsync(organization => organization.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}