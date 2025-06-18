using Api.Data.Models;
using Api.Dtos;

namespace Api.Tests.Helpers;

internal static class ProductServiceTestHelper
{
    public static CreateProductDto GetCreateProductDto()
    {
        return new CreateProductDto
        {
            Code = "P001",
            Name = "Test Product",
            Description = "Sample description",
            Price = 10.5m,
            Quantity = 5,
            InternalReference = "REF123",
            ShellId = 1,
            InventoryStatus = Enums.InventoryStatus.LOWSTOCK,
            Category = "category",
            Image = ""
        };
    }

    public static Product GetProductModel()
    {
        return new Product
        {
            Code = "P001",
            Name = "Test Product",
            Description = "Sample description",
            Price = 10.5m,
            Quantity = 5,
            InternalReference = "REF123",
            ShellId = 1,
            InventoryStatus = Enums.InventoryStatus.LOWSTOCK,
            Category = "category",
            Rating = 0,
            Image = ""
        };
    }

    public static ProductDto GetProductDto()
    {
        return new ProductDto
        {
            Code = "P001",
            Name = "Test Product",
            Description = "Sample description",
            Price = 10.5m,
            Quantity = 5,
            InternalReference = "REF123",
            ShellId = 1,
            InventoryStatus = Enums.InventoryStatus.LOWSTOCK,
            Category = "category",
            Rating = 0,
            Image = ""
        };
    }
}
