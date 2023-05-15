using System.Reflection;

namespace HogeBlazor.Shared.Models.Dto;

public class CarDto
{
    public string Id { get; set; }
    public string? MakerName { get; set; }
    public string? ModelName { get; set; }
    public string? Url { get; set; }
    public string? ImageUrl { get; set; }
    public string? BodyType { get; set; }
    public string? DriveSystem { get; set; }
    public string? PowerTrain { get; set; }
    public string? ModelCode { get; set; }
    public string? GradeName { get; set; }
    public int? Price { get; set; }
    public ModelChange ModelChange { get; set; } = new ModelChange();
    public string? Steering { get; set; }
    public Suspension Suspension { get; set; } = new Suspension();
    public Break Break { get; set; } = new Break();
    public string[] FuelEfficiency { get; set; } = new string[] { };
    public float? MinTurningRadius { get; set; }
    public Fcr Fcr { get; set; } = new Fcr();
    public Ecr Ecr { get; set; } = new Ecr();
    public Engine Engine { get; set; } = new Engine();
    public Motor MotorX { get; set; } = new Motor();
    public Motor MotorY { get; set; } = new Motor();
    public Battery Battery { get; set; } = new Battery();
    public Tire Tire { get; set; } = new Tire();
    public Transmission Transmission { get; set; } = new Transmission();
    public OuterBody OuterBody { get; set; } = new OuterBody();
    public InteriorBody InteriorBody { get; set; } = new InteriorBody();
    public OtherBody OtherBody { get; set; } = new OtherBody();
    public CarDto(string id)
    {
        Id = id;
    }

    public CarDto Set(string propertyName, object value)
    {
        string[] names = propertyName.Split('_');
        setChild(0, names, null, this, value);
        return this;
    }

    public object? Get(string propertyName)
    {
        string[] names = propertyName.Split('_');
        return getChild(0, names, this);
    }

    private object? setChild(int level, string[] names, PropertyInfo? property, object? cv, object? value)
    {
        object? childValue = this;
        if (property != null)
        {
            childValue = property.GetValue(cv);
            if (childValue == null)
            {
                return this;
            }
        }
        var childProperty = childValue.GetType().GetProperty(names[level]);
        if (childProperty == null)
        {
            throw new ArgumentException($"Invalid property name specified: '{names[level]}'");
        }
        if (level == names.Length - 1)
        {
            childProperty.SetValue(childValue, value);
        }
        else
        {
            childValue = setChild(level + 1, names, childProperty, childValue, value);
        }
        return childValue;
    }

    private object? getChild(int level, string[] names, object parent)
    {
        PropertyInfo? pi = parent.GetType().GetProperty(names[level]);
        if (pi == null)
        {
            throw new ArgumentException($"Invalid property name specified: '{names[level]}'");
        }

        // プロパティが存在
        object? value = pi.GetValue(parent);
        if (names.Length == level + 1)
        {
            // 最後のプロパティ
            return value;
        }
        else
        {
            // 子プロパティを取得
            return getChild(level + 1, names, value!);
        }
    }
}

public class ModelChange
{
    public string? Full { get; set; }
    public string? Last { get; set; }
}

public class Suspension
{
    public string? Front { get; set; }
    public string? Rear { get; set; }
}

public class Break
{
    public string? Front { get; set; }
    public string? Rear { get; set; }
}

public class Tire
{
    public SectionWidth SectionWidth { get; set; } = new SectionWidth();
    public AspectRatio AspectRatio { get; set; } = new AspectRatio();
    public WheelDiameter WheelDiameter { get; set; } = new WheelDiameter();
}

public class SectionWidth
{
    public int? Front { get; set; }
    public int? Rear { get; set; }
}

public class AspectRatio
{
    public int? Front { get; set; }
    public int? Rear { get; set; }
}

public class WheelDiameter
{
    public int? Front { get; set; }
    public int? Rear { get; set; }
}

