using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.DeleteCustomer;

/// <summary>
/// Validator for DeleteCustomerCommand
/// </summary>
public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteCustomerCommand
    /// </summary>
    public DeleteCustomerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Customer ID is required");
    }
}
