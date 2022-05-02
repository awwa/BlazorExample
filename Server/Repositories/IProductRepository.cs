// using BlazorProducts.Server.Paging;
using HogeBlazor.Shared.Models;

namespace HogeBlazor.Server.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    // Task<PagedList<Product>> GetProducts();
    // Task CreateProduct(Product product);
    // Task<Product> GetProduct(Guid id);
    // Task UpdateProduct(Product product, Product dbProduct);
    // Task DeleteProduct(Product product);
}
