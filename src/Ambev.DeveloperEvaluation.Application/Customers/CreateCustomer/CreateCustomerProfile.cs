using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Customers.CreateCustomer;

/// <summary>
/// Profile for mapping CreateCustomerCommand to Customer and CreateCustomerResult
/// </summary>
public class CreateCustomerProfile : Profile
{
    public CreateCustomerProfile()
    {
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<Customer, CreateCustomerResult>();
    }
}
