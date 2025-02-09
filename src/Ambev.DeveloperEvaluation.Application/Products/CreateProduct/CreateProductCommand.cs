using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Command for creating a new product.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a product,
/// including title, price, description, category, image, and rating.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request
/// that returns a <see cref="CreateProductResult"/>.
/// </remarks>
public class CreateProductCommand : IRequest<CreateProductResult>
{
    /// <summary>
    /// Gets or sets the title of the product to be created.
    /// </summary>
    public string Title { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the price of the product to be created.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product to be created.
    /// </summary>
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the category of the product to be created.
    /// </summary>
    public string Category { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the image URL of the product to be created.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the rating of the product to be created.
    /// </summary>
    public Rating Rating { get; set; } = new Rating(0,0);
    
    public ValidationResultDetail Validate()
    {
        var validator = new CreateProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}