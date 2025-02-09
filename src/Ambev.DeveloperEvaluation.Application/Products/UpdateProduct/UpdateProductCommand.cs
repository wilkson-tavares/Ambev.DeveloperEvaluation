using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Command for update a product
/// </summary>
public class UpdateProductCommand : IRequest<UpdateProductResponse>
{
    /// <summary>
    /// The unique identifier of the product to update
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the title of the product to be update.
    /// </summary>
    public string Title { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the price of the product to be update.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product to be update.
    /// </summary>
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the category of the product to be update.
    /// </summary>
    public string Category { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the image URL of the product to be update.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the rating of the product to be update.
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0,0);
    
    public ValidationResultDetail Validate()
    {
        var validator = new UpdateProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}