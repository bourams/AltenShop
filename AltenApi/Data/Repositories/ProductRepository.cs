using Api.Common;
using Api.Data.Models;

namespace Api.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly IDateTimeProvider _dateTimeProvider;
    public ProductRepository(AppDbContext context, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<Product> AddAsync(Product product)
    {
        product.CreatedAt = _dateTimeProvider.UtcNow;
        //product.UpdatedAt = _dateTimeProvider.UtcNow;

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }
}
