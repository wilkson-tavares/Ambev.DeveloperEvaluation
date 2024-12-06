using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface ISale
    {
        int SaleNumber { get; }
        DateTime Date { get; }
        ICustomer Customer { get; }
        decimal TotalAmount { get; }
        IBranch Branch { get; }
        List<IProduct> Products { get; }
        bool Cancelled { get; }
    }
}
