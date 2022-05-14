using Xunit;
using HogeBlazor.Server.Db;
using Microsoft.EntityFrameworkCore;
using System;
using HogeBlazor.Server.Repositories;
using Npgsql;
using static HogeBlazor.Server.Repositories.CarRepository;

namespace HogeBlazor.Server.Test.Repositories;

public class CarRepositoryTest : IDisposable
{
    private AppDbContext _context;
    private NpgsqlConnection _conn;
    private readonly DbContextOptions<AppDbContext> _contextOptions;
    private CarRepository _repo;
    public CarRepositoryTest()
    {
        _conn = new NpgsqlConnection(connectionString: "Host=localhost;Username=postgres;Password=password;Database=hoge_blazor");
        _conn.Open();
        _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
        .UseNpgsql(_conn, sql => sql.UseNodaTime()).Options;
        _context = CreateContext();

        // DB構築
        if (_context.Database.EnsureCreated())
        {
        }

        _repo = new CarRepository(_context);
    }

    AppDbContext CreateContext() => new AppDbContext(_contextOptions);
    public void Dispose() => _conn.Dispose();

    [Fact]
    public async void GetCarReturnsValidInstance()
    {
        var car = await _repo.GetCar(1);
        if (car == null)
        {
            throw new Exception();
        }
        Assert.NotNull(car);
        Assert.Equal("マツダ", car.MakerName);
    }

    [Fact]
    public async void GetCarReturnsNullIfNotExists()
    {
        var car = await _repo.GetCar(-999);
        Assert.Null(car);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched1()
    {
        var p = new CarParameters() { MakerName = "マツダ" };
        var cars = await _repo.GetCars(p);
        Assert.Equal(1, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched2()
    {
        var p = new CarParameters()
        {
            BodyType = Shared.Models.BodyType.HATCHBACK,
        };
        var cars = await _repo.GetCars(p);
        Assert.Equal(2, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched3()
    {
        var p = new CarParameters()
        {
            MakerName = "マツダ",
            BodyType = Shared.Models.BodyType.SUV,
        };
        var cars = await _repo.GetCars(p);
        Assert.Equal(1, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched4()
    {
        var p = new CarParameters()
        {
            WidthLower = 1800,
        };
        var cars = await _repo.GetCars(p);
        Assert.Equal(3, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched5()
    {
        var p = new CarParameters()
        {
            WidthUpper = 1800,
        };
        var cars = await _repo.GetCars(p);
        Assert.Equal(3, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched6()
    {
        var p = new CarParameters()
        {
            MakerName = "マツダ",
            PriceLower = 3000000,
            PriceUpper = 3200000,
            PowerTrain = Shared.Models.PowerTrain.ICE,
            DriveSystem = Shared.Models.DriveSystem.AWD,
            BodyType = Shared.Models.BodyType.SUV,
            LengthLower = 4545,
            LengthUpper = 4545,
            WidthLower = 1840,
            WidthUpper = 1840,
            HeightLower = 1690,
            HeightUpper = 1690,
            WeightUpper = 1620,
            DoorNumLower = 4,
            RidingCap = 5,
            FcrWltcLower = 13.0f,
            FcrJc08Lower = 14.2f,
            //MpcWltcLower
            //EcrWltcLower
            //EcrJc08Lower
            //MpcJc08Lower
            FuelType = Shared.Models.FuelType.REGULAR,
        };
        var cars = await _repo.GetCars(p);
        Assert.Equal(1, cars.Count);
    }


    [Fact]
    public async void GetCarsReturnsEmptyListIfNotMatched()
    {
        var p = new CarParameters() { MakerName = "ほげ" };
        var cars = await _repo.GetCars(p);
        Assert.Equal(0, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsEmptyListWithEmptyValue()
    {
        var p = new CarParameters()
        {
            MakerName = "マツダ",
            MpcWltcLower = 14.2f,
        };
        var cars = await _repo.GetCars(p);
        Assert.Equal(0, cars.Count);
    }

}