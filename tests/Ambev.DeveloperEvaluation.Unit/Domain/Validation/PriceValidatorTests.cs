using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class PriceValidatorTests
{
    private readonly PriceValidator _validator;
    
    public PriceValidatorTests()
    {
        _validator = new PriceValidator();
    }
    
    [Fact(DisplayName = "Price greater than 0 must pass validation")]
    public void Given_PriceGreaterThanZero_When_Validated_Then_ShouldNotHaveError()
    {
        // Arrange
        decimal validPrice = 10m;

        // Act
        var result = _validator.TestValidate(validPrice);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Price equal to 0 should fail validation")]
    public void Given_PriceEqualToZero_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        decimal invalidPrice = 0m;

        // Act
        var result = _validator.TestValidate(invalidPrice);

        // Assert
        result.ShouldHaveValidationErrorFor(price => price)
            .WithErrorMessage("Price must be greater than 0.");
    }

    [Fact(DisplayName = "Price less than 0 should fail validation")]
    public void Given_PriceLessThanZero_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        decimal invalidPrice = -5m;

        // Act
        var result = _validator.TestValidate(invalidPrice);

        // Assert
        result.ShouldHaveValidationErrorFor(price => price)
            .WithErrorMessage("Price must be greater than 0.");
    }
}