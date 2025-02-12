using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartCommand, Cart>();
        CreateMap<Cart, CreateCartResult>();
        CreateMap<CreateCartItemsDto, CartItem>();
        CreateMap<CartItem, CreateCartItemsDto>();
        CreateMap<CreateCartProductDto, CartItem>();
    }
}