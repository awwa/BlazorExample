using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using HogeBlazor.Client.Helpers;
using System.Reflection;

namespace HogeBlazor.Client.Models;

public class CarDisp
{
    [DisplayName("ID")]
    public int Id { get; set; }

    [DisplayName("メーカー名")]
    public string MakerName { get; set; } = string.Empty;

    [DisplayName("モデル名")]
    public string ModelName { get; set; } = string.Empty;

    [DisplayName("URL")]
    public string? Url { get; set; }

    [DisplayName("イメージURL")]
    public string? ImageUrl { get; set; }

    // 基本情報
    [DisplayName("ボディタイプ")]
    public string? BodyType { get; set; }

    [DisplayName("駆動方式")]
    public string? DriveSystem { get; set; }

    [DisplayName("パワートレイン")]
    public string? PowerTrain { get; set; }

    [DisplayName("型式")]
    public string ModelCode { get; set; } = string.Empty;

    [DisplayName("グレード")]
    public string GradeName { get; set; } = string.Empty;

    [DisplayName("小売価格（税込/円）")]
    public int? Price { get; set; }

    [DisplayName("モデルチェンジ")]
    public ModelChange ModelChange { get; set; } = new ModelChange();

    [DisplayName("ステアリング形式")]
    public string? Steering { get; set; }

    [DisplayName("サスペンション形式")]
    public Suspension Suspension { get; set; } = new Suspension();

    [DisplayName("ブレーキ形式")]
    public Brake Brake { get; set; } = new Brake();

    [DisplayName("燃費向上対策")]
    public string[] FuelEfficiency { get; set; } = new string[] { };

    // 性能
    [DisplayName("最小回転半径(m)")]
    public float? MinTurningRadius { get; set; }

    [DisplayName("燃料消費率")]
    public Fcr Fcr { get; set; } = new Fcr();

    [DisplayName("交流電力消費率")]
    public Ecr Ecr { get; set; } = new Ecr();

    // エンジン
    [DisplayName("エンジン")]
    public Engine Engine { get; set; } = new Engine();

    // モーター1
    [DisplayName("モーター1")]
    public Motor MotorX { get; set; } = new Motor();

    // モーター2
    [DisplayName("モーター2")]
    public Motor MotorY { get; set; } = new Motor();

    // バッテリー
    [DisplayName("バッテリー")]
    public Battery Battery { get; set; } = new Battery();

    // タイヤ
    [DisplayName("幅(mm)")]
    public SectionWidth SectionWidth { get; set; } = new SectionWidth();

    [DisplayName("扁平率(%)")]
    public AspectRatio AspectRatio { get; set; } = new AspectRatio();

    [DisplayName("ホイール径(インチ)")]
    public WheelDiameter WheelDiameter { get; set; } = new WheelDiameter();

    // トランスミッション
    [DisplayName("トランスミッション")]
    public Transmission Transmission { get; set; } = new Transmission();

    // 外寸(mm)
    [DisplayName("外寸")]
    public OuterBody OuterBody { get; set; } = new OuterBody();

    // 内寸(mm)
    [DisplayName("内寸")]
    public InteriorBody InteriorBody { get; set; } = new InteriorBody();

    // その他
    [DisplayName("その他")]
    public OtherBody OtherBody { get; set; } = new OtherBody();

    public CarDisp()
    {

    }

