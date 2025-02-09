using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Repository implementation for Cart entity operations
/// </summary>
public class CartRepository : ICartRepository
{
    private readonly DbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartRepository"/> class.
    /// </summary>
    /// <param name="context">The database context</param>
    public CartRepository(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new cart in the repository
    /// </summary>
    /// <param name="cart">The cart to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created cart</returns>
    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _context.Set<Cart>().AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    /// Retrieves a cart by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the cart</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The cart if found, null otherwise</returns>
    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Cart>()
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }
    
    public async Task<Cart?> GetByUserIdAsync(Guid UserId, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Cart>()
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.UserId == UserId && !s.IsCancelled, cancellationToken);
    }

    /// <summary>
    /// Retrieves all carts from the repository
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>A collection of all carts</returns>
    public async Task<IEnumerable<Cart>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default)
    {
        var query = _context.Set<Cart>().AsQueryable();

        if (!string.IsNullOrEmpty(order))
            query = query.OrderBy(order);

        return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
    }
    
    public async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Cart>().CountAsync(cancellationToken);
    }

    /// <summary>
    /// Updates an existing cart in the repository
    /// </summary>
    /// <param name="cart">The cart to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The updated cart</returns>
    public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        _context.Set<Cart>().Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    /// Deletes a cart from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the cart to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the cart was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Set<Cart>().FindAsync(new object[] { id }, cancellationToken);
        if (cart == null)
            return false;

        _context.Set<Cart>().Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}