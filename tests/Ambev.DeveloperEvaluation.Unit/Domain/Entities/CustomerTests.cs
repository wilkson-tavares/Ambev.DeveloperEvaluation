using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Customer entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class CustomerTests
{
    /// <summary>
    /// Tests that validation passes when all customer properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid customer data")]
    public void Given_ValidCustomerData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var customer = CustomerTestData.GenerateValidCustomer();

        // Act
        var result = customer.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when customer properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid customer data")]
    public void Given_InvalidCustomerData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var customer = new Customer
        {
            Name = CustomerTestData.GenerateLongName() // Invalid: exceeds the maximum length limit
        };

        // Act
        var result = customer.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
