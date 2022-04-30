
using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Repositories;

public class ProductHttpRepository : IProductHttpRepository
{
    private readonly HttpClient _client;
    //private readonly JsonSerializerOptions _options;

    public ProductHttpRepository(HttpClient client)
    {
        _client = client;
        // _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<Product>> GetProducts()
    {
        var p = new ProductsClient("", _client);
        return (List<Product>)await p.GetAsync();
        // var resp = await p.GetAsync();
        // ProductList = (List<Product>)resp;

    }
    // public async Task<PagingResponse<Product>> GetProducts()
    // {
    //     var queryStringParam = new Dictionary<string, string>
    //     {
    //         // ["pageNumber"] = productParameters.PageNumber.ToString(),
    //         // ["searchTerm"] = productParameters.SearchTerm == null ? "" : productParameters.SearchTerm,
    //         // ["orderBy"] = productParameters.orderBy
    //     };
    //     var response = await _client.GetAsync("/api/v1/products"/*QueryHelpers.AddQueryString("products", queryStringParam)*/);
    //     var content = await response.Content.ReadAsStringAsync();
    //     if (!response.IsSuccessStatusCode)
    //     {
    //         throw new ApplicationException(content);
    //     }
    //     var pagingResponse = new PagingResponse<Product>
    //     {
    //         Items = JsonSerializer.Deserialize<List<Product>>(content, _options),
    //         MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
    //     };

    //     return pagingResponse;
    // }
}