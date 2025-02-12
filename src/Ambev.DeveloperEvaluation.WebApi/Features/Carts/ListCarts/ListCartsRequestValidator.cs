using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts;

public class ListCartsRequestValidator : AbstractValidator<ListCartsRequest>
{
    public ListCartsRequestValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.Size).GreaterThan(0);
    }
}