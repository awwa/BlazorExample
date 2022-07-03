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
    /// クルマ情報取得
    /// </summary>
    /// <param name="id">ID</param>
    /// <returns>クルマ情報</returns>
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
    /// クルマ情報検索
    /// </summary>
    /// <param name="makerNames">メーカー名配列</param>
    /// <param name="priceLower">小売価格下限(税込み/円)</param>
    /// <param name="priceUpper">小売価格上限(税込み/円)</param>
    /// <param name="powerTrain">パワートレイン:ICE(エンジン車)|StrHV(ストロングハイブリッド)|HldHV(マイルドハイブリッド)|SerHV(シリーズハイブリッド)|PHEV(プラグインハイブリッド)|BEV(バッテリーEV)|RexEV(レンジエクステンダーEV)|FCEV(燃料電池車)</param>
    /// <param name="driveSystem">駆動方式:FF|FR|RR|MR|AWD</param>
    /// <param name="bodyType">ボディタイプ:SEDAN(セダン)|HATCHBACK(ハッチバック)|CROSS_COUNTRY(クロスカントリー)|MINI_VAN(ミニバン)|ONEBOX_WAGON(ワンボックスワゴン)|K(軽自動車)|COUPE(クーペ)|STATION_WAGON(ステーションワゴン)|SUV(SUV)|ONEBOX_VAN(ワンボックスバン)|K_OPEN(軽オープン)|K_ONEBOX_WAGON(軽ワンボックスワゴン)|OPEN(オープン)|VAN(バン)|K_VAN(軽バン)|K_ONEBOX_VAN(軽ワンボックスバン)|PICKUP_TRUCK(ピックアップトラック)</param>
    /// <param name="lengthLower">全長下限(mm)</param>
    /// <param name="lengthUpper">全長上限(mm)</param>
    /// <param name="widthLower">全幅下限(mm)</param>
    /// <param name="widthUpper">全幅上限(mm)</param>
    /// <param name="heightLower">全高下限(mm)</param>
    /// <param name="heightUpper">全高上限(mm)</param>
    /// <param name="weightUpper">車両重量上限(kg)</param>
    /// <param name="doorNumLower">ドア数下限</param>
    /// <param name="ridingCapLower">乗車定員下限(人)</param>
    /// <param name="ridingCapUpper">乗車定員上限(人)</param>
    /// <param name="fcrWltcLower">燃料消費率WLTCモード下限(km/L)</param>
    /// <param name="fcrJc08Lower">燃料消費率JC08モード下限(km/L)</param>
    /// <param name="mpcWltcLower">一充電走行距離WLTCモード下限(km)</param>
    /// <param name="ecrWltcLower">交流電力消費率WLTCモード下限(Wh/km)</param>
    /// <param name="ecrJc08Lower">交流電力消費率JC08モード下限(Wh/km)</param>
    /// <param name="mpcJc08Lower">一充電走行距離JC08モード下限(km)</param>
    /// <param name="fuelType">使用燃料種類:DIESEL(軽油)|REGULAR(無鉛レギュラーガソリン)|PREMIUM(無鉛プレミアムガソリン)|LPG(LPG)|BIO(バイオ燃料)|HYDROGEN(水素)</param>
    /// <returns>条件に該当したクルマ情報配列</returns>
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