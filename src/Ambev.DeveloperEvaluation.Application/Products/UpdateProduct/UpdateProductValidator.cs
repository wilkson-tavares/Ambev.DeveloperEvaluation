using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Validator for UpdateProductCommand
/// </summary>
public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    /// <summary>
    /// Initializes validation rules for UpdateProductCommand
    /// </summary>
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Product ID is required");
        
        RuleFor(product => product.Title).SetValidator(new TtileValidator());
        RuleFor(product => product.Description).SetValidator(new DescriptionValidator());
        RuleFor(product => product.Price).SetValidator(new PriceValidator());
        RuleFor(product => product.Category).SetValidator(new CategoryValidator());
        RuleFor(product => product.Image).SetValidator(new ImageValidator());
        RuleFor(product => product.Rating).SetValidator(new RatingValidator());
    }
}