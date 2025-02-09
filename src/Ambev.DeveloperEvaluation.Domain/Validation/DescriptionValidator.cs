using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class DescriptionValidator : AbstractValidator<string>
{
    public DescriptionValidator()
    {
        RuleFor(description => description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 100 characters.");
    }
}