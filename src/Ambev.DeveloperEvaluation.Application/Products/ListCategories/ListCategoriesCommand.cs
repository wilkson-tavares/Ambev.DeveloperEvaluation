using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategories;

/// <summary>
/// Query for listing product categories
/// </summary>
public class ListCategoriesCommand : IRequest<ListCategoriesResult>
{
}