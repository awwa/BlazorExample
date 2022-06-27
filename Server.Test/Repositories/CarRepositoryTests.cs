using Xunit;
using HogeBlazor.Server.Db;
using Microsoft.EntityFrameworkCore;
using System;
using HogeBlazor.Server.Repositories;
using Npgsql;
using static HogeBlazor.Server.Repositories.CarRepository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using HogeBlazor.Shared.Models.Db;

namespace HogeBlazor.Server.Test.Repositories;

public class CarRepositoryTest
{
    public CarRepository Repository;
    public CarRepositoryTest()
    {
        // テスト用設定ファイルの読み込み
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        string npgsqlConnString = config.GetConnectionString("PostgresDatabase");
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString: npgsqlConnString);
        optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();   // 詳細ログの有効化
        var Db = new AppDbContext(optionsBuilder.Options);
        Repository = new CarRepository(config, Db);
    }

    [Fact]
    public async void GetCarReturnsValidInstance()
    {
        var car = await Repository.GetCar(1);
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
        var car = await Repository.GetCar(-999);
        Assert.Null(car);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched1()
    {
        var p = new CarParameters() { MakerNames = new List<string> { "マツダ", "ヒュンダイ" } };
        var cars = await Repository.GetCars(p);
        Assert.Single(cars);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched2()
    {
        var p = new CarParameters()
        {
            BodyType = BodyType.HATCHBACK,
        };
        var cars = await Repository.GetCars(p);
        Assert.Equal(2, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched3()
    {
        var p = new CarParameters()
        {
            MakerNames = new List<string> { "マツダ" },
            BodyType = BodyType.SUV,
        };
        var cars = await Repository.GetCars(p);
        Assert.Single(cars);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched31()
    {
        var p = new CarParameters()
        {
            MakerNames = new List<string> { "マツダ", "トヨタ" },
        };
        var cars = await Repository.GetCars(p);
        Assert.Equal(2, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched4()
    {
        var p = new CarParameters()
        {
            WidthLower = 1800,
        };
        var cars = await Repository.GetCars(p);
        Assert.Equal(3, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched5()
    {
        var p = new CarParameters()
        {
            WidthUpper = 1800,
        };
        var cars = await Repository.GetCars(p);
        Assert.Equal(3, cars.Count);
    }

    [Fact]
    public async void GetCarsReturnsValidListIfMatched6()
    {
        var p = new CarParameters()
        {
            MakerNames = new List<string> { "マツダ" },
            PriceLower = 3000000,
            PriceUpper = 3200000,
            PowerTrain = PowerTrain.ICE,
            DriveSystem = DriveSystem.AWD,
            BodyType = BodyType.SUV,
            LengthLower = 4545,
            LengthUpper = 4545,
            WidthLower = 1840,
            WidthUpper = 1840,
            HeightLower = 1690,
            HeightUpper = 1690,
            WeightUpper = 1620,
            DoorNumLower = 4,
            RidingCapLower = 5,
            RidingCapUpper = 5,
            FcrWltcLower = 13.0f,
            FcrJc08Lower = 14.2f,
            //MpcWltcLower
            //EcrWltcLower
            //EcrJc08Lower
            //MpcJc08Lower
            FuelType = FuelType.REGULAR,
        };
        var cars = await Repository.GetCars(p);
        Assert.Single(cars);
    }


    [Fact]
    public async void GetCarsReturnsEmptyListIfNotMatched()
    {
        var p = new CarParameters() { MakerNames = new List<string> { "ほげ" } };
        var cars = await Repository.GetCars(p);
        Assert.Empty(cars);
    }

    [Fact]
    public async void GetCarsReturnsEmptyListWithEmptyValue()
    {
        var p = new CarParameters()
        {
            MakerNames = new List<string> { "マツダ" },
            MpcWltcLower = 14.2f,
        };
        var cars = await Repository.GetCars(p);
        Assert.Empty(cars);
    }

}