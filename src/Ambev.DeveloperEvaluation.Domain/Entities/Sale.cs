using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity, ISale
    {
        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; } = new Customer();
        ICustomer ISale.Customer => Customer;
        public decimal TotalAmount { get; set; }
        public Branch Branch { get; set; } = new Branch();
        IBranch ISale.Branch => Branch;
        public List<Product> Products { get; set; }
        List<IProduct> ISale.Products => Products.Cast<IProduct>().ToList();
        public bool Cancelled { get; set; }

        public Sale()
        {
            Products = new List<Product>();
            CreatedAt = DateTime.UtcNow;
        }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
