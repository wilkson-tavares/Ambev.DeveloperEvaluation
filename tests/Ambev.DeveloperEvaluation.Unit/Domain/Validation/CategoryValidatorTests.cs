using Ambev.DeveloperEvaluation.Domain.Validation;
using Bogus;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the CategoryValidator class.
/// Tests cover various category validation scenarios including format, length, and empty checks.
/// </summary>
public class CategoryValidatorTests
{
    private readonly CategoryValidator _validator;
    
    public CategoryValidatorTests()
    {
        _validator = new CategoryValidator();
    }
    
    /// <summary>
    /// Tests that validation passes for various valid category formats.
    /// </summary>
    [Fact(DisplayName = "Valid category formats should pass validation")]
    public void Given_ValidCategoryFormat_When_Validated_Then_ShouldNotHaveErrors()
    {
        // Arrange
        var category = new Faker().Random.String2(1, 50); // Generates random string

        // Act
        var result = _validator.TestValidate(category);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
    
    /// <summary>
    /// Tests that validation fails when the category is empty.
    /// </summary>
    [Fact(DisplayName = "Empty category should fail validation")]
    public void Given_EmptyCategory_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var category = string.Empty;

        // Act
        var result = _validator.TestValidate(category);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Category is required.");
    }
    
    /// <summary>
    /// Tests that validation fails when category exceeds maximum length.
    /// </summary>
    [Fact(DisplayName = "Category exceeding maximum length should fail validation")]
    public void Given_CategoryExceeding50Characters_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var category = $"{"a".PadLeft(51, 'a')}"; // Creates category > 50 chars

        // Act
        var result = _validator.TestValidate(category);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Category must not exceed 50 characters.");
    }
}