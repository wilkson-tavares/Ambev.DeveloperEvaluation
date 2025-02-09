using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class TtileValidator : AbstractValidator<string>
{
    public TtileValidator()
    {
        RuleFor(title => title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
    }
}