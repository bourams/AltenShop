using Api.Dtos;
using Api.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Api.IntegrationTests;

public  class ProductsControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProductsControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    //TODO: 201
    //TODO: 400

    [Fact]
    public async Task CreateProduct_ShouldReturn500_WhenServiceThrowsException()
    {
        // Arrange
        var serviceMock = Substitute.For<IProductService>();
        serviceMock.CreateProductAsync(Arg.Any<CreateProductDto>())
            .Throws(new Exception("Simulated failure"));

        var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IProductService>(_ => serviceMock);
            });
        }).CreateClient();

        var dto = new CreateProductDto
        {
            Code = "P001",
            Name = "Test Product",
            Description = "Description",
            Image = "",
            Category = "Category",
            Price = 10.0m,
            Quantity = 1,
            InternalReference = "Ref123",
            ShellId = 1,
            InventoryStatus = Api.Enums.InventoryStatus.INSTOCK,
        };

        // Act
        var response = await client.PostAsJsonAsync("/api/products", dto); // TODO: Move url

        // Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);

        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("An unexpected error occurred", body);
    }
}
