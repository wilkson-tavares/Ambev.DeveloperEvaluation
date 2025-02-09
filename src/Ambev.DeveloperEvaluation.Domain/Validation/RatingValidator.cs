using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class RatingValidator : AbstractValidator<Rating>
{
    public RatingValidator()
    {
        RuleFor(rating => rating.Rate)
            .InclusiveBetween(1, 5).WithMessage("Rating value must be between 1 and 5.");
        
        RuleFor(rating => rating.Count)
            .GreaterThanOrEqualTo(0).WithMessage("Rating count must be greater than or equal to 0.");
    }
}