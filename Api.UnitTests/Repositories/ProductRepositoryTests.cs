using Api.Data;
using Api.Data.Models;
using Api.Data.Repositories;
using Api.UnitTests.Helpers;

namespace Api.UnitTests.Repositories;

public class ProductRepositoryTests
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _sut;
    private readonly DateTime _fixedDate;

    public ProductRepositoryTests()
    {
        _fixedDate = new DateTime(2024, 06, 17, 12, 0, 0, DateTimeKind.Utc);
        var dateProvider = DateTimeProviderHelper.GetProvider(_fixedDate);

        _context = DatabaseHelper.GetInMemoryDbContext();
        _sut = new ProductRepository(_context, dateProvider);
    }

    private Product GetProduct()
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
            InventoryStatus = Enums.InventoryStatus.INSTOCK,
            Rating = 4,
            Category = "category",
            Image = ""
        };
    }

    [Fact]
    public async Task AddAsync_InsertProductInDb_ReturnProductWithId()
    {
        // Arrange
        var product = GetProduct();

        // Act
        var result = await _sut.AddAsync(product);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Id > 0);
    }

    [Fact]
    public async Task AddAsync_InsertProductInDb_ProductsIncrementInDb()
    {
        // Arrange
        var BeforeTestProductsTotal = _context.Products.Count();
        var product = GetProduct();

        // Act
        var result = await _sut.AddAsync(product);

        // Assert
        Assert.Equal(BeforeTestProductsTotal + 1, _context.Products.Count());
    }

    [Fact]
    public async Task AddAsync_InsertProductInDb_AllProductAttributeInserted()
    {
        // Arrange
        var BeforeTestProductsTotal = _context.Products.Count();
        var product = GetProduct();

        // Act
        var result = await _sut.AddAsync(product);

        // Assert
        var dbProduct = await _context.Products.FindAsync(result.Id);
        Assert.NotNull(dbProduct);
        Assert.Equal(product.Code, dbProduct.Code);
        Assert.Equal(product.Name, dbProduct.Name);
        Assert.Equal(product.Description, dbProduct.Description);
        Assert.Equal(product.Image, dbProduct.Image);
        Assert.Equal(product.Category, dbProduct.Category);
        Assert.Equal(product.Price, dbProduct.Price);
        Assert.Equal(product.Quantity, dbProduct.Quantity);
        Assert.Equal(product.InternalReference, dbProduct.InternalReference);
        Assert.Equal(product.ShellId, dbProduct.ShellId);
        Assert.Equal(product.InventoryStatus, dbProduct.InventoryStatus);
        Assert.Equal(product.Rating, dbProduct.Rating);

        Assert.Equal(_fixedDate, dbProduct.CreatedAt);
        Assert.Equal(default, dbProduct.UpdatedAt);
    }

    [Fact]
    public async Task AddAsync_InsertProductInDb_CreatedAtDateCorrect()
    {
        // Arrange
        var product = GetProduct();

        // Act
        var result = await _sut.AddAsync(product);

        // Assert
        var dbProduct = await _context.Products.FindAsync(result.Id);
        Assert.NotNull(dbProduct);
        Assert.Equal(_fixedDate, dbProduct.CreatedAt);
        Assert.Equal(default, dbProduct.UpdatedAt);
    }

    //TODO: TEST REPO RESPONSE
    //TODO: CHECK ENUM CONVERSION

}