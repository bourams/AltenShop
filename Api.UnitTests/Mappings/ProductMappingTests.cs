using Api.Data.Models;
using Api.Dtos;
using Api.Enums;
using Api.Profiles;
using AutoMapper;

namespace Api.UnitTests.Mappings;

public class ProductMappingTests
{
    private readonly IMapper _mapper;

    public ProductMappingTests()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductProfile>();
        });

        config.AssertConfigurationIsValid();

        _mapper = config.CreateMapper();
    }

    [Fact]
    public void CreateProductDto_To_Product_ShouldMapAllProperties()
    {
        // Arrange
        var dto = new CreateProductDto
        {
            Code = "P001",
            Name = "Test Product",
            Description = "Sample description",
            Image = "",
            Category = "category",
            Price = 10.5m,
            Quantity = 5,
            InternalReference = "REF123",
            ShellId = 1,
            InventoryStatus = InventoryStatus.LOWSTOCK,
        };

        // Act
        var product = _mapper.Map<Product>(dto);

        // Assert
        Assert.Equal(dto.Code, product.Code);
        Assert.Equal(dto.Name, product.Name);
        Assert.Equal(dto.Description, product.Description);
        Assert.Equal(dto.Image, product.Image);
        Assert.Equal(dto.Category, product.Category);
        Assert.Equal(dto.Price, product.Price);
        Assert.Equal(dto.Quantity, product.Quantity);
        Assert.Equal(dto.InternalReference, product.InternalReference);
        Assert.Equal(dto.ShellId, product.ShellId);
        Assert.Equal(dto.InventoryStatus, product.InventoryStatus);
        Assert.Equal(0, product.Rating);
    }

    [Fact]
    public void Product_To_ProductDto_ShouldMapAllProperties()
    {
        // Arrange
        var product = new Product
        {
            Id = 1,
            Code = "P001",
            Name = "Test Product",
            Description = "Sample description",
            Image = "",
            Category = "category",
            Price = 10.5m,
            Quantity = 5,
            InternalReference = "REF123",
            ShellId = 1,
            InventoryStatus = InventoryStatus.LOWSTOCK,
            Rating = 0,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Act
        var dto = _mapper.Map<ProductDto>(product);

        // Assert
        Assert.Equal(product.Id, dto.Id);
        Assert.Equal(product.Code, dto.Code);
        Assert.Equal(product.Name, dto.Name);
        Assert.Equal(product.Description, dto.Description);
        Assert.Equal(product.Image, dto.Image);
        Assert.Equal(product.Category, dto.Category);
        Assert.Equal(product.Price, dto.Price);
        Assert.Equal(product.Quantity, dto.Quantity);
        Assert.Equal(product.InternalReference, dto.InternalReference);
        Assert.Equal(product.ShellId, dto.ShellId);
        Assert.Equal(product.InventoryStatus, dto.InventoryStatus);
        Assert.Equal(product.Rating, dto.Rating);
        Assert.Equal(product.CreatedAt, dto.CreatedAt);
        Assert.Equal(product.UpdatedAt, dto.UpdatedAt);
    }
}

