using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <remarks>
/// This response contains the unique identifier, title, price, and description of the newly created product,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created product.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created product in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the newly created product.
    /// </summary>
    /// <value>A string representing the title of the product.</value>
    public string Title { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the price of the newly created product.
    /// </summary>
    /// <value>A decimal representing the price of the product.</value>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the newly created product.
    /// </summary>
    /// <value>A string representing the description of the product.</value>
    public string Description { get; set; } = String.Empty;

    public string Category { get; set; }

    public string Image { get; set; }

    public Rating Rating { get; set; }
}