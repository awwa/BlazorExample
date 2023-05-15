namespace HogeBlazor.Shared.Models.Dto;

public class CarQuery
{
    /// <summary>
    /// メーカー名(複数指定)
    /// </summary>
    // [Required]
    public List<string> MakerNames { get; set; } = new List<string>();
    /// <summary>
    /// 小売価格(税込/円)
    /// </summary>
    public NumberRange Price { get; set; } = new NumberRange();
    /// <summary>
    /// パワートレイン
    /// </summary>
    public string? PowerTrain { get; set; }
    /// <summary>
    /// 駆動方式
    /// </summary>
    public string? DriveSystem { get; set; }
    /// <summary>
    /// ボディタイプ
    /// </summary>
    public string? BodyType { get; set; }
    /// <summary>
    /// 全長(mm)
    /// </summary>
    public NumberRange BodyLength { get; set; } = new NumberRange();
    /// <summary>
    /// 全幅(mm)
    /// </summary>
    public NumberRange BodyWidth { get; set; } = new NumberRange();
    /// <summary>
    /// 全高(mm)
    /// </summary>
    public NumberRange BodyHeight { get; set; } = new NumberRange();
    /// <summary>
    /// 車両重量(kg)
    /// </summary>
    public NumberRange Weight { get; set; } = new NumberRange();
    /// <summary>
    /// ドア数
    /// </summary>
    public NumberRange DoorNum { get; set; } = new NumberRange();
    /// <summary>
    /// 乗車定員(人)
    /// </summary>
    public NumberRange RidingCap { get; set; } = new NumberRange();
    /// <summary>
    /// 燃料消費率WLTCモード(km/L)
    /// </summary>
    public NumberRange FcrWltc { get; set; } = new NumberRange();
    /// <summary>
    /// 燃料消費率JC08モード(km/L)
    /// </summary>
    public NumberRange FcrJc08 { get; set; } = new NumberRange();
    /// <summary>
    /// 一充電走行距離WLTCモード(km)
    /// </summary>
    public NumberRange MpcWltc { get; set; } = new NumberRange();
    /// <summary>
    /// 交流電力消費率WTLCモード(Wh/km)
    /// </summary>
    public NumberRange EcrWltc { get; set; } = new NumberRange();
    /// <summary>
    /// 交流電力消費率JC08モード(Wh/km)
    /// </summary>
    public NumberRange EcrJc08 { get; set; } = new NumberRange();
    /// <summary>
    /// 一充電走行距離JC08モード(km)
    /// </summary>
    public NumberRange MpcJc08 { get; set; } = new NumberRange();
    /// <summary>
    /// 使用燃料種類
    /// </summary>
    public string? FuelType { get; set; }

    public CarQuery()
    {
    }

    public CarQuery(string[] makerNames)
    {
        MakerNames = makerNames.ToList<string>();
    }

    public class NumberRange
    {
        public int? Lower { get; set; }
        public int? Upper { get; set; }

        public bool ShouldQuery()
        {
            return Lower != null || Upper != null;
        }
    }
}