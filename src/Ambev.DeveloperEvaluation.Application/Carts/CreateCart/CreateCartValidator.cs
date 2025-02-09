using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty().WithMessage("UserId cannot be empty.");
        RuleForEach(cart => cart.Products).SetValidator(new CreateCartProductValidator());
    }
}