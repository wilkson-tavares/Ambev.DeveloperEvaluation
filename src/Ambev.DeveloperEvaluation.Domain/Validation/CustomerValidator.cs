using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.CustomerId)
                .GreaterThan(0)
                .WithMessage("Customer ID must be greater than 0.");

            RuleFor(customer => customer.Name)
                .NotEmpty()
                .WithMessage("Customer name must not be empty.");
        }
    }
}
