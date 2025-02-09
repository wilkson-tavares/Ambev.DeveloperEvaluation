using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItems;

public class UpdateCartItemsDtoValidator : AbstractValidator<UpdateCartItemsDto>
{
    public UpdateCartItemsDtoValidator()
    {
        RuleFor(cartItem => cartItem.ProductId).NotEmpty().WithMessage("ProductId cannot be empty.");
        RuleFor(cartItem => cartItem.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}