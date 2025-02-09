using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

public class CreateCartItemsDtoValidator : AbstractValidator<CreateCartItemsDto>
{
    public CreateCartItemsDtoValidator()
    {
        RuleFor(cartItem => cartItem.ProductId).NotEmpty().WithMessage("ProductId cannot be empty.");
        RuleFor(cartItem => cartItem.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}