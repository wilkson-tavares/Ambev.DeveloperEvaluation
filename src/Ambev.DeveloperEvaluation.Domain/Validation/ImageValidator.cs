using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ImageValidator : AbstractValidator<string>
{
    public ImageValidator()
    {
        RuleFor(image => image)
            .NotEmpty().WithMessage("Image URL is required.")
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Image URL must be a valid URL.");
    }
}