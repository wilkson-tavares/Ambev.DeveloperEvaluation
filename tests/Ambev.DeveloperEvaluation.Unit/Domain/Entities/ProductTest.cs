using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Product entity class.
/// Tests cover validation scenarios and business logic.
/// </summary>
public class ProductTest
{
    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid product data")]
    public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var product = ProductTestData.GenerateValidProduct();

        // Act
        var result = product.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product data")]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var product = new Product
        {
            Title = "", // Invalid: empty
            Description = "", // Invalid: empty
            Price = ProductTestData.GenerateInvalidProductPrice(), // Invalid: negative price
            Rating = ProductTestData.GenerateInvalidProductRating(), // Invalid: rating out of range
            Category = ProductTestData.GenerateInvalidProductCategory(), // Invalid: category not matching criteria
            Image = ProductTestData.GenerateInvalidProductImage() // Invalid: image not matching criteria
        };

        // Act
        var result = product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}