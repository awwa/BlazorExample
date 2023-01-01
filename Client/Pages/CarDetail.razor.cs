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

    [Parameter]
    public int Id { get; set; }

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        Console.WriteLine($"OnInitializedAsync()1 {Car}");
        // Interceptor.RegisterEvent();
        Car = await GetCar(this.Id);
        Console.WriteLine("OnInitializedAsync()2");
    }

    public string ToPrice(int? price)
    {
        return String.Format(new System.Globalization.CultureInfo("ja-JP"), "{0:C0}", price);
    }

    public string ToString(float? value, string format = "{0:#,0}")
    {
        return String.Format(format, value);
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

    public List<KeyValuePair<string, string>> MaxOutputRpm(Helpers.Car car, string target)
    {
        switch (target)
        {
            case "Engine":
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("高", ToString(car.Engine.MaxOutputUpperRpm)),
                    new KeyValuePair<string, string>("低", ToString(car.Engine.MaxOutputLowerRpm)),
                };
            case "MotorX":
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("高", ToString(car.MotorX.MaxOutputUpperRpm)),
                    new KeyValuePair<string, string>("低", ToString(car.MotorX.MaxOutputLowerRpm)),
                };
            case "MotorY":
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("高", ToString(car.MotorY.MaxOutputUpperRpm)),
                    new KeyValuePair<string, string>("低", ToString(car.MotorY.MaxOutputLowerRpm)),
                };
            default:
                throw new NotImplementedException();
        }
    }
    public List<KeyValuePair<string, string>> MaxTorqueRpm(Helpers.Car car, string target)
    {
        switch (target)
        {
            case "Engine":
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("高", ToString(car.Engine.MaxTorqueUpperRpm)),
                    new KeyValuePair<string, string>("低", ToString(car.Engine.MaxTorqueLowerRpm)),
                };
            case "MotorX":
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("高", ToString(car.MotorX.MaxTorqueUpperRpm)),
                    new KeyValuePair<string, string>("低", ToString(car.MotorX.MaxTorqueLowerRpm)),
                };
            case "MotorY":
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("高", ToString(car.MotorY.MaxTorqueUpperRpm)),
                    new KeyValuePair<string, string>("低", ToString(car.MotorY.MaxTorqueLowerRpm)),
                };
            default:
                throw new NotImplementedException();
        }
    }

    public List<KeyValuePair<string, string>> SectionWidth(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("前", ToString(car.TireFront.SectionWidth)),
            new KeyValuePair<string, string>("後", ToString(car.TireRear.SectionWidth)),
        };
    }

    public List<KeyValuePair<string, string>> AspectRatio(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("前", ToString(car.TireFront.AspectRatio)),
            new KeyValuePair<string, string>("後", ToString(car.TireRear.AspectRatio)),
        };
    }

    public List<KeyValuePair<string, string>> WheelDiameter(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("前", ToString(car.TireFront.WheelDiameter)),
            new KeyValuePair<string, string>("後", ToString(car.TireRear.WheelDiameter)),
        };
    }

    public List<KeyValuePair<string, string>> GearRatios(Helpers.Car car)
    {
        var kvs = new List<KeyValuePair<string, string>>();
        for (int i = 0; i < Car.Transmission.GearRatiosFront.Count; i++)
        {
            kvs.Add(new KeyValuePair<string, string>($"第{i}速", ToString(Car.Transmission.GearRatiosFront.ElementAt<float>(i), "{0:F3}")));
        }
        kvs.Add(new KeyValuePair<string, string>($"後退", ToString(Car.Transmission.GearRatioRear, "{0:F3}")));
        return kvs;
    }

    public List<KeyValuePair<string, string>> ReductionRaios(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>($"前", ToString(Car.Transmission.ReductionRatioFront, "{0:F3}")),
            new KeyValuePair<string, string>($"後", ToString(Car.Transmission.ReductionRatioRear, "{0:F3}")),
        };
    }

    public List<KeyValuePair<string, string>> OuterBody(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>($"全長", ToString(Car.Body.Length)),
            new KeyValuePair<string, string>($"全幅", ToString(Car.Body.Width)),
            new KeyValuePair<string, string>($"全高", ToString(Car.Body.Height)),
            new KeyValuePair<string, string>($"トレッド前", ToString(Car.Body.TreadFront)),
            new KeyValuePair<string, string>($"トレッド後", ToString(Car.Body.TreadRear)),
            new KeyValuePair<string, string>($"最低地上高", ToString(Car.Body.MinRoadClearance)),
        };
    }

    public List<KeyValuePair<string, string>> InteriorBody(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>($"室内長", ToString(Car.Interior.Length)),
            new KeyValuePair<string, string>($"室内幅", ToString(Car.Interior.Width)),
            new KeyValuePair<string, string>($"室内高", ToString(Car.Interior.Height)),
        };
    }

    public List<KeyValuePair<string, string>> OtherBody(Helpers.Car car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>($"車両重量(kg)", ToString(Car.Body.Weight, "{0}")),
            new KeyValuePair<string, string>($"ドア数", ToString(Car.Body.DoorNum, "{0}")),
            new KeyValuePair<string, string>($"ラゲッジルーム容量(L)", ToString(Car.Interior.LuggageCap, "{0}")),
            new KeyValuePair<string, string>($"乗車定員(人)", ToString(Car.Interior.RidingCap, "{0}")),
        };
    }

    private async Task<Helpers.Car> GetCar(int id)
    {
        return await CarRepo.GetCar(id);
    }

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
