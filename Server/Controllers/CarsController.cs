using HogeBlazor.Server.Helpers;
using HogeBlazor.Server.Repositories;
using HogeBlazor.Shared.Models;
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
        string? MakerName,
        int? PriceLower,
        int? PriceUpper,
        PowerTrain? PowerTrain,
        DriveSystem? DriveSystem,
        BodyType? BodyType,
        int? LengthLower,
        int? LengthUpper,
        int? WidthLower,
        int? WidthUpper,
        int? HeightLower,
        int? HeightUpper,
        int? WeightUpper,
        int? DoorNumLower,
        int? RidingCap,
        float? FcrWltcLower,
        float? FcrJc08Lower,
        float? MpcWltcLower,
        float? EcrWltcLower,
        float? EcrJc08Lower,
        float? MpcJc08Lower,
        FuelType? FuelType
    )
    {
        var p = new CarParameters();
        var cars = await _repo.GetCars(p);
        return Ok(cars);
    }
}