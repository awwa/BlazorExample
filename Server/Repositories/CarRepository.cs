using System.Linq.Expressions;
using HogeBlazor.Server.Db;
using HogeBlazor.Server.Helpers;
using HogeBlazor.Shared.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Server.Repositories;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(IConfiguration configuration, AppDbContext context)
    {
        _context = context;
    }

    // public Task CreateCar(Car car)
    // {
    //     throw new NotImplementedException();
    // }

    // public Task DeleteCar(Car car)
    // {
    //     throw new NotImplementedException();
    // }

    // public Task UpdateCar(Car car)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<Car?> GetCar(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        return car;
    }

    public async Task<List<Car>> GetCars(CarParameters p)
    {
        // 検索条件の組み立て
        var exList = new List<Expression<Func<Car, bool>>>();
        if (p.MakerNames.Any())
        {
            exList.Add(QueryHelper.GetOrExpression<Car>("MakerName", p.MakerNames));
        }
        if (p.PriceLower != null) exList.Add(x => x.Price >= p.PriceLower);
        if (p.PriceUpper != null) exList.Add(x => x.Price <= p.PriceUpper);
        if (p.PowerTrain != null) exList.Add(x => x.PowerTrain == p.PowerTrain);
        if (p.DriveSystem != null) exList.Add(x => x.DriveSystem == p.DriveSystem);
        if (p.BodyType != null) exList.Add(x => x.Body.Type == p.BodyType);
        if (p.WidthLower != null) exList.Add(x => x.Body.Width >= p.WidthLower);
        if (p.WidthUpper != null) exList.Add(x => x.Body.Width <= p.WidthUpper);
        if (p.HeightLower != null) exList.Add(x => x.Body.Height >= p.HeightLower);
        if (p.HeightUpper != null) exList.Add(x => x.Body.Height <= p.HeightUpper);
        if (p.LengthLower != null) exList.Add(x => x.Body.Length >= p.LengthLower);
        if (p.LengthUpper != null) exList.Add(x => x.Body.Length <= p.LengthUpper);
        if (p.WeightUpper != null) exList.Add(x => x.Body.Weight <= p.WeightUpper);
        if (p.DoorNumLower != null) exList.Add(x => x.Body.DoorNum >= p.DoorNumLower);
        if (p.RidingCapUpper != null) exList.Add(x => x.Interior.RidingCap == p.RidingCapUpper);
        if (p.RidingCapLower != null) exList.Add(x => x.Interior.RidingCap >= p.RidingCapLower);
        if (p.FcrWltcLower != null) exList.Add(x => x.Performance.FcrWltc >= p.FcrWltcLower);
        if (p.FcrJc08Lower != null) exList.Add(x => x.Performance.FcrJc08 >= p.FcrJc08Lower);
        if (p.MpcWltcLower != null) exList.Add(x => x.Performance.MpcWltc >= p.MpcWltcLower);
        if (p.EcrWltcLower != null) exList.Add(x => x.Performance.EcrWltc >= p.EcrWltcLower);
        if (p.EcrJc08Lower != null) exList.Add(x => x.Performance.EcrJc08 >= p.EcrJc08Lower);
        if (p.MpcJc08Lower != null) exList.Add(x => x.Performance.MpcJc08 >= p.MpcJc08Lower);
        if (p.FuelType != null) exList.Add(x => x.Engine.FuelType == p.FuelType);

        var query = _context.Cars.AsQueryable();
        foreach (var ex in exList)
        {
            query = query.Where(ex);
        }
        var cars = await query.ToListAsync<Car>();
        return cars;
    }

    /// <summary>
    /// 検索条件
    /// </summary>
    public class CarParameters
    {
        /// <summary>
        /// メーカー名(完全一致)
        /// </summary>
        public List<string> MakerNames { get; set; } = new List<string>();
        /// <summary>
        /// 小売価格(税込/円)下限
        /// </summary>
        public int? PriceLower { get; set; }
        /// <summary>
        /// 小売価格(税込/円)上限
        /// </summary>
        public int? PriceUpper { get; set; }
        /// <summary>
        /// パワートレイン
        /// </summary>
        public string? PowerTrain { get; set; }
        /// <summary>
        /// 駆動方式
        /// </summary>
        public string? DriveSystem { get; set; }
        /// <summary>
        /// ボディタイプ
        /// </summary>
        public string? BodyType { get; set; }
        /// <summary>
        /// 全長(mm)下限
        /// </summary>
        public int? LengthLower { get; set; }
        /// <summary>
        /// 全長(mm)上限
        /// </summary>
        public int? LengthUpper { get; set; }
        /// <summary>
        /// 全幅(mm)下限
        /// </summary>
        public int? WidthLower { get; set; }
        /// <summary>
        /// 全幅(mm)上限
        /// </summary>
        public int? WidthUpper { get; set; }
        /// <summary>
        /// 全高(mm)下限
        /// </summary>
        public int? HeightLower { get; set; }
        /// <summary>
        /// 全高(mm)上限
        /// </summary>
        public int? HeightUpper { get; set; }
        /// <summary>
        /// 車両重量(kg)上限
        /// </summary>
        public int? WeightUpper { get; set; }
        /// <summary>
        /// ドア数下限
        /// </summary>
        public int? DoorNumLower { get; set; }
        /// <summary>
        /// 乗車定員(人)下限
        /// </summary>
        public int? RidingCapLower { get; set; }
        /// <summary>
        /// 乗車定員（人）上限
        /// </summary>
        /// <value></value>
        public int? RidingCapUpper { get; set; }
        /// <summary>
        /// 燃料消費率WLTCモード(km/L)下限
        /// </summary>
        public float? FcrWltcLower { get; set; }
        /// <summary>
        /// 燃料消費率JC08モード(km/L)下限
        /// </summary>
        public float? FcrJc08Lower { get; set; }
        /// <summary>
        /// 一充電走行距離WLTCモード(km)下限
        /// </summary>
        public float? MpcWltcLower { get; set; }
        /// <summary>
        /// 交流電力消費率WTLCモード(Wh/km)
        /// </summary>
        public float? EcrWltcLower { get; set; }
        /// <summary>
        /// 交流電力消費率JC08モード(Wh/km)
        /// </summary>
        public float? EcrJc08Lower { get; set; }
        /// <summary>
        /// 一充電走行距離JC08モード(km)下限
        /// </summary>
        public float? MpcJc08Lower { get; set; }
        /// <summary>
        /// 使用燃料種類
        /// </summary>
        public string? FuelType { get; set; }
    }
}
