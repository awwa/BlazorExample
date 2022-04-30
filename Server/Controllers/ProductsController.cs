using HogeBlazor.Server.Helpers;
using HogeBlazor.Server.Repository;
using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HogeBlazor.Server.Controllers;

[Route($"{Const.API_BASE_PATH_V1}[controller]")]
[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;

    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
    public async Task<ActionResult<List<Product>>> Get()
    {
        var products = await _repo.GetProducts();
        // var products = await _repo.GetProducts();
        // Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));
        return Ok(products);
    }
}