using Ambev.DeveloperEvaluation.Domain.Validation;
using Bogus;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the DescriptionValidator class.
/// Tests cover various description validation scenarios including format, length, and empty checks.
/// </summary>
public class DescriptionValidatorTests
{
    private readonly DescriptionValidator _validator;
    
    public DescriptionValidatorTests()
    {
        _validator = new DescriptionValidator();
    }
    
    /// <summary>
    /// Tests that validation passes for various valid description formats.
    /// </summary>
    [Fact(DisplayName = "Valid description formats should pass validation")]
    public void Given_ValidDescriptionFormat_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var description = new Faker().Random.String2(1, 50); // Generates random string

        // Act
        var result = _validator.TestValidate(description);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    /// <summary>
    /// Tests that validation fails when the description is empty.
    /// </summary>
    [Fact(DisplayName = "Empty description should fail validation")]
    public void Given_EmptyDescription_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var description = string.Empty;

        // Act
        var result = _validator.TestValidate(description);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Description is required.");
    }
    
    /// <summary>
    /// Tests that validation fails when description exceeds maximum length.
    /// </summary>
    [Fact(DisplayName = "Description exceeding maximum length should fail validation")]
    public void Given_DescriptionExceeding100Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var description = $"{"a".PadLeft(101, 'a')}"; // Creates description > 100 chars

        // Act
        var result = _validator.TestValidate(description);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Description must not exceed 100 characters.");
    }
}