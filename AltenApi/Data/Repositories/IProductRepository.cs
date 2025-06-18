using Api.Data.Models;

namespace Api.Data.Repositories;

public interface IProductRepository
{
    Task<Product> AddAsync(Product product);
}
