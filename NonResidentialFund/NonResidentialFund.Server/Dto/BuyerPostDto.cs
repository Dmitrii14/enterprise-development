﻿namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for creating or updating buyer data.
/// </summary>
public class BuyerPostDto
{
    /// <summary>
    /// LastName - buyer's last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// FirstName - buyer's first name
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// MiddleName - buyer's middle name
    /// </summary>
    public string MiddleName { get; set; } = string.Empty;
    /// <summary>
    /// PassportSeries - buyer's passport series
    /// </summary>
    public string PassportSeries { get; set; } = string.Empty;
    /// <summary>
    /// PassportNumber - buyer's passpoer number
    /// </summary>
    public string PassportNumber { get; set; } = string.Empty;
    /// <summary>
    /// Address - buyer's residence address 
    /// </summary>
    public string Address { get; set; } = string.Empty;
}