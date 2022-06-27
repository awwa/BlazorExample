using HogeBlazor.Server.Helpers;
using HogeBlazor.Server.Repositories;
using HogeBlazor.Shared.Models.Db;
using Microsoft.AspNetCore.Mvc;
using static HogeBlazor.Server.Repositories.CarRepository;

namespace HogeBlazor.Server.Controllers;

[Route($"{Const.API_BASE_PATH_V1}[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ICarRepository _repo;

    public CarsController(ICarRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Car))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Car>> Get(int id)
    {
        var car = await _repo.GetCar(id);
        if (car == null) return NotFound();
        return Ok(car);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Car>))]
    public async Task<ActionResult<List<Car>>> GetCars(
        [FromQuery]
        string? MakerName = null,
        int? PriceLower = null,
        int? PriceUpper = null,
        string? PowerTrain = null,
        string? DriveSystem = null,
        string? BodyType = null,
        int? LengthLower = null,
        int? LengthUpper = null,
        int? WidthLower = null,
        int? WidthUpper = null,
        int? HeightLower = null,
        int? HeightUpper = null,
        int? WeightUpper = null,
        int? DoorNumLower = null,
        int? RidingCap = null,
        float? FcrWltcLower = null,
        float? FcrJc08Lower = null,
        float? MpcWltcLower = null,
        float? EcrWltcLower = null,
        float? EcrJc08Lower = null,
        float? MpcJc08Lower = null,
        string? FuelType = null
    )
    {
        var p = new CarParameters();
        var cars = await _repo.GetCars(p);
        return Ok(cars);
    }
}