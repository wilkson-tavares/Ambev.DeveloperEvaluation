using Ambev.DeveloperEvaluation.Domain.Validation;
using Bogus;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the ImageValidator class.
/// Tests cover various validator validation scenarios including format, length, and empty checks.
/// </summary>
public class ImageValidatorTests
{
    private readonly ImageValidator _validator;
    
    public ImageValidatorTests()
    {
        _validator = new ImageValidator();
    }
    
    /// <summary>
    /// Tests that validation fails when the image is empty.
    /// </summary>
    [Fact(DisplayName = "Empty image should fail validation")]
    public void Given_EmptyImage_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var image = string.Empty;

        // Act
        var result = _validator.TestValidate(image);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Image URL is required.");
    }
    
    /// <summary>
    /// Tests that validation fails when image url is invalid.
    /// </summary>
    [Fact(DisplayName = "Invalid URL image format should fail validation")]
    public void Given_InvalidUrlFormat_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var invalidUrl = "invalid_url_format";

        // Act
        var result = _validator.TestValidate(invalidUrl);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x)
            .WithErrorMessage("Image URL must be a valid URL.");
    }
    
    /// <summary>
    /// Tests that validation passes when the image URL is in a valid format.
    /// </summary>
    [Fact(DisplayName = "Valid URL image format should pass validation")]
    public void Given_ValidUrlFormat_When_Validated_Then_ShouldNotHaveError()
    {
        // Arrange
        var validUrl = new Faker().Internet.Url(); // Generates random URL

        // Act
        var result = _validator.TestValidate(validUrl);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}