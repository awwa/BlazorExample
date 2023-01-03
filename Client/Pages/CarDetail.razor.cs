using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Models;
using Microsoft.AspNetCore.Components;
using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Pages;
public partial class CarDetail// : IDisposable
{
    // [Inject]
    // public HttpInterceptorService Interceptor { get; set; } = default!;

    public CarDisp Car { get; set; } = new CarDisp();//default!;

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
        return value == null ? "ー" : String.Format(format, value);
    }

    public List<KeyValuePair<string, string?>> ModelChangeDates(CarDisp car)
    {
        return new List<KeyValuePair<string, string?>>
        {
            new KeyValuePair<string, string?>(ModelChange.DisplayName("Full"), car.ModelChange != null ? car.ModelChange.Full : null
            ),
            new KeyValuePair<string, string?>(ModelChange.DisplayName("Last"), car.ModelChange != null ? car.ModelChange.Last : null
            ),
        };
    }

    public List<KeyValuePair<string, string?>> SuspensionTypes(CarDisp car)
    {
        return new List<KeyValuePair<string, string?>>
        {
            new KeyValuePair<string, string?>(Suspension.DisplayName("Front"), car.Suspension != null ? car.Suspension.Front : null),
            new KeyValuePair<string, string?>(Suspension.DisplayName("Rear"), car.Suspension != null ? car.Suspension.Rear : null),
        };
    }
    public List<KeyValuePair<string, string?>> BrakeTypes(CarDisp car)
    {
        return new List<KeyValuePair<string, string?>>
        {
            new KeyValuePair<string, string?>(Brake.DisplayName("Front"), car.Brake != null ? car.Brake.Front : null),
            new KeyValuePair<string, string?>(Brake.DisplayName("Rear"), car.Brake != null ? car.Brake.Rear: null),
        };
    }

    public List<KeyValuePair<string, string>> MaxOutputRpm(HogeBlazor.Client.Models.MaxOutputRpm rpm)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.MaxOutputRpm.DisplayName("Upper"),ToString(rpm.Upper)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.MaxOutputRpm.DisplayName("Lower") ,ToString(rpm.Lower)),
        };
    }

    public List<KeyValuePair<string, string>> MaxTorqueRpm(HogeBlazor.Client.Models.MaxTorqueRpm rpm)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.MaxTorqueRpm.DisplayName("Upper"),ToString(rpm.Upper)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.MaxTorqueRpm.DisplayName( "Lower"),ToString(rpm.Lower)),
        };
    }

    public List<KeyValuePair<string, string>> SectionWidth(CarDisp car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.SectionWidth.DisplayName( "Front"),ToString(car.SectionWidth != null ? car.SectionWidth.Front : null)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.SectionWidth.DisplayName("Rear"),ToString(car.SectionWidth != null ? car.SectionWidth.Rear : null)),
        };
    }

    public List<KeyValuePair<string, string>> AspectRatio(CarDisp car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.AspectRatio.DisplayName("Front"),ToString(car.AspectRatio != null ? car.AspectRatio.Front : null)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.AspectRatio.DisplayName("Rear"),ToString(car.AspectRatio != null ? car.AspectRatio.Rear : null)),
        };
    }

    public List<KeyValuePair<string, string>> WheelDiameter(CarDisp car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.WheelDiameter.DisplayName("Front"),ToString(car.WheelDiameter != null ? car.WheelDiameter.Front : null)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.WheelDiameter.DisplayName("Rear"),ToString(car.WheelDiameter != null ? car.WheelDiameter.Rear : null)),
        };
    }

    public List<KeyValuePair<string, string>> GearRatios(CarDisp car)
    {
        var kvs = new List<KeyValuePair<string, string>>();
        foreach (var item in Car.Transmission.GearRatios)
        {
            kvs.Add(new KeyValuePair<string, string>(item.Key, ToString(item.Value, "{0:F3}")));
        }
        return kvs;
    }

    public List<KeyValuePair<string, string>> ReductionRaio(CarDisp car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.ReductionRatio.DisplayName("Front"),ToString(car.Transmission.ReductionRatio != null ? Car.Transmission.ReductionRatio.Front : null, "{0:F3}")),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.ReductionRatio.DisplayName("Rear"),ToString(car.Transmission.ReductionRatio != null ? car.Transmission.ReductionRatio.Rear : null, "{0:F3}")),
        };
    }

    public List<KeyValuePair<string, string>> OuterBody(CarDisp car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.OuterBody.DisplayName("Length"),ToString(car.OuterBody != null ? car.OuterBody.Length : null)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.OuterBody.DisplayName("Width"),ToString(car.OuterBody != null ? car.OuterBody.Width : null)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.OuterBody.DisplayName("Height"),ToString(car.OuterBody != null ? car.OuterBody.Height : null)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.OuterBody.DisplayName("TreadFront"),ToString(car.OuterBody != null ? car.OuterBody.TreadFront : null)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.OuterBody.DisplayName("TreadRear"),ToString(car.OuterBody != null ? car.OuterBody.TreadRear : null)),
            new KeyValuePair<string, string>(HogeBlazor.Client.Models.OuterBody.DisplayName("MinRoadClearance"),ToString(car.OuterBody != null ? car.OuterBody.MinRoadClearance : null)),
        };
    }

    public List<KeyValuePair<string, string>> InteriorBody(CarDisp car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>(
                HogeBlazor.Client.Models.InteriorBody.DisplayName("Length"),
                ToString(car.InteriorBody != null ? car.InteriorBody.Length : null)
            ),
            new KeyValuePair<string, string>(
                HogeBlazor.Client.Models.InteriorBody.DisplayName("Width"),
                ToString(car.InteriorBody != null ? car.InteriorBody.Width : null)
            ),
            new KeyValuePair<string, string>(
                HogeBlazor.Client.Models.InteriorBody.DisplayName("Height"),
                ToString(car.InteriorBody != null ? car.InteriorBody.Height : null)
            ),
        };
    }

    public List<KeyValuePair<string, string>> OtherBody(CarDisp car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>(
                HogeBlazor.Client.Models.OtherBody.DisplayName("Weight"),
                ToString(car.OtherBody != null ? car.OtherBody.Weight : null, "{0}")),
            new KeyValuePair<string, string>(
                HogeBlazor.Client.Models.OtherBody.DisplayName("DoorNum"),
                ToString(car.OtherBody != null ? car.OtherBody.DoorNum : null, "{0}")),
            new KeyValuePair<string, string>(
                HogeBlazor.Client.Models.OtherBody.DisplayName("LuggageCap"),
                ToString(car.OtherBody != null ? car.OtherBody.LuggageCap : null, "{0}")),
            new KeyValuePair<string, string>(
                HogeBlazor.Client.Models.OtherBody.DisplayName("RidingCap"),
                ToString(car.OtherBody != null ? car.OtherBody.RidingCap : null, "{0}")),
        };
    }

    private async Task<CarDisp> GetCar(int id)
    {
        return new CarDisp(await CarRepo.GetCar(id));
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
