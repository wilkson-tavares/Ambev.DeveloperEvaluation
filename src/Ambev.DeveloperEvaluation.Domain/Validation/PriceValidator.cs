using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class PriceValidator : AbstractValidator<decimal>
{
    public PriceValidator()
    {
        RuleFor(price => price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}