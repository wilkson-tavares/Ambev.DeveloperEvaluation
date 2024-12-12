using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveCustomerSpecification : ISpecification<Customer>
{
    public bool IsSatisfiedBy(Customer user)
    {
        return user.Name != string.Empty;
    }
}
