using Api.Enums;

namespace Api.Dtos;

public record ProductDto
{
    public int Id { get; init; }
    public string Code { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string Image { get; init; }
    public string Category { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public string InternalReference { get; init; }
    public int ShellId { get; init; }
    public InventoryStatus InventoryStatus { get; init; }
    public int Rating { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
