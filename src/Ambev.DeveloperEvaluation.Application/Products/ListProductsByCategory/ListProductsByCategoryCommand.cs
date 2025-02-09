using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

public class ListProductsByCategoryCommand : IRequest<ListProductsByCategoryResult>
{
    /// <summary>
    /// The identifier category of products to retrieve
    /// </summary>
    public string Category { get; set; }
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string Order { get; set; }
}