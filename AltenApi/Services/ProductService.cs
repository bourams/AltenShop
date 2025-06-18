using Api.Data.Models;
using Api.Data.Repositories;
using Api.Dtos;
using AutoMapper;

namespace Api.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }

        var product = _mapper.Map<Product>(dto);

        var repoResponse = await _repo.AddAsync(product);

        return _mapper.Map<ProductDto>(repoResponse);
    }
}
