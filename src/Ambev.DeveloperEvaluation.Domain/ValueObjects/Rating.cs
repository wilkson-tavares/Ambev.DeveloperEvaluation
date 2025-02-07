namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

/// <summary>
/// Represents the rating of a product.
/// </summary>
public class Rating
{
    /// <summary>
    /// Gets the rate of the product.
    /// </summary>
    public decimal Rate { get; }

    /// <summary>
    /// Gets the count of ratings for the product.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rating"/> class.
    /// </summary>
    /// <param name="rate">The rate of the product.</param>
    /// <param name="count">The count of ratings for the product.</param>
    public Rating(decimal rate, int count)
    {
        Rate = rate;
        Count = count;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (obj is Rating rating)
        {
            return Rate == rating.Rate && Count == rating.Count;
        }
        return false;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Rate, Count);
    }
}