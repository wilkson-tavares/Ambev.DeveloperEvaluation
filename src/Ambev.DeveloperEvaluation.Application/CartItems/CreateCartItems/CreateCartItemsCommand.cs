using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;

public class CreateCartItemsCommand : IRequest<CreateCartItemsResult>
{
    public Guid CartId { get; set; }
    public List<CreateCartItemsDto> CartItems { get; set; } = new List<CreateCartItemsDto>();

    public CreateCartItemsCommand()
    {
    }

    public CreateCartItemsCommand(Guid cartId, List<CreateCartItemsDto> cartItems)
    {
        CartId = cartId;
        CartItems = cartItems;
    }
}