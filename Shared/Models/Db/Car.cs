using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Shared.Models.Db;

public class Car
{
    [Comment("ID")]
    public int Id { get; set; }

    [Comment("削除日時")]
    public DateTime? DeletedAt { get; set; }

    [Comment("作成日時")]
    public DateTime CreatedAt { get; set; }

    [Comment("更新日時")]
    public DateTime UpdatedAt { get; set; }

    [Comment("メーカー名")]
    public string MakerName { get; set; } = string.Empty;

    [Comment("モデル名")]
    public string ModelName { get; set; } = string.Empty;

    [Comment("グレード")]
    public string GradeName { get; set; } = string.Empty;

    [Comment("型式")]
    public string ModelCode { get; set; } = string.Empty;

    [Comment("小売価格（税込/円）")]
    public int? Price { get; set; }

    [Comment("URL")]
    public string? Url { get; set; }

    [Comment("イメージURL")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// フルモデルチェンジ時期(日本)[yyyy-mm-dd]
    /// </summary>
    /// <value></value>
    [Comment("フルモデルチェンジ")]
    public string? ModelChangeFull { get; set; }

    /// <summary>
    /// 最終モデルチェンジ時期(日本)[yyyy-mm-dd]
    /// </summary>
    /// <value></value>
    [Comment("最終モデルチェンジ")]
    public string? ModelChangeLast { get; set; }

    [Comment("車体")]
    public Body Body { get; set; } = default!;

    [Comment("車内")]
    public Interior Interior { get; set; } = default!;

    [Comment("性能")]
    public Performance Performance { get; set; } = default!;

    [Comment("パワートレイン")]
    public string? PowerTrain { get; set; }

    [Comment("駆動方式")]
    public string? DriveSystem { get; set; }

    [Comment("エンジン")]
    public Engine Engine { get; set; } = default!;

    [Comment("電動機X")]
    public Motor MotorX { get; set; } = default!;

    [Comment("電動機Y")]
    public Motor MotorY { get; set; } = default!;

    [Comment("バッテリー")]
    public Battery Battery { get; set; } = default!;

    [Comment("ステアリング形式")]
    public string? Steering { get; set; }

    [Comment("サスペンション形式前")]
    public string? SuspensionFront { get; set; }

    [Comment("サスペンション形式後")]
    public string? SuspensionRear { get; set; }

    [Comment("ブレーキ形式前")]
    public string? BrakeFront { get; set; }

    [Comment("ブレーキ形式後")]
    public string? BrakeRear { get; set; }

    [Comment("タイヤ前")]
    public Tire TireFront { get; set; } = default!;

    [Comment("タイヤ後")]
    public Tire TireRear { get; set; } = default!;

    [Comment("トランスミッション")]
    public Transmission Transmission { get; set; } = default!;

    [Comment("燃費向上対策")]
    public string[] FuelEfficiency { get; set; } = default!;
}

[Owned]
public class Body
{
    [Comment("ボディタイプ")]
    public string? Type { get; set; }

    [Comment("全長(mm)")]
    public int? Length { get; set; }

    [Comment("全幅(mm)")]
    public int? Width { get; set; }

    [Comment("全高(mm)")]
    public int? Height { get; set; }

    [Comment("ホイールベース(mm)")]
    public int? WheelBase { get; set; }

    [Comment("トレッド前(mm)")]
    public int? TreadFront { get; set; }

    [Comment("トレッド後(mm)")]
    public int? TreadRear { get; set; }

    [Comment("最低地上高(mm)")]
    public int? MinRoadClearance { get; set; }

    [Comment("車両重量(kg)")]
    public int? Weight { get; set; }

    [Comment("ドア数")]
    public int? DoorNum { get; set; }
}

// 車内
[Owned]
public class Interior
{
    [Comment("室内長(mm)")]
    public int? Length { get; set; }

    [Comment("室内幅(mm)")]
    public int? Width { get; set; }

    [Comment("室内高(mm)")]
    public int? Height { get; set; }

    [Comment("ラゲッジルーム容量(L)")]
    public int? LuggageCap { get; set; }

    [Comment("乗車定員(人)")]
    public int? RidingCap { get; set; }
}

// 性能
[Owned]
public class Performance
{
    [Comment("最小回転半径(m)")]
    public float? MinTurningRadius { get; set; }

    [Comment("燃料消費率WLTCモード(km/L)")]
    public float? FcrWltc { get; set; }

    [Comment("燃料消費率WLTC市街地モード(km/L)")]
    public float? FcrWltcL { get; set; }

    [Comment("燃料消費率WLTC郊外モード(km/L)")]
    public float? FcrWltcM { get; set; }

    [Comment("燃料消費率WLTC高速道路モード(km/L)")]
    public float? FcrWltcH { get; set; }

