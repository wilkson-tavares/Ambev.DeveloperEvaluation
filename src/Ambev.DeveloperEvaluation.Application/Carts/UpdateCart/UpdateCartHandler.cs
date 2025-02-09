using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;
using Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartHandler : IRequestHandler<UpdateCartCommand, UpdateCartResponse>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    
    public UpdateCartHandler(ICartRepository cartRepository, IMapper mapper, IMediator mediator)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _mediator = mediator;
    }
    
    public async Task<UpdateCartResponse> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var cart = _mapper.Map<Cart>(request);
        var updatedCart = await _cartRepository.UpdateAsync(cart, cancellationToken);
        var result = _mapper.Map<UpdateCartResponse>(updatedCart);
        
        var deleleteCartItemCommand = new DeleteCartItemsCommand(updatedCart.Id);
        await _mediator.Send(deleleteCartItemCommand, cancellationToken);
        
        var createCartItemCommand = new CreateCartItemsCommand(updatedCart.Id, _mapper.Map<List<CreateCartItemsDto>>(updatedCart.Items));
        await _mediator.Send(createCartItemCommand, cancellationToken);
        
        return result;
    }
}