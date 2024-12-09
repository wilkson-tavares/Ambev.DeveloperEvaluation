using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer;

/// <summary>
/// Profile for mapping GetCustomer feature requests to commands
/// </summary>
public class GetCustomerProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCustomer feature
    /// </summary>
    public GetCustomerProfile()
    {
        CreateMap<Guid, Application.Customers.GetCustomer.GetCustomerCommand>()
            .ConstructUsing(id => new Application.Customers.GetCustomer.GetCustomerCommand(id));
    }
}