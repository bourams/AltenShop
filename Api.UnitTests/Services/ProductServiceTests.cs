using Api.Data.Models;
using Api.Data.Repositories;
using Api.Dtos;
using Api.Enums;
using Api.Services;
using Api.UnitTests.Helpers;
using AutoMapper;
using NSubstitute;
using NSubstitute.ReceivedExtensions;

namespace Api.UnitTests.Services;

public class ProductServiceTests
{
    private readonly IProductRepository _repoMock;
    private readonly IMapper _mapperMock;
    private readonly ProductService _service;

    private readonly CreateProductDto _createDto;
    private readonly Product _productModel;
    private readonly ProductDto _productDto;

    public ProductServiceTests()
    {
        _repoMock = Substitute.For<IProductRepository>();
        _mapperMock = Substitute.For<IMapper>();
        _service = new ProductService(_repoMock, _mapperMock);

        // Setup common test data
        _createDto = ProductServiceTestHelper.GetCreateProductDto();
        _productModel = ProductServiceTestHelper.GetProductModel();
        _productDto = ProductServiceTestHelper.GetProductDto();

        // Common mapping setup
        _mapperMock.Map<Product>(_createDto).Returns(_productModel);
        _repoMock.AddAsync(_productModel).Returns(Task.FromResult(_productModel));
        _mapperMock.Map<ProductDto>(_productModel).Returns(_productDto);
    }

    [Fact]
    public async Task CreateProductAsync_WhenProductIsCreated_CallRepositoryAndMapOnce()
    {
        // Arrange
        // Act
        var result = await _service.CreateProductAsync(_createDto);

        // Assert
        _mapperMock.Received(1).Map<Product>(_createDto);
        await _repoMock.Received(1).AddAsync(_productModel);
        _mapperMock.Received(1).Map<ProductDto>(_productModel);
    }

    [Fact]
    public async Task CreateProductAsync_WhenProductIsCreated_PassUnalteredProductModelToRepository()
    {
        // Arrange
        // Act
        var result = await _service.CreateProductAsync(_createDto);

        // Assert
        Assert.Equal(0, _productModel.Id);
        Assert.Equal(5, _productModel.Quantity);
        Assert.Equal(0, _productModel.Rating);
        Assert.Equal(1, _productModel.ShellId);
        Assert.Equal(10.5m, _productModel.Price);
        Assert.Equal("", _productModel.Image);
        Assert.Equal("P001", _productModel.Code);
        Assert.Equal("Test Product", _productModel.Name);
        Assert.Equal("category", _productModel.Category);
        Assert.Equal("REF123", _productModel.InternalReference);
        Assert.Equal("Sample description", _productModel.Description);
        Assert.Equal(InventoryStatus.LOWSTOCK, _productModel.InventoryStatus);
    }

    [Fact]
    public async Task CreateProductAsync_WhenDtoIsNull_ThrowArgumentNullException()
    {
        // Arrange
        CreateProductDto nullDto = null;

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() =>
            _service.CreateProductAsync(nullDto));
    }
}
