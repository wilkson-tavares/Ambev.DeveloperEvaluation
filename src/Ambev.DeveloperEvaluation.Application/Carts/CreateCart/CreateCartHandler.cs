using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public CreateCartHandler(ICartRepository cartRepository, IMapper mapper, IMediator mediator)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _mediator = mediator;
    }
    
    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var existingCart = await _cartRepository.GetByUserIdAsync(command.UserId, cancellationToken);
        if (existingCart != null)
            throw new InvalidOperationException($"Cart with user id {command.UserId} already exists");
        
        var cart = _mapper.Map<Cart>(command);
        var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);
        
        var createCartItemCommand = new CreateCartItemsCommand(createdCart.Id, _mapper.Map<List<CreateCartItemsDto>>(createdCart.Items));
        await _mediator.Send(createCartItemCommand, cancellationToken);
        
        var result = _mapper.Map<CreateCartResult>(createdCart);
        return result;
    }
}