using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategories;

/// <summary>
/// Handler for listing product categories
/// </summary>
public class ListCategoriesHandler : IRequestHandler<ListCategoriesCommand, ListCategoriesResult>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ListCategoriesHandler"/> class.
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    public ListCategoriesHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    /// <summary>
    /// Handles the request to list product categories
    /// </summary>
    /// <param name="request">The request to list product categories</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A <see cref="ListCategoriesResult"/> containing the list of categories</returns>
    public async Task<ListCategoriesResult> Handle(ListCategoriesCommand request, CancellationToken cancellationToken)
    {
        var categories = await _productRepository.GetCategoriesAsync(cancellationToken);
        return new ListCategoriesResult
        {
            Categories = categories.ToList()
        };
    }
}