using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
    /// Repository implementation for SaleItem entity operations
    /// </summary>
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleItemRepository"/> class.
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleItemRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new sale item in the repository
        /// </summary>
        /// <param name="saleItem">The sale item to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created sale item</returns>
        public async Task<SaleItem> CreateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            await _context.Set<SaleItem>().AddAsync(saleItem, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return saleItem;
        }

        /// <summary>
        /// Retrieves a sale item by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale item</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The sale item if found, null otherwise</returns>
        public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<SaleItem>().FindAsync(new object[] { id }, cancellationToken);
        }

        /// <summary>
        /// Retrieves all sale items from the repository
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A collection of all sale items</returns>
        public async Task<IEnumerable<SaleItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<SaleItem>().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Updates an existing sale item in the repository
        /// </summary>
        /// <param name="saleItem">The sale item to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated sale item</returns>
        public async Task<SaleItem> UpdateAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            _context.Set<SaleItem>().Update(saleItem);
            await _context.SaveChangesAsync(cancellationToken);
            return saleItem;
        }

        /// <summary>
        /// Deletes a sale item from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the sale item to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the sale item was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var saleItem = await _context.Set<SaleItem>().FindAsync(new object[] { id }, cancellationToken);
            if (saleItem == null)
                return false;

            _context.Set<SaleItem>().Remove(saleItem);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }