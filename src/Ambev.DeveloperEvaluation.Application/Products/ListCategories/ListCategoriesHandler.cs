using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
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
        var validator = new ListCategoriesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var categories = await _productRepository.GetCategoriesAsync(request.Page, request.Size, request.Order, cancellationToken);
        var totalItems = await _productRepository.CountCategoriesAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((double)totalItems / request.Size);
        
        return new ListCategoriesResult
        {
            Categories = categories.ToList(),
            TotalItems = totalItems,
            TotalPages = totalPages
        };
    }
}