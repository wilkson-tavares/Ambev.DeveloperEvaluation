using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems;

public class DeleteCartItemsHandler : IRequestHandler<DeleteCartItemsCommand, DeleteCartItemsResponse>
{
    private readonly ICartItemRepository _cartItemRepository;
    
    public DeleteCartItemsHandler(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }
    
    public async Task<DeleteCartItemsResponse> Handle(DeleteCartItemsCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _cartItemRepository.GetByCartIdAsync(request.CartId, cancellationToken);
        if (cartItem == null)
            throw new KeyNotFoundException($"Cart item with CartID {request.CartId} not found");
        
        var success = await _cartItemRepository.DeleteByCartIdAsync(request.CartId, cancellationToken);
        if (!success)
            throw new InvalidOperationException($"Cart item with CartID {request.CartId} cannot be deleted");
        
        return new DeleteCartItemsResponse { Message = $"Cart item with CartID {request.CartId} deleted successfully" };
    }
}