    public CarDisp(Car car)
    {
        Id = car.Id;
        MakerName = car.MakerName;
        ModelName = car.ModelName;
        Url = car.Url;
        ImageUrl = car.ImageUrl;
        BodyType = car.Body.Type;
        DriveSystem = car.DriveSystem;
        PowerTrain = car.PowerTrain;
        ModelCode = car.ModelCode;
        GradeName = car.GradeName;
        Price = car.Price;
        ModelChange = new ModelChange()
        {
            Full = car.ModelChangeFull,
            Last = car.ModelChangeLast,
        };
        Steering = car.Steering;
        Suspension = new Suspension()
        {
            Front = car.SuspensionFront,
            Rear = car.SuspensionRear,
        };
        Brake = new Brake()
        {
            Front = car.BrakeFront,
            Rear = car.BrakeRear,
        };
        FuelEfficiency = car.FuelEfficiency.ToArray<string>();
        MinTurningRadius = car.Performance.MinTurningRadius;
        Fcr = new Fcr()
        {
            FcrWltc = car.Performance.FcrWltc,
            FcrWltcL = car.Performance.FcrWltcL,
            FcrWltcM = car.Performance.FcrWltcM,
            FcrWltcH = car.Performance.FcrWltcH,
            FcrJc08 = car.Performance.FcrJc08,
        };
        Ecr = new Ecr()
        {
            EcrWltc = car.Performance.EcrWltc,
            EcrWltcL = car.Performance.EcrWltcL,
            EcrWltcM = car.Performance.EcrWltcM,
            EcrWltcH = car.Performance.EcrWltcH,
            EcrJc08 = car.Performance.EcrJc08,
            MpcWltc = car.Performance.MpcWltc,
            MpcJc08 = car.Performance.MpcJc08,
        };
        Engine = new Engine()
        {
            Code = car.Engine.Code,
            Type = car.Engine.Type,
            CylinderNum = car.Engine.CylinderNum,
            CylinderLayout = car.Engine.CylinderLayout,
            ValveSystem = car.Engine.ValveSystem,
            Displacement = car.Engine.Displacement,
            Bore = car.Engine.Bore,
            Stroke = car.Engine.Stroke,
            CompressionRatio = car.Engine.CompressionRatio,
            MaxOutput = car.Engine.MaxOutput,
            MaxOutputRpm = new MaxOutputRpm()
            {
                Lower = car.Engine.MaxOutputLowerRpm,
                Upper = car.Engine.MaxOutputUpperRpm,
            },
            MaxTorque = car.Engine.MaxTorque,
            MaxTorqueRpm = new MaxTorqueRpm()
            {
                Lower = car.Engine.MaxTorqueLowerRpm,
                Upper = car.Engine.MaxTorqueUpperRpm,
            },
            FuelSystem = car.Engine.FuelSystem,
            FuelType = car.Engine.FuelType,
            FuelTankCap = car.Engine.FuelTankCap,
        };
        MotorX = new Motor()
        {
            Code = car.MotorX.Code,
            Type = car.MotorX.Type,
            Purpose = car.MotorX.Purpose,
            RatedOutput = car.MotorX.RatedOutput,
            MaxOutput = car.MotorX.MaxOutput,
            MaxOutputRpm = new MaxOutputRpm()
            {
                Lower = car.MotorX.MaxOutputLowerRpm,
                Upper = car.MotorX.MaxOutputUpperRpm,
            },
            MaxTorque = car.MotorX.MaxTorque,
            MaxTorqueRpm = new MaxTorqueRpm()
            {
                Lower = car.MotorX.MaxTorqueLowerRpm,
                Upper = car.MotorX.MaxTorqueUpperRpm,
            },
        };
        MotorY = new Motor()
        {
            Code = car.MotorY.Code,
            Type = car.MotorY.Type,
            Purpose = car.MotorY.Purpose,
            RatedOutput = car.MotorY.RatedOutput,
            MaxOutput = car.MotorY.MaxOutput,
            MaxOutputRpm = new MaxOutputRpm()
            {
                Lower = car.MotorY.MaxOutputLowerRpm,
                Upper = car.MotorY.MaxOutputUpperRpm,
            },
            MaxTorque = car.MotorY.MaxTorque,
            MaxTorqueRpm = new MaxTorqueRpm()
            {
                Lower = car.MotorY.MaxTorqueLowerRpm,
                Upper = car.MotorY.MaxTorqueUpperRpm,
            },
        };
        Battery = new Battery()
        {
            Type = car.Battery.Type,
            Quantity = car.Battery.Quantity,
            Voltage = car.Battery.Voltage,
            Capacity = car.Battery.Capacity,
        };
        SectionWidth = new SectionWidth()
        {
            Front = car.TireFront.SectionWidth,
            Rear = car.TireRear.SectionWidth,
        };
        AspectRatio = new AspectRatio()
        {
            Front = car.TireFront.AspectRatio,
            Rear = car.TireRear.AspectRatio,
        };
        WheelDiameter = new WheelDiameter()
        {
            Front = car.TireFront.WheelDiameter,
            Rear = car.TireRear.WheelDiameter,
        };
        Transmission = new Transmission();
        Transmission.TransmissionType = car.Transmission.Type;
        if (car.Transmission.GearRatiosFront != null)
        {
            for (var i = 0; i < car.Transmission.GearRatiosFront.Count(); i++)
            {
                Transmission.GearRatios.Add(new KeyValuePair<string, float?>($"第{i + 1}速", car.Transmission.GearRatiosFront.ElementAt(i)));
            }
        }
        if (car.Transmission.GearRatioRear != null)
        {
            Transmission.GearRatios.Add(new KeyValuePair<string, float?>($"後退", car.Transmission.GearRatioRear));
        }
        Transmission.ReductionRatio = new ReductionRatio()
        {
            Front = car.Transmission.ReductionRatioFront,
            Rear = car.Transmission.ReductionRatioRear,
        };

        OuterBody = new OuterBody()
        {
            Length = car.Body.Length,
            Width = car.Body.Width,
            Height = car.Body.Height,
            WheelBase = car.Body.WheelBase,
            TreadFront = car.Body.TreadFront,
            TreadRear = car.Body.TreadRear,
            MinRoadClearance = car.Body.MinRoadClearance,
        };
        InteriorBody = new InteriorBody()
        {
            Length = car.Interior.Length,
            Width = car.Interior.Width,
            Height = car.Interior.Height,
        };
        OtherBody = new OtherBody()
        {
            Weight = car.Body.Weight,
            DoorNum = car.Body.DoorNum,
            LuggageCap = car.Interior.LuggageCap,
            RidingCap = car.Interior.RidingCap,
        };
    }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.CarDisp).FullName!, property);
    }
}

