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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="makerNames"></param>
    /// <param name="priceLower"></param>
    /// <param name="priceUpper"></param>
    /// <param name="powerTrain"></param>
    /// <param name="driveSystem"></param>
    /// <param name="bodyType"></param>
    /// <param name="lengthLower"></param>
    /// <param name="lengthUpper"></param>
    /// <param name="widthLower"></param>
    /// <param name="widthUpper"></param>
    /// <param name="heightLower"></param>
    /// <param name="heightUpper"></param>
    /// <param name="weightUpper"></param>
    /// <param name="doorNumLower"></param>
    /// <param name="ridingCapLower"></param>
    /// <param name="ridingCapUpper"></param>
    /// <param name="fcrWltcLower"></param>
    /// <param name="fcrJc08Lower"></param>
    /// <param name="mpcWltcLower"></param>
    /// <param name="ecrWltcLower"></param>
    /// <param name="ecrJc08Lower"></param>
    /// <param name="mpcJc08Lower"></param>
    /// <param name="fuelType"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Car>))]
    public async Task<ActionResult<List<Car>>> GetCars(
        [FromQuery]
        List<string> makerNames = default!,
        int? priceLower = null,
        int? priceUpper = null,
        string? powerTrain = null,
        string? driveSystem = null,
        string? bodyType = null,
        int? lengthLower = null,
        int? lengthUpper = null,
        int? widthLower = null,
        int? widthUpper = null,
        int? heightLower = null,
        int? heightUpper = null,
        int? weightUpper = null,
        int? doorNumLower = null,
        int? ridingCapLower = null,
        int? ridingCapUpper = null,
        float? fcrWltcLower = null,
        float? fcrJc08Lower = null,
        float? mpcWltcLower = null,
        float? ecrWltcLower = null,
        float? ecrJc08Lower = null,
        float? mpcJc08Lower = null,
        string? fuelType = null
    )
    {
        var p = new CarParameters()
        {
            MakerNames = makerNames,
            PriceLower = priceLower,
            PriceUpper = priceUpper,
            PowerTrain = powerTrain,
            DriveSystem = driveSystem,
            BodyType = bodyType,
            LengthLower = lengthLower,
            LengthUpper = lengthUpper,
            WidthLower = widthLower,
            WidthUpper = widthUpper,
            HeightLower = heightLower,
            HeightUpper = heightUpper,
            WeightUpper = weightUpper,
            DoorNumLower = doorNumLower,
            RidingCapLower = ridingCapLower,
            RidingCapUpper = ridingCapUpper,
            FcrWltcLower = fcrWltcLower,
            FcrJc08Lower = fcrJc08Lower,
            MpcWltcLower = mpcWltcLower,
            EcrWltcLower = ecrWltcLower,
            EcrJc08Lower = ecrJc08Lower,
            MpcJc08Lower = mpcJc08Lower,
            FuelType = fuelType
        };
        var cars = await _repo.GetCars(p);
        return Ok(cars);
    }
}