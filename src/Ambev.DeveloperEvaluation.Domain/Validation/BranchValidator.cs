using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(branch => branch.BranchId)
                .GreaterThan(0)
                .WithMessage("Branch ID must be greater than 0.");

            RuleFor(branch => branch.Name)
                .NotEmpty()
                .WithMessage("Branch name must not be empty.");
        }
    }
}
