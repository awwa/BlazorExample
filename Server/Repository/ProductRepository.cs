using BlazorProducts.Server.Paging;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Server.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        _context = context;
    }

    public async Task<PagedList<Product>> GetProducts()
    {
        var products = await _context.Products
            // .Search(productParameters.SearchTerm)
            // .Sort(productParameters.OrderBy)
            .ToListAsync();

        return PagedList<Product>
            .ToPagedList(products, 0, 10);//productParameters.PageNumber, productParameters.PageSize);
    }
}
