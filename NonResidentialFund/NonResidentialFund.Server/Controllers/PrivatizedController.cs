﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;
using NonResidentialFund.Server.Repository;

namespace NonResidentialFund.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrivatizedController : ControllerBase
{
    private readonly ILogger<PrivatizedController> _logger;

    private readonly INonResidentialFundRepository _privatizedRepository;

    private readonly IMapper _mapper;

    public PrivatizedController(ILogger<PrivatizedController> logger, INonResidentialFundRepository privatizedRepository, IMapper mapper)
    {
        _logger = logger;
        _privatizedRepository = privatizedRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns all privatized buildings
    /// </summary>
    /// <returns>List of prtivatized buildings</returns>
    [HttpGet]
    public IEnumerable<PrivatizedGetDto> Get()
    {
        _logger.LogInformation("Get all privatized buildings");
        return _mapper.Map<IEnumerable<PrivatizedGetDto>>(_privatizedRepository.Privatized);
    }

    /// <summary>
    /// Returns the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">registration number of the privatized building</param>
    /// <returns>Result of operation and privatized building object</returns>
    [HttpGet("{registrationNumber}")]
    public ActionResult<PrivatizedGetDto> Get(int registrationNumber)
    {
        var privatized = _privatizedRepository.Privatized.FirstOrDefault(privatized => privatized.RegistrationNumber == registrationNumber);
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
    public void Post([FromBody] PrivatizedPostDto privatized)
    {
        _privatizedRepository.Privatized.Add(_mapper.Map<Privatized>(privatized));
    }

    /// <summary>
    /// Changes the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the privatized building to be changed</param>
    /// <param name="privatizedToPut">New privatized building data</param>
    /// <returns>Result of operation</returns>
    [HttpPut("{registrationNumber}")]
    public IActionResult Put(int registrationNumber, [FromBody] PrivatizedPostDto privatizedToPut)
    {
        var privatized = _privatizedRepository.Privatized.FirstOrDefault(privatized => privatized.RegistrationNumber == registrationNumber);
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
            return Ok();
        }
    }

    /// <summary>
    /// Removes the privatized building by the specified registration number
    /// </summary>
    /// <param name="registrationNumber">Registration number of the privatized building to be removed</param>
    /// <returns>Result of operation</returns>
    [HttpDelete("{registrationNumber}")]
    public IActionResult Delete(int registrationNumber)
    {
        var privatized = _privatizedRepository.Privatized.FirstOrDefault(privatized => privatized.RegistrationNumber == registrationNumber);
        if (privatized == null)
        {
            _logger.LogInformation("Not found privatized building with registration number: {registrationNumber}", registrationNumber);
            return NotFound();
        }
        else
        {
            _privatizedRepository.Privatized.Remove(privatized);
            return Ok();
        }
    }
}