using Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems;
using Ambev.DeveloperEvaluation.Application.CartItems.ListCartItemsByCartId;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResponse>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMediator _mediator;
    
    public DeleteCartHandler(ICartRepository cartRepository, IMediator mediator)
    {
        _cartRepository = cartRepository;
        _mediator = mediator;
    }   

    public async Task<DeleteCartResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var listCartItemsByCartIdCommand = new ListCartItemsByCartIdCommand(request.Id);
        var cartItems = await _mediator.Send(listCartItemsByCartIdCommand, cancellationToken);
        
        if (cartItems.CartItems.Any())
            throw new InvalidOperationException($"Cart with ID {request.Id} cannot be deleted because it has items");
        
        var success = await _cartRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Cart with ID {request.Id} not found");
        
        return new DeleteCartResponse { Message = $"Cart with ID {request.Id} deleted successfully" };
    }
}