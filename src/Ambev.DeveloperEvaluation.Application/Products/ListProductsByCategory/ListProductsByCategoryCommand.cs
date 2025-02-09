using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

public class ListProductsByCategoryCommand : PaginatedCommand, IRequest<ListProductsByCategoryResult>
{
    /// <summary>
    /// The identifier category of products to retrieve
    /// </summary>
    public string Category { get; set; }
}