using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class RatingValidatorTests
{
    private readonly RatingValidator _validator;
    
    public RatingValidatorTests()
    {
        _validator = new RatingValidator();
    }
    
    [Fact(DisplayName = "Rating between 1 and 5 must pass validation")]
    public void Given_RatingBetweenOneAndFive_When_Validated_Then_ShouldNotHaveError()
    {
        // Arrange
        var validRating = new Rating(4.5m, 10);

        // Act
        var result = _validator.TestValidate(validRating);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Rating less than 1 should fail validation")]
    public void Given_RatingLessThanOne_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var invalidRating = new Rating(0.5m, 10);

        // Act
        var result = _validator.TestValidate(invalidRating);

        // Assert
        result.ShouldHaveValidationErrorFor(rating => rating.Rate)
            .WithErrorMessage("Rating value must be between 1 and 5.");
    }

    [Fact(DisplayName = "Rating greater than 5 should fail validation")]
    public void Given_RatingGreaterThanFive_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var invalidRating = new Rating(5.5m, 10);

        // Act
        var result = _validator.TestValidate(invalidRating);

        // Assert
        result.ShouldHaveValidationErrorFor(rating => rating.Rate)
            .WithErrorMessage("Rating value must be between 1 and 5.");
    }
}