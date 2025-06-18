using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public record CreateProductDto
{
    [Required]
    public string Code { get; init; }

    [Required]
    public string Name { get; init; }

    [Required]
    public string Description { get; init; }

    public string Image { get; init; }

    [Required]
    public string Category { get; init; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; init; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; init; }

    [Required]
    public string InternalReference { get; init; }

    public int ShellId { get; init; }

    [Required]
    [RegularExpression("INSTOCK|LOWSTOCK|OUTOFSTOCK")]
    public string InventoryStatus { get; init; }
}
