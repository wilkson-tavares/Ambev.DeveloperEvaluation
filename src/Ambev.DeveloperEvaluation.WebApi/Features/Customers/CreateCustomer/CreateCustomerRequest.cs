namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.CreateCustomer;

/// <summary>
/// Represents a request to create a new customer in the system.
/// </summary>
public class CreateCustomerRequest
{
    /// <summary>
    /// Gets or sets the name of the customer.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number in format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address. Must be a valid email format.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}