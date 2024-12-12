using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation for ActiveCustomerSpecification tests
/// to ensure consistency across test cases.
/// </summary>
public static class ActiveCustomerSpecificationTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Customer entities.
    /// The generated customers will have valid:
    /// - Name (using person names)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// Status is not set here as it's the main test parameter
    /// </summary>
    private static readonly Faker<Customer> customerFaker = new Faker<Customer>()
        .CustomInstantiator(f => new Customer
        {
            Name = f.Person.FullName
        });

    /// <summary>
    /// Generates a valid Customer entity with the specified status.
    /// </summary>
    /// <returns>A valid Customer entity with randomly generated data and specified status.</returns>
    public static Customer GenerateCustomer()
    {
        var customer = customerFaker.Generate();
        return customer;
    }
}

