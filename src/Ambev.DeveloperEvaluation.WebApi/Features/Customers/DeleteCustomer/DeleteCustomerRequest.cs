namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.DeleteCustomer;

/// <summary>
/// Represents a request to delete a customer in the system.
/// </summary>
public class DeleteCustomerRequest
{
    /// <summary>
    /// The unique identifier of the customer to delete
    /// </summary>
    public Guid Id { get; set; }
}