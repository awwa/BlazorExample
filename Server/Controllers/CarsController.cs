using HogeBlazor.Server.Helpers;
using HogeBlazor.Server.Repositories;
using HogeBlazor.Shared.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using static HogeBlazor.Server.Repositories.DynamoCarRepository;

namespace HogeBlazor.Server.Controllers;

[Route($"{Const.API_BASE_PATH_V1}[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly IDynamoCarRepository _repo;

    public CarsController(IDynamoCarRepository repo)
    {
        _repo = repo;
    }

    /// <summary>
    /// クルマ情報取得
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns>クルマ情報</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CarDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarDto>> GetCarAsync(string id)
    {
        var car = await _repo.GetAsync(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    /// <summary>
    /// クルマ情報検索
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Dictionary<string, CarDto>))]
    public async Task<ActionResult<Dictionary<string, CarDto>>> QueryCarsAsync([FromQuery] CarQuery query)
    {
        Console.WriteLine("QueryCarsAsync()");
        query.MakerNames.ForEach(x => Console.WriteLine($"makerName: {x}"));
        return Ok(await _repo.QueryAsync(query));
    }

    /// <summary>
    /// 一意な属性値一覧を取得
    /// </summary>
    /// <param name="dataType">属性値名（MakerNameなど）</param>
    /// <returns></returns>
    [HttpGet]
    [Route("attributes")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HashSet<string>))]
    public async Task<ActionResult<HashSet<string>>> GetAttributeValuesAsync([FromQuery] string dataType)
    {
        return Ok(await _repo.GetAttributeValuesAsync(dataType));
    }
}