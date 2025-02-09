using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartProductValidator : AbstractValidator<CreateCartProductDto>
{
    public CreateCartProductValidator()
    {
        RuleFor(product => product.ProductId).NotEmpty().WithMessage("ProductId cannot be empty.");
        RuleFor(product => product.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}