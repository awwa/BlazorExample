using System.Text.Json;
using HogeBlazor.Client.Features;
using HogeBlazor.Shared.Models;
using HogeBlazor.Shared.RequestFeatures;
using Microsoft.AspNetCore.WebUtilities;

namespace HogeBlazor.Client.HttpRepository;

public class ProductHttpRepository : IProductHttpRepository
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public ProductHttpRepository(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<PagingResponse<Product>> GetProducts()
    {
        var queryStringParam = new Dictionary<string, string>
        {
            // ["pageNumber"] = productParameters.PageNumber.ToString(),
            // ["searchTerm"] = productParameters.SearchTerm == null ? "" : productParameters.SearchTerm,
            // ["orderBy"] = productParameters.orderBy
        };
        var response = await _client.GetAsync("/api/v1/products"/*QueryHelpers.AddQueryString("products", queryStringParam)*/);
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException(content);
        }
        var pagingResponse = new PagingResponse<Product>
        {
            Items = JsonSerializer.Deserialize<List<Product>>(content, _options),
            MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
        };

        return pagingResponse;
    }
}