    [Comment("燃料消費率WLTC高高速道路モード(km/L)")]
    public float? FcrWltcExh { get; set; }

    [Comment("燃料消費率JC08モード(km/L)")]
    public float? FcrJc08 { get; set; }

    [Comment("一充電走行距離WLTCモード(km)")]
    public float? MpcWltc { get; set; }

    [Comment("交流電力消費率WTLCモード(Wh/km)")]
    public float? EcrWltc { get; set; }

    [Comment("交流電力消費率WLTC市街地モード(Wh/km)")]
    public float? EcrWltcL { get; set; }

    [Comment("交流電力消費率WLTC郊外モード(Wh/km)")]
    public float? EcrWltcM { get; set; }

    [Comment("交流電力消費率WLTC高速道路モード(Wh/km)")]
    public float? EcrWltcH { get; set; }

    [Comment("交流電力消費率WLTC高高速道路モード(Wh/km)")]
    public float? EcrWltcExh { get; set; }

    [Comment("交流電力消費率JC08モード(Wh/km)")]
    public float? EcrJc08 { get; set; }

    [Comment("一充電走行距離JC08モード(km)")]
    public float? MpcJc08 { get; set; }
}

// エンジン
[Owned]
public class Engine
{
    [Comment("エンジン型式")]
    public string? Code { get; set; }

    [Comment("エンジン種類")]
    public string? Type { get; set; }

    [Comment("気筒数")]
    public int? CylinderNum { get; set; }

    [Comment("シリンダーレイアウト")]
    public string? CylinderLayout { get; set; }

    [Comment("バルブ構造")]
    public string? ValveSystem { get; set; }

    [Comment("総排気量(L)")]
    public float? Displacement { get; set; }

    [Comment("ボア(mm)")]
    public float? Bore { get; set; }

    [Comment("ストローク(mm)")]
    public float? Stroke { get; set; }

    [Comment("圧縮比")]
    public float? CompressionRatio { get; set; }

    [Comment("最高出力(kW)")]
    public float? MaxOutput { get; set; }

    [Comment("最高出力回転数(低)(rpm)")]
    public int? MaxOutputLowerRpm { get; set; }

    [Comment("最高出力回転数(高)(rpm)")]
    public int? MaxOutputUpperRpm { get; set; }

    [Comment("最大トルク(Nm)")]
    public float? MaxTorque { get; set; }

    [Comment("最大トルク回転数(低)(rpm)")]
    public int? MaxTorqueLowerRpm { get; set; }

    [Comment("最大トルク回転数(高)(rpm)")]
    public int? MaxTorqueUpperRpm { get; set; }

    [Comment("燃料供給装置")]
    public string? FuelSystem { get; set; }

    [Comment("使用燃料種類")]
    public string? FuelType { get; set; }

    [Comment("燃料タンク容量(L)")]
    public int? FuelTankCap { get; set; }
}

// 電動機
[Owned]
public class Motor
{
    [Comment("電動機型式")]
    public string? Code { get; set; }

    [Comment("電動機種類")]
    public string? Type { get; set; }

    [Comment("用途(動力前用/動力後用/発電用)")]
    public string? Purpose { get; set; }

    [Comment("定格出力(kW)")]
    public float? RatedOutput { get; set; }

    [Comment("最高出力(kW)")]
    public float? MaxOutput { get; set; }

    [Comment("最高出力回転数(低)(rpm)")]
    public int? MaxOutputLowerRpm { get; set; }

    [Comment("最高出力回転数(高)(rpm)")]
    public int? MaxOutputUpperRpm { get; set; }

    [Comment("最大トルク(Nm)")]
    public float? MaxTorque { get; set; }

    [Comment("最大トルク回転数(低)(rpm)")]
    public int? MaxTorqueLowerRpm { get; set; }

    [Comment("最大トルク回転数(高)(rpm)")]
    public int? MaxTorqueUpperRpm { get; set; }
}

// バッテリー
[Owned]
public class Battery
{
    [Comment("バッテリー種類")]
    public string? Type { get; set; }

    [Comment("バッテリー個数")]
    public int? Quantity { get; set; }

    [Comment("バッテリー電圧(V)")]
    public float? Voltage { get; set; }

    [Comment("バッテリー容量(Ah)")]
    public float? Capacity { get; set; }
}

// タイヤ
[Owned]
public class Tire
{
    [Comment("タイヤ幅(mm)")]
    public int? SectionWidth { get; set; }

    [Comment("扁平率(%)")]
    public int? AspectRatio { get; set; }

    [Comment("ホイール径(インチ)")]
    public int? WheelDiameter { get; set; }
}

// トランスミッション
[Owned]
public class Transmission
{
    [Comment("トランスミッション種類")]
    public string? Type { get; set; }

    [Comment("変速比前進配列")]
    public float[]? GearRatiosFront { get; set; }

    [Comment("変速比後退")]
    public float? GearRatioRear { get; set; }

    [Comment("減速比フロント")]
    public float? ReductionRatioFront { get; set; }

    [Comment("減速比リア")]
    public float? ReductionRatioRear { get; set; }
}

/// <summary>
/// ボディタイプ
/// </summary>
public class BodyType
{
    [Comment("セダン")]
    public const string SEDAN = "SEDAN";
    [Comment("ハッチバック")]
    public const string HATCHBACK = "HATCHBACK";
    [Comment("クロスカントリー")]
    public const string CROSS_COUNTRY = "CROSS_COUNTRY";
    [Comment("ミニバン")]
    public const string MINI_VAN = "MINI_VAN,";
    [Comment("ワンボックスワゴン")]
    public const string ONEBOX_WAGON = "ONEBOX_WAGON";
    [Comment("軽自動車")]
    public const string K = "K";
    [Comment("クーペ")]
    public const string COUPE = "COUPE";
    [Comment("ステーションワゴン")]
    public const string STATION_WAGON = "STATION_WAGON";
    [Comment("SUV")]
    public const string SUV = "SUV";
    [Comment("ワンボックスバン")]
    public const string ONEBOX_VAN = "ONEBOX_VAN";
    [Comment("軽オープン")]
    public const string K_OPEN = "K_OPEN";
    [Comment("軽ワンボックスワゴン")]
    public const string K_ONEBOX_WAGON = "K_ONEBOX_WAGON";
    [Comment("オープン")]
    public const string OPEN = "OPEN";
    [Comment("バン")]
    public const string VAN = "VAN";
    [Comment("軽バン")]
    public const string K_VAN = "K_VAN";
    [Comment("軽ワンボックスバン")]
    public const string K_ONEBOX_VAN = "K_ONEBOX_VAN";
    [Comment("ピックアップトラック")]
    public const string PICKUP_TRUCK = "PICKUP_TRUCK";
}

/// <summary>
/// パワートレイン
/// </summary>
public class PowerTrain
{
    [Comment("エンジン車")]
    public const string ICE = "ICE";
    [Comment("ストロングハイブリッド")]
    public const string StrHV = "StrHV";
    [Comment("マイルドハイブリッド")]
    public const string MldHV = "MldHV";
    [Comment("シリーズハイブリッド")]
    public const string SerHV = "SerHV";
    [Comment("プラグインハイブリッド")]
    public const string PHEV = "PHEV";
    [Comment("バッテリーEV")]
    public const string BEV = "BEV";
    [Comment("レンジエクステンダーEV")]
    public const string RexEV = "RexEV";
    [Comment("燃料電池車")]
    public const string FCEV = "FCEV";
}

/// <summary>
/// 駆動方式
/// </summary>
public class DriveSystem
{
    public const string FF = "FF";
    public const string FR = "FR";
    public const string RR = "RR";
    public const string MR = "MR";
    public const string AWD = "AWD";
}

/// <summary>
/// シリンダーレイアウト
/// </summary>
public class CylinderLayout
{
    [Comment("直列")]
    public const string I = "I";
    [Comment("V型")]
    public const string V = "V";
    [Comment("水平対向")]
    public const string B = "B";
    [Comment("W型")]
    public const string W = "W";
}

/// <summary>
/// バルブ構造
/// </summary>
public class ValveSystem
{
    public const string SV = "SV";
    public const string OHV = "OHV";
    public const string SOHC = "SOHC";
    public const string DOHC = "DOHC";
}

/// <summary>
/// 使用燃料種類
/// </summary>
public class FuelType
{
    [Comment("軽油")]
    public const string DIESEL = "DIESEL";
    [Comment("無鉛レギュラーガソリン")]
    public const string REGULAR = "REGULAR";
    [Comment("無鉛プレミアムガソリン")]
    public const string PREMIUM = "PREMIUM";
    [Comment("LPG")]
    public const string LPG = "LPG";
    [Comment("バイオ燃料")]
    public const string BIO = "BIO";
    [Comment("水素")]
    public const string HYDROGEN = "HYDROGEN";
}

/// <summary>
/// トランスミッション種類
/// </summary>
public class TransmissionType
{
    [Comment("AT")]
    public const string AT = "AT";
    [Comment("DCT")]
    public const string DCT = "DCT";
    [Comment("AMT")]
    public const string AMT = "AMT";
    [Comment("MT")]
    public const string MT = "MT";
    [Comment("CVT")]
    public const string CVT = "CVT";
    [Comment("電気式無段変速機")]
    public const string PG = "PG";
}