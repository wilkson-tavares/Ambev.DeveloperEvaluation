namespace Ambev.DeveloperEvaluation.Application.Products.ListCategories;

/// <summary>
/// Response model for ListCategories operation
/// </summary>
public class ListCategoriesResult
{
    /// <summary>
    /// List of product categories
    /// </summary>
    public List<string> Categories { get; set; }
}