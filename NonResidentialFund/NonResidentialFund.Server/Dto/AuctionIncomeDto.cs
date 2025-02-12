namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for representing auction income data.
/// </summary>
public class AuctionIncomeDto
{
    /// <summary>
    /// AuctionId - unique key of auction
    /// </summary>
    public int AuctionId { get; set; }

    /// <summary>
    /// The income that the auction received
    /// </summary>
    public double Income { get; set; }
}