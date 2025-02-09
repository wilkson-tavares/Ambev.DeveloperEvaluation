namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;

public class UpdateCartResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreateDate { get; set; }
    public List<UpdateCartProductDto> Products { get; set; }
}