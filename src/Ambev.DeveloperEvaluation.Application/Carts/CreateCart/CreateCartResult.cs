namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreateDate { get; set; }
    public List<CreateCartProductDto> Products { get; set; }
}