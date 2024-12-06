using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface ICustomer
    {
        int CustomerId { get; }
        string Name { get; }
    }
}
