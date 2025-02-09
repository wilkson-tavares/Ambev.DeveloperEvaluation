using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

public class CreateCartItemsValidator : AbstractValidator<CreateCartItemsCommand>
{
    public CreateCartItemsValidator()
    {
        RuleFor(cartItem => cartItem.CartId).NotEmpty().WithMessage("CartId cannot be empty.");
        RuleForEach(cartItem => cartItem.CartItems).SetValidator(new CreateCartItemsDtoValidator());
    }
}