using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartValidator()
    {
        RuleFor(cart => cart.UserId).NotEmpty().WithMessage("UserId cannot be empty.");
        RuleForEach(cart => cart.Products).SetValidator(new UpdateCartProductValidator());
    }
}