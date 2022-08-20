using System.Reflection;
using HogeBlazor.Client.Helpers;
using HogeBlazor.Client.Repositories;
using Microsoft.AspNetCore.Components;

namespace HogeBlazor.Client.Pages;
public partial class Cars
{
    public List<Car> CarList { get; set; } = new List<Car>();

    bool BodyVisible = false;
    bool InteriorVisible = false;
    bool PerformanceVisible = false;
    bool EngineVisible = false;
    bool MotorVisible = false;
    bool BatteryVisible = false;
    bool TireVisible = false;
    bool TransmissionVisible = false;
    bool OtherVisible = false;

    public string TitleMakerName { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("MakerName");
    public string TitleModelName { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("ModelName");
    public string TitleGradeName { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("GradeName");
    public string TitleModelCode { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("ModelCode");
    public string TitlePrice { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("Price");
    public string TitleModelChangeFull { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("ModelChangeFull");
    public string TitleModelChangeLast { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("ModelChangeLast");
    public string TitleBody { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("Body");
    public string TitleBodyType { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("Type");
    public string TitleBodyLength { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("Length");
    public string TitleBodyWidth { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("Width");
    public string TitleBodyHeight { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("Height");
    public string TitleBodyWheelBase { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("WheelBase");
    public string TitleBodyTreadFront { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("TreadFront");
    public string TitleBodyTreadRear { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("TreadRear");
    public string TitleBodyMinRoadClearance { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("MinRoadClearance");
    public string TitleBodyWeight { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("Weight");
    public string TitleBodyDoorNum { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Body>("DoorNum");
    public string TitleInteriorLength { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Interior>("Length");
    public string TitleInteriorWidth { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Interior>("Width");
    public string TitleInteriorHeight { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Interior>("Height");
    public string TitleInteriorLuggageCap { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Interior>("LuggageCap");
    public string TitleInteriorRidingCap { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Interior>("RidingCap");
    public string TitlePerformanceMinTurningRadius { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("MinTurningRadius");
    public string TitlePerformanceFcrWltc { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("FcrWltc");
    public string TitlePerformanceFcrWltcL { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("FcrWltcL");
    public string TitlePerformanceFcrWltcM { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("FcrWltcM");
    public string TitlePerformanceFcrWltcH { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("FcrWltcH");
    public string TitlePerformanceFcrWltcExh { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("FcrWltcExh");
    public string TitlePerformanceFcrJc08 { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("FcrJc08");
    public string TitlePerformanceMpcWltc { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("MpcWltc");
    public string TitlePerformanceEcrWltc { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("EcrWltc");
    public string TitlePerformanceEcrWltcL { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("EcrWltcL");
    public string TitlePerformanceEcrWltcM { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("EcrWltcM");
    public string TitlePerformanceEcrWltcH { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("EcrWltcH");
    public string TitlePerformanceEcrWltcExh { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("EcrWltcExh");
    public string TitlePerformanceEcrJc08 { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("EcrJc08");
    public string TitlePerformanceMpcJc08 { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Performance>("MpcJc08");
    public string TitlePowerTrain { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("PowerTrain");
    public string TitleDriveSystem { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("DriveSystem");
    public string TitleEngineCode { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("Code");
    public string TitleEngineType { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("Type");
    public string TitleEngineCylinderNum { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("CylinderNum");
    public string TitleEngineCylinderLayout { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("CylinderLayout");
    public string TitleEngineValveSystem { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("ValveSystem");
    public string TitleEngineDisplacement { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("Displacement");
    public string TitleEngineBore { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("Bore");
    public string TitleEngineStroke { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("Stroke");
    public string TitleEngineCompressionRatio { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("CompressionRatio");
    public string TitleEngineMaxOutput { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("MaxOutput");
    public string TitleEngineMaxOutputLowerRpm { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("MaxOutputLowerRpm");
    public string TitleEngineMaxOutputUpperRpm { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("MaxOutputUpperRpm");
    public string TitleEngineMaxTorque { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("MaxTorque");
    public string TitleEngineMaxTorqueLowerRpm { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("MaxTorqueLowerRpm");
    public string TitleEngineMaxTorqueUpperRpm { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("MaxTorqueUpperRpm");
    public string TitleEngineFuelSystem { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("FuelSystem");
    public string TitleEngineFuelType { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("FuelType");
    public string TitleEngineFuelTankCap { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Engine>("FuelTankCap");
    public string TitleMotorCode { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("Code");
    public string TitleMotorType { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("Type");
    public string TitleMotorPurpose { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("Purpose");
    public string TitleMotorRatedOutput { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("RatedOutput");
    public string TitleMotorMaxOutput { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("MaxOutput");
    public string TitleMotorMaxOutputLowerRpm { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("MaxOutputLowerRpm");
    public string TitleMotorMaxOutputUpperRpm { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("MaxOutputUpperRpm");
    public string TitleMotorMaxTorque { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("MaxTorque");
    public string TitleMotorMaxTorqueLowerRpm { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("MaxTorqueLowerRpm");
    public string TitleMotorMaxTorqueUpperRpm { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Motor>("MaxTorqueUpperRpm");
    public string TitleBatteryType { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Battery>("Type");
    public string TitleBatteryQuantity { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Battery>("Quantity");
    public string TitleBatteryVoltage { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Battery>("Voltage");
    public string TitleBatteryCapacity { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Battery>("Capacity");
    public string TitleSteering { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("Steering");
    public string TitleSuspensionFront { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("SuspensionFront");
    public string TitleSuspensionRear { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("SuspensionRear");
    public string TitleBrakeFront { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("BrakeFront");
    public string TitleBrakeRear { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("BrakeRear");
    public string TitleTireSectionWidth { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Tire>("SectionWidth");
    public string TitleTireAspectRatio { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Tire>("AspectRatio");
    public string TitleTireWheelDiameter { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Tire>("WheelDiameter");
    public string TitleTransmissionType { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Transmission>("Type");
    public string TitleTransmissionGearRatiosFront { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Transmission>("GearRatiosFront");
    public string TitleTransmissionGearRatioRear { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Transmission>("GearRatioRear");
    public string TitleTransmissionReductionRatioFront { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Transmission>("ReductionRatioFront");
    public string TitleTransmissionReductionRatioRear { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Transmission>("ReductionRatioRear");
    public string TitleFuelEfficiency { get; set; } = CommentHelper.GetCommentAttributeOnProperty<HogeBlazor.Shared.Models.Db.Car>("FuelEfficiency");

    [Inject]
    public ICarHttpRepository CarRepo { get; set; } = default!;

    private string ConvertForDisplay<T>(string value)
    {
        return CommentHelper.GetCommentAttributeOnField<T>(value);
    }

    protected async override Task OnInitializedAsync()
    {
        await GetCars();
    }

    private async Task SelectedPage(int page)
    {
        await GetCars();
    }

    private async Task GetCars()
    {
        CarList = await CarRepo.GetCars();
    }
}
