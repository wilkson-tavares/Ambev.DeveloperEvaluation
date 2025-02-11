using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
    /// Repository implementation for Product entity operations
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The database context</param>
        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new product in the repository
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created product</returns>
        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Set<Product>().AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        /// <summary>
        /// Retrieves a product by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().FindAsync(new object[] { id }, cancellationToken);
        }
        
        /// <summary>
        /// Retrieves a product by title
        /// </summary>
        /// <param name="title">The title of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        public async Task<Product?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().FirstOrDefaultAsync(p => p.Title == title, cancellationToken);
        }

        /// <summary>
        /// Retrieves all products from the repository
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A collection of all products</returns>
        public async Task<IEnumerable<Product>> GetAllAsync(int page, int size, string order, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Product>().AsQueryable();

            if (!string.IsNullOrEmpty(order))
                query = query.OrderBy(order);

            return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
        }
        
        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().CountAsync(cancellationToken);
        }

        /// <summary>
        /// Updates an existing product in the repository
        /// </summary>
        /// <param name="product">The product to update</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The updated product</returns>'
        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        /// <summary>
        /// Deletes a product from the repository
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the product was deleted, false if not found</returns>
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = await _context.Set<Product>().FindAsync(new object[] { id }, cancellationToken);
            if (product == null)
                return false;

            _context.Set<Product>().Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        
        /// <summary>
        /// Retrieves a distinct list of product categories from the repository.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A collection of unique product categories</returns>
        public async Task<IEnumerable<string>> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().Select(p => p.Category).Distinct().ToListAsync();
        }

        /// <summary>
        /// Retrieves a list of products by their category.
        /// </summary>
        /// <param name="category">The category of the products to retrieve.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>A collection of products that belong to the specified category.</returns>
        public async Task<IEnumerable<Product>> GetByCategoryAsync(string category, int page, int size, string order,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Set<Product>().Where(p => p.Category == category);

            if (!string.IsNullOrEmpty(order))
                query = query.OrderBy(order);

            return await query.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
        }
        
        public async Task<int> CountByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Product>().CountAsync(p => p.Category == category, cancellationToken);
        }
    }