public class OuterBody
{
    public int? Length { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int? WheelBase { get; set; }
    public Tread Tread { get; set; } = new Tread();
    public int? MinRoadClearance { get; set; }
}

public class Tread
{
    public int? Front { get; set; }
    public int? Rear { get; set; }
}

public class InteriorBody
{
    public int? Length { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
}

public class OtherBody
{
    public int? Weight { get; set; }
    public int? DoorNum { get; set; }
    public int? LuggageCap { get; set; }
    public int? RidingCap { get; set; }
}

public class Fcr
{
    public float? Wltc { get; set; }
    public float? WltcL { get; set; }
    public float? WltcM { get; set; }
    public float? WltcH { get; set; }
    public float? WltcExH { get; set; }
    public float? Jc08 { get; set; }
}

public class Ecr
{
    public float? Wltc { get; set; }
    public float? WltcL { get; set; }
    public float? WltcM { get; set; }
    public float? WltcH { get; set; }
    public float? WltcExH { get; set; }
    public float? MpcWltc { get; set; }
    public float? Jc08 { get; set; }
    public float? MpcJc08 { get; set; }
}

public class Engine
{
    public string? Code { get; set; }
    public string? Type { get; set; }
    public int? CylinderNum { get; set; }
    public string? CylinderLayout { get; set; }
    public string? ValveSystem { get; set; }
    public float? Displacement { get; set; }
    public float? Bore { get; set; }
    public float? Stroke { get; set; }
    public float? CompressionRatio { get; set; }
    public float? MaxOutput { get; set; }
    public MaxOutputRpm MaxOutputRpm { get; set; } = new MaxOutputRpm();
    public float? MaxTorque { get; set; }
    public MaxTorqueRpm MaxTorqueRpm { get; set; } = new MaxTorqueRpm();
    public string? FuelSystem { get; set; }
    public string? FuelType { get; set; }
    public int? FuelTankCap { get; set; }
}

public class MaxOutputRpm
{
    public int? Lower { get; set; }
    public int? Upper { get; set; }
}

public class MaxTorqueRpm
{
    public int? Lower { get; set; }
    public int? Upper { get; set; }
}

public class Motor
{
    public string? Code { get; set; }
    public string? Type { get; set; }
    public string? Purpose { get; set; }
    public float? RatedOutput { get; set; }
    public float? MaxOutput { get; set; }
    public MaxOutputRpm MaxOutputRpm { get; set; } = new MaxOutputRpm();
    public float? MaxTorque { get; set; }
    public MaxTorqueRpm MaxTorqueRpm { get; set; } = new MaxTorqueRpm();
}

public class Battery
{
    public string? Type { get; set; }
    public int? Quantity { get; set; }
    public float? Voltage { get; set; }
    public float? Capacity { get; set; }
}

public class GearRatio
{
    public float[] Front { get; set; } = new float[] { };
    public float? Rear { get; set; }
}


public class ReductionRatio
{
    public float? Front { get; set; }
    public float? Rear { get; set; }
}

public class Transmission
{
    public string? Type { get; set; }
    public GearRatio GearRatio { get; set; } = new GearRatio();
    public ReductionRatio ReductionRatio { get; set; } = new ReductionRatio();
}

// /// <summary>
// /// ボディタイプ
// /// </summary>
// public class BodyType
// {
//     private const string SEDAN = "SEDAN";
//     public const string HATCHBACK = "HATCHBACK";
//     public const string CROSS_COUNTRY = "CROSS_COUNTRY";
//     public const string K = "K";
//     public const string COUPE = "COUPE";
//     public const string STATION_WAGON = "STATION_WAGON";
//     public const string SUV = "SUV";
//     public const string ONEBOX = "ONEBOX";
//     public const string K_OPEN = "K_OPEN";
//     public const string K_ONEBOX = "K_ONEBOX";
//     public const string OPEN = "OPEN";
//     public const string PICKUP_TRUCK = "PICKUP_TRUCK";
// }

// /// <summary>
// /// パワートレイン
// /// </summary>
// public class PowerTrain
// {
//     public const string ICE = "ICE";
//     public const string StrHV = "StrHV";
//     public const string MldHV = "MldHV";
//     public const string SerHV = "SerHV";
//     public const string PHEV = "PHEV";
//     public const string BEV = "BEV";
//     public const string RexEV = "RexEV";
//     public const string FCEV = "FCEV";
// }

// /// <summary>
// /// 駆動方式
// /// </summary>
// public class DriveSystem
// {
//     public const string FF = "FF";
//     public const string FR = "FR";
//     public const string RR = "RR";
//     public const string MR = "MR";
//     public const string AWD = "AWD";
// }

// /// <summary>
// /// シリンダーレイアウト
// /// </summary>
// public class CylinderLayout
// {
//     public const string I = "I";
//     public const string V = "V";
//     public const string B = "B";
//     public const string W = "W";
// }

// /// <summary>
// /// バルブ構造
// /// </summary>
// public class ValveSystem
// {
//     public const string SV = "SV";
//     public const string OHV = "OHV";
//     public const string SOHC = "SOHC";
//     public const string DOHC = "DOHC";
// }

// /// <summary>
// /// 使用燃料種類
// /// </summary>
// public class FuelType
// {
//     public const string DIESEL = "DIESEL";
//     public const string REGULAR = "REGULAR";
//     public const string PREMIUM = "PREMIUM";
//     public const string LPG = "LPG";
//     public const string BIO = "BIO";
//     public const string HYDROGEN = "HYDROGEN";
// }

// /// <summary>
// /// トランスミッション種類
// /// </summary>
// public class TransmissionType
// {
//     public const string AT = "AT";
//     public const string DCT = "DCT";
//     public const string AMT = "AMT";
//     public const string MT = "MT";
//     public const string CVT = "CVT";
//     public const string PG = "PG";
// }