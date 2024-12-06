using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface IProduct
    {
        int ProductId { get; }
        string Name { get; }
        int Quantity { get; }
        decimal UnitPrice { get; }
        decimal Discount { get; }
        decimal TotalAmount { get; }
    }
}
