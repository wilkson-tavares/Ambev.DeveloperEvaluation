using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory;

public class ListProductsByCategoryRequest : PaginatedRequest
{
    /// <summary>
    /// The identifier category of products to retrieve
    /// </summary>
    public string Category { get; set; }
}