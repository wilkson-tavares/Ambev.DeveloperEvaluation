using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategories;

public class ListCategoriesValidator : AbstractValidator<ListCategoriesCommand>
{
    public ListCategoriesValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.Size).GreaterThan(0);
    }
}