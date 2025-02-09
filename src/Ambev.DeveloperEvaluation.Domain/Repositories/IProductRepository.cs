using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Product entity operations
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Creates a new product in the repository
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a product by its title
    /// </summary>
    /// <param name="title">The title of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product if found, null otherwise</returns>
    Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all products from the repository
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of all products</returns>
    Task<IEnumerable<Product>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default);
    
    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing product in the repository
    /// </summary>
    /// <param name="product">The product to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated product</returns>
    Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a product from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a distinct list of product categories from the repository.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of unique product categories</returns>
    Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of products by their category.
    /// </summary>
    /// <param name="category">The category of the products to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
    /// <returns>A collection of products that belong to the specified category.</returns>
    Task<IEnumerable<Product>> GetByCategoryAsync(string category, int page, int size, string order, CancellationToken cancellationToken = default);

    Task<int> CountByCategoryAsync(string category, CancellationToken cancellationToken = default);
}