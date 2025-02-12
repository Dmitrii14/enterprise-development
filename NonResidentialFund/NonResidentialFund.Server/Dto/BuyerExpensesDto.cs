namespace NonResidentialFund.Server.Dto;

/// <summary>
/// Data Transfer Object (DTO) for representing buyer expenses.
/// </summary>
public class BuyerExpensesDto
{
    /// <summary>
    /// BuyerId - the id of the buyer
    /// </summary>
    public int BuyerId { get; set; }

    /// <summary>
    /// Expenses cpent by the buyer
    /// </summary>
    public double Expenses { get; set; }
}