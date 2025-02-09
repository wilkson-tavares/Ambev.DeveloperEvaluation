namespace Ambev.DeveloperEvaluation.Application.Common;

public abstract class PaginatedCommand
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    public string Order { get; set; }
}