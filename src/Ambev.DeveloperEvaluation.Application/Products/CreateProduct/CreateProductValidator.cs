using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for product creation command.
/// </summary>
public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    
    public CreateProductValidator()
    {
        RuleFor(product => product.Title).SetValidator(new TtileValidator());
        RuleFor(product => product.Description).SetValidator(new DescriptionValidator());
        RuleFor(product => product.Price).SetValidator(new PriceValidator());
        RuleFor(product => product.Category).SetValidator(new CategoryValidator());
        RuleFor(product => product.Image).SetValidator(new ImageValidator());
        RuleFor(product => product.Rating).SetValidator(new RatingValidator());
    }
}