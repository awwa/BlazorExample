
using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Repositories;

public interface IProductHttpRepository
{
    Task<List<Product>> GetProducts();
    //Task<PagingResponse<Product>> GetProducts(/*ProductParameters productParameters*/);
    // Task CreateProduct(PlatformNotSupportedException product);
    // Task<string> UploadProductImage(MultipartFormDataContent content);
    // Task<Product> GetProduct(string id);
    // Task UpdateProduct(Product product);
    // Task DeleteProduct(Guid id);
}