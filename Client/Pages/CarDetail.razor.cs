using HogeBlazor.Client.Repositories;
using HogeBlazor.Client.Models;
using Microsoft.AspNetCore.Components;
using HogeBlazor.Shared.Models.Dto;

namespace HogeBlazor.Client.Pages;
public partial class CarDetail// : IDisposable
{
    // [Inject]
    // public HttpInterceptorService Interceptor { get; set; } = default!;

    public CarDto Car { get; set; } = new CarDto(string.Empty);

    [Parameter]
    public string Id { get; set; } = default!;

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        // Interceptor.RegisterEvent();
        Car = await GetCar(this.Id);
    }

    public string ToPrice(int? price)
    {
        return String.Format(new System.Globalization.CultureInfo("ja-JP"), "{0:C0}", price);
    }

    public string ToString(float? value, string format = "{0:#,0}")
    {
        return value == null ? "ー" : String.Format(format, value);
    }

    public List<KeyValuePair<string, string?>> ModelChangeDates(CarDto car)
    {
        return new List<KeyValuePair<string, string?>>
        {
            new KeyValuePair<string, string?>(CarLabel.Full, car.ModelChange.Full),
            new KeyValuePair<string, string?>(CarLabel.Last, car.ModelChange.Last),
        };
    }

    public List<KeyValuePair<string, string?>> SuspensionTypes(CarDto car)
    {
        return new List<KeyValuePair<string, string?>>
        {
            new KeyValuePair<string, string?>(CarLabel.Front, car.Suspension.Front),
            new KeyValuePair<string, string?>(CarLabel.Rear, car.Suspension.Rear),
        };
    }
    public List<KeyValuePair<string, string?>> BrakeTypes(CarDto car)
    {
        return new List<KeyValuePair<string, string?>>
        {
            new KeyValuePair<string, string?>(CarLabel.Front, car.Break.Front),
            new KeyValuePair<string, string?>(CarLabel.Rear, car.Break.Rear),
        };
    }

    public List<KeyValuePair<string, string>> MaxOutputRpm(MaxOutputRpm rpm)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(CarLabel.Upper, ToString(rpm.Upper)),
            new KeyValuePair<string, string>(CarLabel.Lower, ToString(rpm.Lower)),
        };
    }

    public List<KeyValuePair<string, string>> MaxTorqueRpm(MaxTorqueRpm rpm)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(CarLabel.Upper, ToString(rpm.Upper)),
            new KeyValuePair<string, string>(CarLabel.Lower, ToString(rpm.Lower)),
        };
    }

    public List<KeyValuePair<string, string>> SectionWidth(CarDto car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(CarLabel.Front, ToString(car.Tire.SectionWidth.Front)),
            new KeyValuePair<string, string>(CarLabel.Rear, ToString(car.Tire.SectionWidth.Rear)),
        };
    }

    public List<KeyValuePair<string, string>> AspectRatio(CarDto car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(CarLabel.Front, ToString(car.Tire.AspectRatio.Front)),
            new KeyValuePair<string, string>(CarLabel.Rear, ToString(car.Tire.AspectRatio.Rear)),
        };
    }

    public List<KeyValuePair<string, string>> WheelDiameter(CarDto car)
    {
        return new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>(CarLabel.Front, ToString(car.Tire.WheelDiameter.Front)),
            new KeyValuePair<string, string>(CarLabel.Rear, ToString(car.Tire.WheelDiameter.Rear)),
        };
    }

    public List<KeyValuePair<string, string>> GearRatios(CarDto car)
    {
        var kvs = new List<KeyValuePair<string, string>>();
        float[] gears = Car.Transmission.GearRatio.Front;
        for (int i = 0; i < gears.Count(); i++)
        {
            kvs.Add(new KeyValuePair<string, string>($"{i + 1}速", ToString(gears[i], "{0:F3}")));
        }
        return kvs;
    }

    public List<KeyValuePair<string, string>> ReductionRaio(CarDto car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>(CarLabel.Front, ToString(car.Transmission.ReductionRatio != null ? Car.Transmission.ReductionRatio.Front : null, "{0:F3}")),
            new KeyValuePair<string, string>(CarLabel.Rear, ToString(car.Transmission.ReductionRatio != null ? car.Transmission.ReductionRatio.Rear : null, "{0:F3}")),
        };
    }

    public List<KeyValuePair<string, string>> OuterBody(CarDto car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>(CarLabel.OuterBody_Length, ToString(car.OuterBody != null ? car.OuterBody.Length : null)),
            new KeyValuePair<string, string>(CarLabel.OuterBody_Width, ToString(car.OuterBody != null ? car.OuterBody.Width : null)),
            new KeyValuePair<string, string>(CarLabel.OuterBody_Height, ToString(car.OuterBody != null ? car.OuterBody.Height : null)),
            new KeyValuePair<string, string>(CarLabel.Tread + CarLabel.Front, ToString(car.OuterBody != null ? car.OuterBody.Tread.Front : null)),
            new KeyValuePair<string, string>(CarLabel.Tread + CarLabel.Rear, ToString(car.OuterBody != null ? car.OuterBody.Tread.Rear : null)),
            new KeyValuePair<string, string>(CarLabel.MinRoadClearance, ToString(car.OuterBody != null ? car.OuterBody.MinRoadClearance : null)),
        };
    }

    public List<KeyValuePair<string, string>> InteriorBody(CarDto car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>(
                CarLabel.InteriorBody_Length,
                ToString(car.InteriorBody != null ? car.InteriorBody.Length : null)
            ),
            new KeyValuePair<string, string>(
                CarLabel.InteriorBody_Width,
                ToString(car.InteriorBody != null ? car.InteriorBody.Width : null)
            ),
            new KeyValuePair<string, string>(
                CarLabel.InteriorBody_Height,
                ToString(car.InteriorBody != null ? car.InteriorBody.Height : null)
            ),
        };
    }

    public List<KeyValuePair<string, string>> OtherBody(CarDto car)
    {
        return new List<KeyValuePair<string, string>>()
        {
            new KeyValuePair<string, string>(
                CarLabel.Weight,
                ToString(car.OtherBody != null ? car.OtherBody.Weight : null, "{0}")),
            new KeyValuePair<string, string>(
                CarLabel.DoorNum,
                ToString(car.OtherBody != null ? car.OtherBody.DoorNum : null, "{0}")),
            new KeyValuePair<string, string>(
                CarLabel.LuggageCap,
                ToString(car.OtherBody != null ? car.OtherBody.LuggageCap : null, "{0}")),
            new KeyValuePair<string, string>(
                CarLabel.RidingCap,
                ToString(car.OtherBody != null ? car.OtherBody.RidingCap : null, "{0}")),
        };
    }

    private async Task<CarDto> GetCar(string id)
    {
        return await CarRepo.GetCarAsync(id);
    }
}
