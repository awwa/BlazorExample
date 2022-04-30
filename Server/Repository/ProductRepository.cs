using HogeBlazor.Server.Db;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Server.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
}
