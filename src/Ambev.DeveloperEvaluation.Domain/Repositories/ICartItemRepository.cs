using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for CartItem entity operations
/// </summary>
public interface ICartItemRepository
{
    /// <summary>
    /// Creates a new cart item in the repository
    /// </summary>
    /// <param name="cartItem">The cart item to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart item</returns>
    Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a cart item by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the cart item</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The cart item if found, null otherwise</returns>
    Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all cart items from the repository
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of all cart items</returns>
    Task<IEnumerable<CartItem>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing cart item in the repository
    /// </summary>
    /// <param name="cartItem">The cart item to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated cart item</returns>
    Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a cart item from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the cart item to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the cart item was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}