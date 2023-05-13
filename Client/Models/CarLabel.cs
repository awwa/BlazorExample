namespace HogeBlazor.Client.Models;

public class CarLabel
{
    public static string BasicInfo = "基本情報";
    public static string Id = "ID";
    public static string MakerName = "メーカー名";
    public static string ModelName = "モデル名";
    public static string Url = "URL";
    public static string ImageUrl = "イメージURL";
    public static string BodyType = "ボディタイプ";
    public static string DriveSystem = "駆動方式";
    public static string PowerTrain = "パワートレイン";
    public static string ModelCode = "型式";
    public static string GradeName = "グレード";
    public static string Price = "小売価格（税込/円）";
    public static string ModelChange = "モデルチェンジ";
    public static string Full = "フル";
    public static string Last = "最終";
    public static string Steering = "ステアリング形式";
    public static string Suspension = "サスペンション形式";
    public static string Front = "前";
    public static string Rear = "後";
    public static string Break = "ブレーキ形式";
    public static string FuelEfficiency = "燃費向上対策";
    public static string Performance = "性能";
    public static string MinTurningRadius = "最小回転半径(m)";
    public static string Fcr = "燃料消費率(km/L)";
    public static string Wltc = "WLTCモード";
    public static string WltcL = "市街地モード(WLTC-L)";
    public static string WltcM = "郊外モード(WLTC-M)";
    public static string WltcH = "高速道路モード(WPTC-H)";
    public static string Jc08 = "JC08モード";
    public static string Ecr = "交流電力消費率(Wh/km)";
    public static string MpcWltc = "一充電走行距離WLTCモード(km)";
    public static string MpcJc08 = "一充電走行距離JC08モード(km)";
    public static string Engine = "エンジン";
    public static string Code = "型式";
    public static string Type = "種類";
    public static string CylinderNum = "気筒数";
    public static string CylinderLayout = "シリンダーレイアウト";
    public static string ValveSystem = "バルブ構造";
    public static string Displacement = "総排気量(L)";
    public static string Bore = "ボア(mm)";
    public static string Stroke = "ストローク(mm)";
    public static string CompressionRatio = "圧縮比";
    public static string MaxOutput = "最高出力(kW)";
    public static string MaxOutputRpm = "最高出力回転数";
    public static string Lower = "低";
    public static string Upper = "高";
    public static string MaxTorque = "最大トルク(Nm)";
    public static string MaxTorqueRpm = "最大トルク回転数(rpm)";
    public static string FuelSystem = "燃料供給装置";
    public static string FuelType = "使用燃料種類";
    public static string FuelTankCap = "燃料タンク容量(L)";
    public static string MotorX = "モーター1";
    public static string Purpose = "用途";
    public static string RatedOutput = "定格出力(kW)";
    public static string MotorY = "モーター2";
    public static string Battery = "バッテリー";
    public static string Quantity = "個数";
    public static string Voltage = "電圧(V)";
    public static string Capacity = "容量(Ah)";
    public static string Tire = "タイヤ";
    public static string SectionWidth = "幅(mm)";
    public static string AspectRatio = "扁平率(%)";
    public static string WheelDiameter = "ホイール径(インチ)";
    public static string Transmission = "トランスミッション";
    public static string GearRatios = "変速比";
    public static string ReductionRatio = "減速比";
    public static string OuterBody = "外寸";
    public static string OuterBody_Length = "全長";
    public static string OuterBody_Width = "全幅";
    public static string OuterBody_Height = "全高";
    public static string WheelBase = "ホイールベース";
    public static string Tread = "トレッド";
    public static string MinRoadClearance = "最低地上高";
    public static string InteriorBody = "内寸";
    public static string InteriorBody_Length = "室内長";
    public static string InteriorBody_Width = "室内幅";
    public static string InteriorBody_Height = "室内高";
    public static string OtherBody = "その他";
    public static string Weight = "車両重量(kg)";
    public static string DoorNum = "ドア数";
    public static string LuggageCap = "ラゲッジルーム容量(L)";
    public static string RidingCap = "乗車定員(人)";


}

/// <summary>
/// ボディタイプ
/// </summary>
public class BodyType
{
    // [DisplayName("セダン")]
    private const string SEDAN = "SEDAN";
    // [Comment("ハッチバック")]
    public const string HATCHBACK = "HATCHBACK";
    // [Comment("クロスカントリー")]
    public const string CROSS_COUNTRY = "CROSS_COUNTRY";
    // [Comment("軽自動車")]
    public const string K = "K";
    // [Comment("クーペ")]
    public const string COUPE = "COUPE";
    // [Comment("ステーションワゴン")]
    public const string STATION_WAGON = "STATION_WAGON";
    // [Comment("SUV")]
    public const string SUV = "SUV";
    // [Comment("ワンボックス")]
    public const string ONEBOX = "ONEBOX";
    // [Comment("軽オープン")]
    public const string K_OPEN = "K_OPEN";
    // [Comment("軽ワンボックス")]
    public const string K_ONEBOX = "K_ONEBOX";
    // [Comment("オープン")]
    public const string OPEN = "OPEN";
    // [Comment("ピックアップトラック")]
    public const string PICKUP_TRUCK = "PICKUP_TRUCK";

