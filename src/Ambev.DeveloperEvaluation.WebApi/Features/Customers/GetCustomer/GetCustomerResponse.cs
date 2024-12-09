namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

/// <summary>
/// API response model for GetCustomer operation
/// </summary>
public class GetCustomerResponse
{
    /// <summary>
    /// The unique identifier of the customer
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The customer's full name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The customer's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The customer's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;
}