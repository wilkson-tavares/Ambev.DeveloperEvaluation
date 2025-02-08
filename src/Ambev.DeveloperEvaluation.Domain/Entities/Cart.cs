using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a cart transaction in the system.
/// </summary>
public class Cart : BaseEntity
{
    /// <summary>
    /// Gets or sets the cart number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date when the cart was made.
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the customer.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the name of the customer.
    /// </summary>
    [NotMapped]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the total amount of the cart.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the name of the branch.
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of items in the cart.
    /// </summary>
    public List<CartItem> Items { get; set; } = new List<CartItem>();

    /// <summary>
    /// Gets or sets a value indicating whether the cart is cancelled.
    /// </summary>
    public bool IsCancelled { get; set; }
    
    /// <summary>
    /// Adds an item to the cart.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(CartItem item)
    {
        item.CalculateTotalPrice();
        Items.Add(item);
        CalculateTotalAmount();
    }

    /// <summary>
    /// Cancels the cart.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
    }

    /// <summary>
    /// Calculates the total amount of the cart.
    /// </summary>
    private void CalculateTotalAmount()
    {
        TotalAmount = 0;
        foreach (var item in Items)
        {
            TotalAmount += item.TotalPrice;
        }
    }
}