using System.ComponentModel.DataAnnotations;

namespace NonResidentialFund.Domain;
/// <summary>
/// District - a class that describes characteristics of a district in which the buildings are located
/// </summary>
public class District
{
    /// <summary>
    /// DistrictId - the id of the district
    /// </summary>
    [Key]
    public int DistrictId { get; set; }

    /// <summary>
    /// DistrictName - district's name
    /// </summary>
    public string DistrictName { get; set; } = string.Empty;

    /// <summary>
    /// Default constructor for the District class.
    /// </summary>
    public District() { }

    /// <summary>
    /// Constructor for the District class, allowing initialization of district ID and name.
    /// </summary>
    public District(int districtId, string districtName)
    {
        DistrictId = districtId;
        DistrictName = districtName;
    }
}
