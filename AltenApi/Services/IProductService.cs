using Api.Dtos;

namespace Api.Services
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto dto);
    }
}
