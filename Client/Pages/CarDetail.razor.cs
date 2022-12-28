using System.Globalization;
using System.Reflection;
using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Services;
using HogeBlazor.Shared.Models.Db;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class CarDetail// : IDisposable
{
    // [Inject]
    // public HttpInterceptorService Interceptor { get; set; } = default!;

    public Helpers.Car Car { get; set; } = default!;

    public List<KeyValuePair<string, string>> TestValues { get; set; } = new List<KeyValuePair<string, string>>
    {
        new KeyValuePair<string, string>("A", "a"),
        new KeyValuePair<string, string>("B", "b"),
        new KeyValuePair<string, string>("C", "c"),
    };

    public List<KeyValuePair<string, string>> Numbers { get; set; } = new List<KeyValuePair<string, string>>
    {
        new KeyValuePair<string, string>("全長", "4545"),
        new KeyValuePair<string, string>("全幅", "1840"),
        new KeyValuePair<string, string>("全高", "1690"),
        new KeyValuePair<string, string>("ホイールベース", "2700"),
        new KeyValuePair<string, string>("最低地上高", "210"),
    };

    [Parameter]
    public int Id { get; set; }

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        // Interceptor.RegisterEvent();
        // Car = await GetCar(this.Id);
        // TODO テスト用コード
        Car = new Helpers.Car
        {
            Id = 1,
            MakerName = "マツダ",
            ModelName = "CX-5",
            GradeName = "25S Proactive",
            ModelCode = "6BA-KF5P",
            Price = 3140500,
            Url = "https://www.mazda.co.jp/cars/cx-5/",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/85/2017_Mazda_CX-5_%28KF%29_Maxx_2WD_wagon_%282018-11-02%29_01.jpg",
            ModelChangeFull = "2016-12-15",
            ModelChangeLast = "2018-01-01",
            PowerTrain = PowerTrain.ICE,
            DriveSystem = DriveSystem.AWD,
            Steering = "ラック&ピニオン式",
            SuspensionFront = "マクファーソンストラット式",
            SuspensionRear = "マルチリンク式",
            BrakeFront = "ベンチレーテッドディスク",
            BrakeRear = "ディスク",
            FuelEfficiency = new string[]
            {
                "ミラーサイクルエンジン",
                "アイドリングストップ機構",
                "筒内直接噴射",
                "可変バルブタイミング",
                "気筒休止",
                "充電制御",
                "ロックアップ機構付トルクコンバーター",
                "電動パワーステアリング",
            },
            Body = new Helpers.Body
            {
                Type = BodyType.SUV,
                Length = 4545,
                Width = 1840,
                Height = 1690,
                WheelBase = 2700,
                TreadFront = 1595,
                TreadRear = 1595,
                MinRoadClearance = 210,
                Weight = 1620,
                DoorNum = 4,
            },
            // MotorX: Motor{},
            // MotorY: Motor{},
            // Battery: Battery{},
            Interior = new Helpers.Interior
            {
                Length = 1890,
                Width = 1540,
                Height = 1265,
                // LuggageCap
                RidingCap = 5,
            },
            Performance = new Helpers.Performance
            {
                MinTurningRadius = 5.5f,
                FcrWltc = 13.0f,
                FcrWltcL = 10.2f,
                FcrWltcM = 13.4f,
                FcrWltcH = 14.7f,
                // FcrWltcExh
                FcrJc08 = 14.2f,
                // MpcWltc
                // EcrWltc
                // EcrWltcL
                // EcrWltcM
                // EcrWltcH
                // EcrWltcExh
                // EcrJc08
                // MpcJc08
            },
            Engine = new Helpers.Engine
            {
                Code = "PY-RPS",
                Type = "水冷直列4気筒DOHC16バルブ",
                CylinderNum = 4,
                CylinderLayout = CylinderLayout.I,
                ValveSystem = ValveSystem.DOHC,
                Displacement = 2.488f,
                Bore = 89.0f,
                Stroke = 100.0f,
                CompressionRatio = 13.0f,
                MaxOutput = 138f,
                MaxOutputLowerRpm = 6000,
                MaxOutputUpperRpm = 6000,
                MaxTorque = 250f,
                MaxTorqueLowerRpm = 4000,
                MaxTorqueUpperRpm = 4000,
                FuelSystem = "DI",
                FuelType = FuelType.REGULAR,
                FuelTankCap = 58,
            },
            TireFront = new Helpers.Tire
            {
                SectionWidth = 225,
                AspectRatio = 55,
                WheelDiameter = 19,
            },
            TireRear = new Helpers.Tire
            {
                SectionWidth = 225,
                AspectRatio = 55,
                WheelDiameter = 19,
            },
            Transmission = new Helpers.Transmission
            {
                Type = TransmissionType.AT,
                GearRatiosFront = new float[]
                    {
                        3.552f,
                        2.022f,
                        1.452f,
                        1.000f,
                        0.708f,
                        0.599f,
                        //Ratio7
                        //Ratio8
                        //Ratio9
                        //Ratio10
                    },
                GearRatioRear = 3.893f,
                ReductionRatioFront = 4.624f,
                ReductionRatioRear = 2.928f,
            }
        };
    }

    public string FormatAsPrice(int? price)
    {
        return String.Format(new System.Globalization.CultureInfo("ja-JP"), "{0:C0}", price);
    }

    public List<KeyValuePair<string, string>> ModelChangeDates(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("フル", car.ModelChangeFull),
            new KeyValuePair<string, string>("最終", car.ModelChangeLast),
        };
    }

    public List<KeyValuePair<string, string>> SuspensionTypes(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("前", car.SuspensionFront),
            new KeyValuePair<string, string>("後", car.SuspensionRear),
        };
    }
    public List<KeyValuePair<string, string>> BrakeTypes(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("前", car.BrakeFront),
            new KeyValuePair<string, string>("後", car.BrakeRear),
        };
    }

    // private async Task<Helpers.Car> GetCar(int id)
    // {
    //     return await CarRepo.GetCar(id);
    // }

    // async void ButtonClicked()
    // {
    //     //
    //     //CultureInfo ci = new CultureInfo("es-MX", false);
    //     //CultureInfo.CurrentCulture = ci;
    //     Console.WriteLine(CultureInfo.CurrentCulture.ToString());
    //     Car = await GetCar(this.Id);
    // }

    // public void Dispose() => Interceptor.DisposeEvent();
}
