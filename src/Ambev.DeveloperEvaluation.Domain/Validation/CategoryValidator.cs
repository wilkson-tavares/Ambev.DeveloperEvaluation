using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class CategoryValidator : AbstractValidator<string>
{
    public CategoryValidator()
    {
        RuleFor(category => category)
            .NotEmpty().WithMessage("Category is required.")
            .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");
    }
}