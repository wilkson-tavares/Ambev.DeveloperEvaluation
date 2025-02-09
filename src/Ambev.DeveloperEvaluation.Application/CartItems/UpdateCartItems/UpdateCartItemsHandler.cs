using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItems;

public class UpdateCartItemsHandler :IRequestHandler<UpdateCartItemsCommand, UpdateCartItemsResponse>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;
    
    public UpdateCartItemsHandler(ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }
    
    public async Task<UpdateCartItemsResponse> Handle(UpdateCartItemsCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartItemsValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var updatedCartItems = new List<CartItem>();
        foreach (var itemDto in command.CartItems)
        {
            var cartItem = _mapper.Map<CartItem>(itemDto);
            cartItem.CartId = command.CartId;
            var updatedCartItem = await _cartItemRepository.UpdateAsync(cartItem, cancellationToken);
            updatedCartItems.Add(updatedCartItem);
        }

        var result = new UpdateCartItemsResponse()
        {
            CartItems = _mapper.Map<List<UpdateCartItemsDto>>(updatedCartItems)
        };
        
        return result;
    }
}