public class ModelChange
{
    [DisplayName("フル")]
    public string? Full { get; set; }

    [DisplayName("最終")]
    public string? Last { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.ModelChange).FullName!, property);
    }
}

public class Suspension
{
    [DisplayName("前")]
    public string? Front { get; set; }

    [DisplayName("後")]
    public string? Rear { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Suspension).FullName!, property);
    }
}

public class Brake
{
    [DisplayName("前")]
    public string? Front { get; set; }

    [DisplayName("後")]
    public string? Rear { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Brake).FullName!, property);
    }
}

public class SectionWidth
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.SectionWidth).FullName!, property);
    }
}

public class AspectRatio
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.AspectRatio).FullName!, property);
    }
}

public class WheelDiameter
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.WheelDiameter).FullName!, property);
    }
}

public class OuterBody
{
    [DisplayName("全長")]
    public int? Length { get; set; }

    [DisplayName("全幅")]
    public int? Width { get; set; }

    [DisplayName("全高")]
    public int? Height { get; set; }

    [DisplayName("ホイールベース")]
    public int? WheelBase { get; set; }

    [DisplayName("トレッド前")]
    public int? TreadFront { get; set; }

    [DisplayName("トレッド後")]
    public int? TreadRear { get; set; }

    [DisplayName("最低地上高")]
    public int? MinRoadClearance { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.OuterBody).FullName!, property);
    }
}

public class InteriorBody
{
    [DisplayName("室内長")]
    public int? Length { get; set; }

    [DisplayName("室内幅")]
    public int? Width { get; set; }

    [DisplayName("室内高")]
    public int? Height { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.InteriorBody).FullName!, property);
    }
}

public class OtherBody
{
    [DisplayName("車両重量(kg)")]
    public int? Weight { get; set; }

    [DisplayName("ドア数")]
    public int? DoorNum { get; set; }

    [DisplayName("ラゲッジルーム容量(L)")]
    public int? LuggageCap { get; set; }

    [DisplayName("乗車定員(人)")]
    public int? RidingCap { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.OtherBody).FullName!, property);
    }
}

public class Fcr
{
    [DisplayName("燃料消費率WLTCモード(km/L)")]
    public float? FcrWltc { get; set; }

    [DisplayName("市街地モード(WLTC-L)")]
    public float? FcrWltcL { get; set; }

    [DisplayName("郊外モード(WLTC-M)")]
    public float? FcrWltcM { get; set; }

    [DisplayName("高速道路モード(WPTC-H)")]
    public float? FcrWltcH { get; set; }

    [DisplayName("燃料消費率JC08モード(km/L)")]
    public float? FcrJc08 { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Fcr).FullName!, property);
    }
}

public class Ecr
{
    [DisplayName("交流電力消費率WTLCモード(Wh/km)")]
    public float? EcrWltc { get; set; }

    [DisplayName("市街地モード(WLTC-L)")]
    public float? EcrWltcL { get; set; }

    [DisplayName("郊外モード(WLTC-M)")]
    public float? EcrWltcM { get; set; }

