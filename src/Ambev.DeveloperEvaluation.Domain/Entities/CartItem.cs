using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item in a cart transaction.
/// </summary>
public class CartItem : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    [NotMapped]
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product being sold.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the cart item.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the total price of the cart item after applying the discount.
    /// </summary>
    public decimal TotalPrice { get; set; }

    
    // Foreign key to Cart
    public Guid CartId { get; set; }
    public Cart Cart { get; set; }
    
    /// <summary>
    /// Calculates the total price of the cart item based on the quantity and unit price,
    /// and applies the appropriate discount based on the quantity.
    /// </summary>
    /// <exception cref="DomainException">
    /// Thrown when the quantity exceeds 20, as selling more than 20 identical items is not allowed.
    /// </exception>
    public void CalculateTotalPrice()
    {
        if (Quantity is >= 4 and < 10)
        {
            Discount = 0.10m;
        }
        else if (Quantity is >= 10 and <= 20)
        {
            Discount = 0.20m;
        }
        else if (Quantity > 20)
        {
            throw new DomainException("Cannot sell more than 20 identical items.");
        }
        else
        {
            Discount = 0.0m;
        }

        TotalPrice = Quantity * UnitPrice * (1 - Discount);
    }
}