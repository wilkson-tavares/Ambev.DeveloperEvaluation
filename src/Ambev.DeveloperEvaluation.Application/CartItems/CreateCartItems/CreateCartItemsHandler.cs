using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

public class CreateCartItemsHandler : IRequestHandler<CreateCartItemsCommand, CreateCartItemsResult>
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;
    
    public CreateCartItemsHandler(ICartItemRepository cartItemRepository, IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }
    
    public async Task<CreateCartItemsResult> Handle(CreateCartItemsCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartItemsValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var createdCartItems = new List<CartItem>();
        foreach (var itemDto in command.CartItems)
        {
            var cartItem = _mapper.Map<CartItem>(itemDto);
            cartItem.CartId = command.CartId;
            var createdCartItem = await _cartItemRepository.CreateAsync(cartItem, cancellationToken);
            createdCartItems.Add(createdCartItem);
        }

        var result = new CreateCartItemsResult()
        {
            CartItems = _mapper.Map<List<CreateCartItemsDto>>(createdCartItems)
        };
        
        return result;
    }
}