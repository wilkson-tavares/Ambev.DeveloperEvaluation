using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
    /// Repository implementation for CartItem entity operations
    /// </summary>
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CartItemRepository"/> class.
        /// </summary>
        /// <param name="context">The database context</param>
        public CartItemRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new cart item in the repository
        /// </summary>
        /// <param name="cartItem">The cart item to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created cart item</returns>
        public async Task<CartItem> CreateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
        {
            await _context.Set<CartItem>().AddAsync(cartItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return cartItem;
        }

        /// <summary>
        /// Retrieves a cart item by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the cart item</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The cart item if found, null otherwise</returns>
        public async Task<CartItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<CartItem>().FindAsync(new object[] { id }, cancellationToken);
        }

        /// <summary>
        /// Retrieves all cart items from the repository
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A collection of all cart items</returns>
        public async Task<IEnumerable<CartItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<CartItem>().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Updates an existing cart item in the repository
        /// </summary>
        /// <param name="cartItem">The cart item to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated cart item</returns>
        public async Task<CartItem> UpdateAsync(CartItem cartItem, CancellationToken cancellationToken = default)
        {
            _context.Set<CartItem>().Update(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
            return cartItem;
        }

        /// <summary>
        /// Deletes a cart item from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the cart item to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the cart item was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var cartItem = await _context.Set<CartItem>().FindAsync(new object[] { id }, cancellationToken);
            if (cartItem == null)
                return false;

            _context.Set<CartItem>().Remove(cartItem);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }