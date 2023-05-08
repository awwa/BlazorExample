using System.ComponentModel;
using System.Reflection;

namespace HogeBlazor.Shared.Models.Dto;

public class CarDto
{
    [DisplayName("ID")]
    public string Id { get; set; }

    [DisplayName("メーカー名")]
    public string? MakerName { get; set; }

    [DisplayName("モデル名")]
    public string? ModelName { get; set; }

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
    public string? ModelCode { get; set; }

    [DisplayName("グレード")]
    public string? GradeName { get; set; }

    [DisplayName("小売価格（税込/円）")]
    public int? Price { get; set; }

    [DisplayName("モデルチェンジ")]
    public ModelChange ModelChange { get; set; } = new ModelChange();

    [DisplayName("ステアリング形式")]
    public string? Steering { get; set; }

    [DisplayName("サスペンション形式")]
    public Suspension Suspension { get; set; } = new Suspension();

    [DisplayName("ブレーキ形式")]
    public Break Break { get; set; } = new Break();

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
    [DisplayName("タイヤ")]
    public Tire Tire { get; set; } = new Tire();

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

    public CarDto(string id)
    {
        Id = id;
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
    [DisplayName("フル")]
    public string? Full { get; set; }

    [DisplayName("最終")]
    public string? Last { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.ModelChange).FullName!, property);
    // }
}

public class Suspension
{
    [DisplayName("前")]
    public string? Front { get; set; }

    [DisplayName("後")]
    public string? Rear { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Suspension).FullName!, property);
    // }
}

public class Break
{
    [DisplayName("前")]
    public string? Front { get; set; }

    [DisplayName("後")]
    public string? Rear { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Brake).FullName!, property);
    // }
}

public class Tire
{
    [DisplayName("幅(mm)")]
    public SectionWidth SectionWidth { get; set; } = new SectionWidth();

    [DisplayName("扁平率(%)")]
    public AspectRatio AspectRatio { get; set; } = new AspectRatio();

    [DisplayName("ホイール径(インチ)")]
    public WheelDiameter WheelDiameter { get; set; } = new WheelDiameter();
}

public class SectionWidth
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.SectionWidth).FullName!, property);
    // }
}

public class AspectRatio
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }

    //     public static string DisplayName(string property)
    //     {
    //         return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.AspectRatio).FullName!, property);
    //     }
}

public class WheelDiameter
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.WheelDiameter).FullName!, property);
    // }
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

    [DisplayName("トレッド")]
    public Tread Tread { get; set; } = new Tread();

    [DisplayName("最低地上高")]
    public int? MinRoadClearance { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.OuterBody).FullName!, property);
    // }
}

public class Tread
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }
}

public class InteriorBody
{
    [DisplayName("室内長")]
    public int? Length { get; set; }

    [DisplayName("室内幅")]
    public int? Width { get; set; }

    [DisplayName("室内高")]
    public int? Height { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.InteriorBody).FullName!, property);
    // }
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

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.OtherBody).FullName!, property);
    // }
}

public class Fcr
{
    [DisplayName("燃料消費率WLTCモード(km/L)")]
    public float? Wltc { get; set; }

    [DisplayName("市街地モード(WLTC-L)")]
    public float? WltcL { get; set; }

    [DisplayName("郊外モード(WLTC-M)")]
    public float? WltcM { get; set; }

    [DisplayName("高速道路モード(WLTC-H)")]
    public float? WltcH { get; set; }

    [DisplayName("高高速道路モード(WLTC-ExH)")]
    public float? WltcExH { get; set; }

    [DisplayName("燃料消費率JC08モード(km/L)")]
    public float? Jc08 { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Fcr).FullName!, property);
    // }
}

public class Ecr
{
    [DisplayName("交流電力消費率WTLCモード(Wh/km)")]
    public float? Wltc { get; set; }

    [DisplayName("市街地モード(WLTC-L)")]
    public float? WltcL { get; set; }

    [DisplayName("郊外モード(WLTC-M)")]
    public float? WltcM { get; set; }

    [DisplayName("高速道路モード(WLTC-H)")]
    public float? WltcH { get; set; }

    [DisplayName("高高速道路モード(WLTC-ExH)")]
    public float? WltcExH { get; set; }

    [DisplayName("一充電走行距離WLTCモード(km)")]
    public float? MpcWltc { get; set; }

    [DisplayName("交流電力消費率JC08モード(Wh/km)")]
    public float? Jc08 { get; set; }

    [DisplayName("一充電走行距離JC08モード(km)")]
    public float? MpcJc08 { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Ecr).FullName!, property);
    // }
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

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Engine).FullName!, property);
    // }
}

public class MaxOutputRpm
{
    [DisplayName("低")]
    public int? Lower { get; set; }

    [DisplayName("高")]
    public int? Upper { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.MaxOutputRpm).FullName!, property);
    // }
}

public class MaxTorqueRpm
{
    [DisplayName("低")]
    public int? Lower { get; set; }

    [DisplayName("高")]
    public int? Upper { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.MaxTorqueRpm).FullName!, property);
    // }
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

    [DisplayName("最大トルク回転数(rpm)")]
    public MaxTorqueRpm MaxTorqueRpm { get; set; } = new MaxTorqueRpm();

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Motor).FullName!, property);
    // }
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

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Battery).FullName!, property);
    // }
}

public class GearRatio
{
    [DisplayName("")]
    public float[] Front { get; set; } = new float[] { };

    [DisplayName("")]
    public float? Rear { get; set; }
}

// 減速比

public class ReductionRatio
{
    [DisplayName("前")]
    public float? Front { get; set; }

    [DisplayName("後")]
    public float? Rear { get; set; }

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.ReductionRatio).FullName!, property);
    // }
}

public class Transmission
{
    [DisplayName("種類")]
    public string? Type { get; set; }

    [DisplayName("変速比")]
    public GearRatio GearRatio { get; set; } = new GearRatio();

    [DisplayName("減速比")]
    public ReductionRatio ReductionRatio { get; set; } = new ReductionRatio();

    // public static string DisplayName(string property)
    // {
    //     return ModelHelper.DisplayName(typeof(HogeBlazor.Client.Models.Transmission).FullName!, property);
    // }
}