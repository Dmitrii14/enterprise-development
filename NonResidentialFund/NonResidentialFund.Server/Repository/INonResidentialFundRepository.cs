using NonResidentialFund.Domain;

namespace NonResidentialFund.Server.Repository;

/// <summary>
/// Repository interface for managing non-residential fund data.
/// </summary>
public interface INonResidentialFundRepository
{
    /// <summary>
    /// Gets a list of all auctions related to the non-residential fund.
    /// </summary>
    public List<Auction> Auctions { get; }

    /// <summary>
    /// Gets a list of buildings associated with the non-residential fund.
    /// </summary>
    public List<Building> Buildings { get; }

    /// <summary>
    /// Gets a list of buyers participating in auctions within the fund.
    /// </summary>
    public List<Buyer> Buyers { get; }

    /// <summary>
    /// Gets a list of districts where properties are located within the fund.
    /// </summary>
    public List<District> Districts { get; }

    /// <summary>
    /// Gets a list of organizations involved with the non-residential fund.
    /// </summary>
    public List<Organization> Organizations { get; }

    /// <summary>
    /// Gets a list of privatized entities within the fund.
    /// </summary>
    public List<Privatized> Privatized { get; }
}