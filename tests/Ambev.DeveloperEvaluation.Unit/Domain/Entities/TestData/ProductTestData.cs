using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated products will have valid:
    /// - Name
    /// - Description
    /// - Price
    /// - Rating
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(p => p.Title, f => f.Commerce.ProductName())
        .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
        .RuleFor(p => p.Price, f => f.Random.Decimal(1, 1000))
        .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0])
        .RuleFor(p => p.Image, f => f.Image.PicsumUrl())
        .RuleFor(p => p.Rating, f => new Rating(f.Random.Decimal(1, 5), f.Random.Int(1, 100)));

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Generates a valid product name.
    /// The generated name will:
    /// - Be a realistic product name
    /// </summary>
    /// <returns>A valid product name.</returns>
    public static string GenerateValidProductName()
    {
        return new Faker().Commerce.ProductName();
    }

    /// <summary>
    /// Generates a valid product description.
    /// The generated description will:
    /// - Be a realistic product description
    /// </summary>
    /// <returns>A valid product description.</returns>
    public static string GenerateValidProductDescription()
    {
        return new Faker().Commerce.ProductDescription();
    }

    /// <summary>
    /// Generates a valid product price.
    /// The generated price will:
    /// - Be a decimal value between 1 and 1000
    /// </summary>
    /// <returns>A valid product price.</returns>
    public static decimal GenerateValidProductPrice()
    {
        return new Faker().Random.Decimal(1, 1000);
    }
    
    /// <summary>
    /// Generates a valid product category.
    /// The generated category will:
    /// - Be a realistic product category
    /// </summary>
    /// <returns>A valid product category.</returns>
    public static string GenerateValidProductCategory()
    {
        return new Faker().Commerce.Categories(1)[0];
    }
    
    /// <summary>
    /// Generates a valid product image url.
    /// The generated image url will:
    /// - Be a realistic product image url
    /// </summary>
    /// <returns>A valid product image url.</returns>
    public static string GenerateValidProductImage()
    {
        return new Faker().Image.PicsumUrl();
    }

    /// <summary>
    /// Generates a valid product rating.
    /// The generated rating will:
    /// - Have a rate between 1 and 5
    /// - Have a count between 1 and 100
    /// </summary>
    /// <returns>A valid product rating.</returns>
    public static Rating GenerateValidProductRating()
    {
        var faker = new Faker();
        return new Rating(faker.Random.Decimal(1, 5), faker.Random.Int(1, 100));
    }

    /// <summary>
    /// Generates an invalid product price for testing negative scenarios.
    /// The generated price will:
    /// - Be a negative decimal value
    /// </summary>
    /// <returns>An invalid product price.</returns>
    public static decimal GenerateInvalidProductPrice()
    {
        return new Faker().Random.Decimal(-1000, -1);
    }

    /// <summary>
    /// Generates an invalid product rating for testing negative scenarios.
    /// The generated rating will:
    /// - Have a rate outside the range of 1 to 5
    /// </summary>
    /// <returns>An invalid product rating.</returns>
    public static Rating GenerateInvalidProductRating()
    {
        var faker = new Faker();
        return new Rating(faker.Random.Decimal(6, 10), faker.Random.Int(1, 100));
    }
    
    public static string GenerateInvalidProductCategory()
    {
        return new Faker().Lorem.Word();
    }
    
    public static string GenerateInvalidProductImage()
    {
        return new Faker().Lorem.Word();
    }
}