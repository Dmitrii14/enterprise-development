using System.ComponentModel.DataAnnotations;

namespace NonResidentialFund.Domain;
/// <summary>
/// Organization - a class that describes characteristics of a organization that organized the auction 
/// </summary>
public class Organization
{
    /// <summary>
    /// OrganizationId - the id of the organization
    /// </summary>
    [Key]
    public int OrganizationId { get; set; }

    /// <summary>
    /// OrganizationName - organization's name
    /// </summary>
    public string OrganizationName { get; set; } = string.Empty;

    /// <summary>
    /// Default constructor for the Organization class.
    /// </summary>
    public Organization() { }

    /// <summary>
    /// Constructor for the Organization class, allowing initialization of organization ID and name.
    /// </summary>
    public Organization(int organizationId, string organizationName)
    {
        OrganizationId = organizationId;
        OrganizationName = organizationName;
    }
}