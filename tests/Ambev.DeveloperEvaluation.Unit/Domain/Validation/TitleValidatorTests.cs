using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class TitleValidatorTests
{
    private readonly TtileValidator _validator;

    public TitleValidatorTests()
    {
        _validator = new TtileValidator();
    }

    [Fact(DisplayName = "Non-empty title must pass validation")]
    public void Given_NonEmptyTitle_When_Validated_Then_ShouldNotHaveError()
    {
        // Arrange
        var validTitle = "Título válido";

        // Act
        var result = _validator.TestValidate(validTitle);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact(DisplayName = "Empty title should fail validation")]
    public void Given_EmptyTitle_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var invalidTitle = "";

        // Act
        var result = _validator.TestValidate(invalidTitle);

        // Assert
        result.ShouldHaveValidationErrorFor(title => title)
            .WithErrorMessage("Title is required.");
    }

    [Fact(DisplayName = "Title with more than 100 characters should fail validation")]
    public void Given_TitleExceedingMaxLength_When_Validated_Then_ShouldHaveError()
    {
        // Arrange
        var invalidTitle = new string('a', 101);

        // Act
        var result = _validator.TestValidate(invalidTitle);

        // Assert
        result.ShouldHaveValidationErrorFor(title => title)
            .WithErrorMessage("Title must not exceed 100 characters.");
    }
}