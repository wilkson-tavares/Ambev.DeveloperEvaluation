namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

/// <summary>
/// Represents a request to get a customer in the system.
/// </summary>
public class GetCustomerRequest
{
    /// <summary>
    /// The unique identifier of the customer to get
    /// </summary>
    public Guid Id { get; set; }
}