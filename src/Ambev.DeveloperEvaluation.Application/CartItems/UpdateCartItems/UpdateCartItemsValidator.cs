using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItems;

public class UpdateCartItemsValidator : AbstractValidator<UpdateCartItemsCommand>
{
    public UpdateCartItemsValidator()
    {
        RuleFor(cartItem => cartItem.CartId).NotEmpty().WithMessage("CartId cannot be empty.");
        RuleForEach(cartItem => cartItem.CartItems).SetValidator(new UpdateCartItemsDtoValidator());
    }
}