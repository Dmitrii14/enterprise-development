using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;

/// <summary>
/// Controller for handling organization-related operations.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly ILogger<OrganizationController> _logger;

    private readonly INonResidentialFundRepository _organizationsRepository;

    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the OrganizationController class using dependency injection to set up logger, repository, and mapper instances.
    /// </summary>
    public OrganizationController(ILogger<OrganizationController> logger, INonResidentialFundRepository organizationsRepository, IMapper mapper)
    {
        _logger = logger;
        _organizationsRepository = organizationsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all organizations
    /// </summary>
    /// <returns>List of organizations</returns>
    [HttpGet]
    public IEnumerable<OrganizationGetDto> Get()
    {
        _logger.LogInformation("Get all organization");
        return _mapper.Map<IEnumerable<OrganizationGetDto>>(_organizationsRepository.Organizations);
    }

    /// <summary>
    /// Returns the organization by the specified id
    /// </summary>
    /// <param name="id">id of the organization</param>
    /// <returns>Result of operation and organization object</returns>
    [HttpGet("{id}")]
    public ActionResult<OrganizationGetDto> Get(int id)
    {
        var organization = _organizationsRepository.Organizations.FirstOrDefault(organiz => organiz.OrganizationId == id);
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
    public void Post([FromBody] OrganizationPostDto organization)
    {
        _organizationsRepository.Organizations.Add(_mapper.Map<Organization>(organization));
    }

    /// <summary>
    /// Changes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be changed</param>
    /// <param name="organizationToPut">New organization data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] OrganizationPostDto organizationToPut)
    {
        var organization = _organizationsRepository.Organizations.FirstOrDefault(organiz => organiz.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _mapper.Map(organizationToPut, organization);
            return Ok();
        }
    }

    /// <summary>
    /// Removes the organization by the specified id
    /// </summary>
    /// <param name="id">Id of the organization to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var organization = _organizationsRepository.Organizations.FirstOrDefault(organiz => organiz.OrganizationId == id);
        if (organization == null)
        {
            _logger.LogInformation("Not found organization with id: {id}", id);
            return NotFound();
        }
        else
        {
            _organizationsRepository.Organizations.Remove(organization);
            return Ok();
        }
    }
}