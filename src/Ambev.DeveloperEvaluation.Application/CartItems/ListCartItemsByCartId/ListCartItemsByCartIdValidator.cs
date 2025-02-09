using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.ListCartItemsByCartId;

public class ListCartItemsByCartIdValidator : AbstractValidator<ListCartItemsByCartIdCommand>
{
    public ListCartItemsByCartIdValidator()
    {
        RuleFor(x => x.CartId)
            .NotEmpty()
            .WithMessage("Cart ID is required");
        
        
    }
}