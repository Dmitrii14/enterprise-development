namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for representing a buyer's address.
/// </summary>
public class BuyerAddressDto
{
    /// <summary>
    /// BuyerId - the id of the buyer
    /// </summary>
    public int BuyerId { get; set; }

    /// <summary>
    /// Address - buyer's residence address 
    /// </summary>
    public string Address { get; set; } = string.Empty;
}