    public static string Label(string? bodyType)
    {
        return bodyType switch
        {
            SEDAN => "セダン",
            HATCHBACK => "ハッチバック",
            CROSS_COUNTRY => "クロスカントリー",
            K => "軽自動車",
            COUPE => "クーペ",
            STATION_WAGON => "ステーションワゴン",
            SUV => "SUV",
            ONEBOX => "ワンボックス",
            K_OPEN => "軽オープン",
            K_ONEBOX => "軽ワンボックス",
            OPEN => "オープン",
            PICKUP_TRUCK => "ピックアップトラック",
            _ => "不明",
        };
    }
}

public class PowerTrain
{
    // [Comment("エンジン")]
    public const string ICE = "ICE";
    // [Comment("ストロングハイブリッド")]
    public const string StrHV = "StrHV";
    // [Comment("マイルドハイブリッド")]
    public const string MldHV = "MldHV";
    // [Comment("シリーズハイブリッド")]
    public const string SerHV = "SerHV";
    // [Comment("プラグインハイブリッド")]
    public const string PHEV = "PHEV";
    // [Comment("バッテリーEV")]
    public const string BEV = "BEV";
    // [Comment("レンジエクステンダーEV")]
    public const string RexEV = "RexEV";
    // [Comment("燃料電池車")]
    public const string FCEV = "FCEV";

    public static string Label(string? powerTrain)
    {
        return powerTrain switch
        {
            ICE => "エンジン",
            StrHV => "ストロングハイブリッド",
            MldHV => "マイルドハイブリッド",
            SerHV => "シリーズハイブリッド",
            PHEV => "プラグインハイブリッド",
            BEV => "バッテリーEV",
            RexEV => "レンジエクステンダーEV",
            FCEV => "燃料電池車",
            _ => "不明",
        };
    }
}

/// <summary>
/// シリンダーレイアウト
/// </summary>
public class CylinderLayout
{
    // [Comment("直列")]
    public const string I = "I";
    // [Comment("V型")]
    public const string V = "V";
    // [Comment("水平対向")]
    public const string B = "B";
    // [Comment("W型")]
    public const string W = "W";

    public static string Label(string? cylinderLayout)
    {
        return cylinderLayout switch
        {
            I => "直列",
            V => "V型",
            B => "水平対向",
            W => "W型",
            _ => "不明",
        };
    }
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

    public static string Label(string? valveSystem)
    {
        return valveSystem switch
        {
            SV => "SV",
            OHV => "OHV",
            SOHC => "SOHC",
            DOHC => "DOHC",
            _ => "不明",
        };
    }
}

/// <summary>
/// 使用燃料種類
/// </summary>
public class FuelType
{
    // [Comment("軽油")]
    public const string DIESEL = "DIESEL";
    // [Comment("無鉛レギュラーガソリン")]
    public const string REGULAR = "REGULAR";
    // [Comment("無鉛プレミアムガソリン")]
    public const string PREMIUM = "PREMIUM";
    // [Comment("LPG")]
    public const string LPG = "LPG";
    // [Comment("バイオ燃料")]
    public const string BIO = "BIO";
    // [Comment("水素")]
    public const string HYDROGEN = "HYDROGEN";

    public static string Label(string? fuelType)
    {
        return fuelType switch
        {
            DIESEL => "軽油",
            REGULAR => "無鉛レギュラーガソリン",
            PREMIUM => "無鉛プレミアムガソリン",
            LPG => "LPG",
            BIO => "バイオ燃料",
            HYDROGEN => "水素",
            _ => "不明",
        };
    }
}

/// <summary>
/// トランスミッション種類
/// </summary>
public class TransmissionType
{
    // [Comment("AT")]
    public const string AT = "AT";
    // [Comment("DCT")]
    public const string DCT = "DCT";
    // [Comment("AMT")]
    public const string AMT = "AMT";
    // [Comment("MT")]
    public const string MT = "MT";
    // [Comment("CVT")]
    public const string CVT = "CVT";
    // [Comment("電気式無段変速機")]
    public const string PG = "PG";

    public static string Label(string? transmissionType)
    {
        return transmissionType switch
        {
            AT => "AT",
            DCT => "DCT",
            AMT => "AMT",
            MT => "MT",
            CVT => "CVT",
            PG => "電気式無段変速機",
            _ => "不明",
        };
    }
}