using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory;

public class ListProductsByCategoryResult : PaginatedResult
{
    public List<ListProductsByCategoryProductDto> Data { get; set; }
}