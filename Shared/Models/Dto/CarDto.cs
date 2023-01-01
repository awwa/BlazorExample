using System.ComponentModel;

namespace HogeBlazor.Shared.Models.Dto;

public class CarDto
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
    public string BodyType { get; set; } = string.Empty;

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
    public ModelChange ModelChange { get; set; } = default!;

    [DisplayName("ステアリング形式")]
    public string? Steering { get; set; }

    [DisplayName("サスペンション形式")]
    public string? Suspension { get; set; } = default!;

    [DisplayName("ブレーキ形式")]
    public string? Brake { get; set; } = default!;

    [DisplayName("燃費向上対策")]
    public string[] FuelEfficiency { get; set; } = default!;

    // 性能
    [DisplayName("最小回転半径(m)")]
    public float? MinTurningRadius { get; set; }

    [DisplayName("燃料消費率")]
    public Fcr Fcr { get; set; } = default!;

    [DisplayName("交流電力消費率")]
    public Ecr Ecr { get; set; } = default!;

    // エンジン
    [DisplayName("エンジン")]
    public Engine Engine { get; set; } = default!;

    // モーター1
    [DisplayName("モーター1")]
    public Motor MotorX { get; set; } = default!;

    // モーター2
    [DisplayName("モーター2")]
    public Motor MotorY { get; set; } = default!;

    // バッテリー
    [DisplayName("バッテリー")]
    public Battery Battery { get; set; } = default!;

    // タイヤ
    [DisplayName("幅(mm)")]
    public SectionWidth SectionWidth { get; set; } = default!;

    [DisplayName("扁平率(%)")]
    public AspectRatio AspectRatio { get; set; } = default!;

    [DisplayName("ホイール径(インチ)")]
    public WheelDiameter WheelDiameter { get; set; } = default!;

    // トランスミッション
    [DisplayName("種類")]
    public string? TransmissionType { get; set; }

    [DisplayName("変速比")]
    public Dictionary<string, float?> GearRatios { get; set; } = default!;

    public ReductionRatio ReductionRatio { get; set; } = default!;

    // 外寸(mm)
    public OuterBody OuterBody { get; set; } = default!;

    // 内寸(mm)
    public InteriorBody InteriorBody { get; set; } = default!;

    // その他
    public OtherBody OtherBody { get; set; } = default!;
}

public class ModelChange
{
    [DisplayName("フル")]
    public string? Full { get; set; }

    [DisplayName("最終")]
    public string? Last { get; set; }
}

public class Suspension
{
    [DisplayName("前")]
    public string? Front { get; set; }

    [DisplayName("後")]
    public string? Rear { get; set; }
}

public class Brake
{
    [DisplayName("前")]
    public string? Front { get; set; }

    [DisplayName("後")]
    public string? Rear { get; set; }
}

public class SectionWidth
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }
}

public class AspectRatio
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }
}

public class WheelDiameter
{
    [DisplayName("前")]
    public int? Front { get; set; }

    [DisplayName("後")]
    public int? Rear { get; set; }
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
}

public class InteriorBody
{
    [DisplayName("室内長")]
    public int? Length { get; set; }

    [DisplayName("室内幅")]
    public int? Width { get; set; }

    [DisplayName("室内高")]
    public int? Height { get; set; }
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
    public MaxOutputRpm MaxOutputRpm { get; set; } = default!;

    [DisplayName("最大トルク(Nm)")]
    public float? MaxTorque { get; set; }

    [DisplayName("最大トルク回転数(rpm)")]
    public MaxTorqueRpm MaxTorqueRpm { get; set; } = default!;

    [DisplayName("燃料供給装置")]
    public string? FuelSystem { get; set; }

    [DisplayName("使用燃料種類")]
    public string? FuelType { get; set; }

    [DisplayName("燃料タンク容量(L)")]
    public int? FuelTankCap { get; set; }
}

public class MaxOutputRpm
{
    [DisplayName("低")]
    public int? Lower { get; set; }

    [DisplayName("高")]
    public int? Upper { get; set; }
}

public class MaxTorqueRpm
{
    [DisplayName("低")]
    public int? Lower { get; set; }

    [DisplayName("高")]
    public int? Upper { get; set; }
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

    [DisplayName("最高出力回転数(低)(rpm)")]
    public int? MaxOutputLowerRpm { get; set; }

    [DisplayName("最高出力回転数(高)(rpm)")]
    public int? MaxOutputUpperRpm { get; set; }

    [DisplayName("最大トルク(Nm)")]
    public float? MaxTorque { get; set; }

    [DisplayName("最大トルク回転数(低)(rpm)")]
    public int? MaxTorqueLowerRpm { get; set; }

    [DisplayName("最大トルク回転数(高)(rpm)")]
    public int? MaxTorqueUpperRpm { get; set; }
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
}

// 減速比

public class ReductionRatio
{
    [DisplayName("前")]
    public float? Front { get; set; }

    [DisplayName("後")]
    public float? Rear { get; set; }
}