    [DisplayName("高速道路モード(WLTC-H)")]
    public float? EcrWltcH { get; set; }

    [DisplayName("一充電走行距離WLTCモード(km)")]
    public float? MpcWltc { get; set; }

    [DisplayName("交流電力消費率JC08モード(Wh/km)")]
    public float? EcrJc08 { get; set; }

    [DisplayName("一充電走行距離JC08モード(km)")]
    public float? MpcJc08 { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Ecr).FullName!, property);
    }
}

// エンジン
public class Engine
{
    [DisplayName("型式")]
    public string? Code { get; set; }

    [DisplayName("種類")]
    public string? Type { get; set; }

    [DisplayName("気筒数")]
    public int? CylinderNum { get; set; }

    [DisplayName("シリンダーレイアウト")]
    public string? CylinderLayout { get; set; }

    [DisplayName("バルブ構造")]
    public string? ValveSystem { get; set; }

    [DisplayName("総排気量(L)")]
    public float? Displacement { get; set; }

    [DisplayName("ボア(mm)")]
    public float? Bore { get; set; }

    [DisplayName("ストローク(mm)")]
    public float? Stroke { get; set; }

    [DisplayName("圧縮比")]
    public float? CompressionRatio { get; set; }

    [DisplayName("最高出力(kW)")]
    public float? MaxOutput { get; set; }

    [DisplayName("最高出力回転数")]
    public MaxOutputRpm MaxOutputRpm { get; set; } = new MaxOutputRpm();

    [DisplayName("最大トルク(Nm)")]
    public float? MaxTorque { get; set; }

    [DisplayName("最大トルク回転数(rpm)")]
    public MaxTorqueRpm MaxTorqueRpm { get; set; } = new MaxTorqueRpm();

    [DisplayName("燃料供給装置")]
    public string? FuelSystem { get; set; }

    [DisplayName("使用燃料種類")]
    public string? FuelType { get; set; }

    [DisplayName("燃料タンク容量(L)")]
    public int? FuelTankCap { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Engine).FullName!, property);
    }
}

public class MaxOutputRpm
{
    [DisplayName("低")]
    public int? Lower { get; set; }

    [DisplayName("高")]
    public int? Upper { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.MaxOutputRpm).FullName!, property);
    }
}

public class MaxTorqueRpm
{
    [DisplayName("低")]
    public int? Lower { get; set; }

    [DisplayName("高")]
    public int? Upper { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.MaxTorqueRpm).FullName!, property);
    }
}

// 電動機
public class Motor
{
    [DisplayName("型式")]
    public string? Code { get; set; }

    [DisplayName("種類")]
    public string? Type { get; set; }

    [DisplayName("用途")]
    public string? Purpose { get; set; }

    [DisplayName("定格出力(kW)")]
    public float? RatedOutput { get; set; }

    [DisplayName("最高出力(kW)")]
    public float? MaxOutput { get; set; }

    [DisplayName("最高出力回転数(rpm)")]
    public MaxOutputRpm MaxOutputRpm { get; set; } = new MaxOutputRpm();

    [DisplayName("最大トルク(Nm)")]
    public float? MaxTorque { get; set; }

    [DisplayName("最大トルク回転数(低)(rpm)")]
    public MaxTorqueRpm MaxTorqueRpm { get; set; } = new MaxTorqueRpm();

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Motor).FullName!, property);
    }
}

// バッテリー
public class Battery
{
    [DisplayName("種類")]
    public string? Type { get; set; }

    [DisplayName("個数")]
    public int? Quantity { get; set; }

    [DisplayName("電圧(V)")]
    public float? Voltage { get; set; }

    [DisplayName("容量(Ah)")]
    public float? Capacity { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Battery).FullName!, property);
    }
}

// 減速比

public class ReductionRatio
{
    [DisplayName("前")]
    public float? Front { get; set; }

    [DisplayName("後")]
    public float? Rear { get; set; }

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.ReductionRatio).FullName!, property);
    }
}

public class Transmission
{
    [DisplayName("種類")]
    public string? TransmissionType { get; set; }

    [DisplayName("変速比")]
    public List<KeyValuePair<string, float?>> GearRatios { get; set; } = new List<KeyValuePair<string, float?>>();

    [DisplayName("減速比")]
    public ReductionRatio ReductionRatio { get; set; } = new ReductionRatio();

    public static string DisplayName(string property)
    {
        return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Transmission).FullName!, property);
    }
}