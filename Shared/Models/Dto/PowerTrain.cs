namespace HogeBlazor.Shared.Models.Dto;

public class PowerTrain
{
    public static readonly string ICE = "ICE";
    public static readonly string StrHV = "StrHV";
    public static readonly string MldHV = "MldHV";
    public static readonly string SerHV = "SerHV";
    public static readonly string PHEV = "PHEV";
    public static readonly string BEV = "BEV";
    public static readonly string RexEV = "RexEV";
    public static readonly string FCEV = "FCEV";

    public string Value { get; } = default!;
    public string Label { get; } = default!;

    public PowerTrain(string value)
    {
        Value = value;
        Label = GetLabel(value);
    }

    public static string GetLabel(string? value)
    {
        if (value == ICE) return "エンジン";
        if (value == StrHV) return "ストロングハイブリッド";
        if (value == MldHV) return "マイルドハイブリッド";
        if (value == SerHV) return "シリーズハイブリッド";
        if (value == PHEV) return "プラグインハイブリッド";
        if (value == BEV) return "バッテリーEV";
        if (value == RexEV) return "レンジエクステンダーEV";
        if (value == FCEV) return "燃料電池車";
        return "不明";
    }

    public static List<PowerTrain> CreateItems()
    {
        return new List<PowerTrain>()
        {
            new PowerTrain(ICE),
            new PowerTrain(StrHV),
            new PowerTrain(MldHV),
            new PowerTrain(SerHV),
            new PowerTrain(PHEV),
            new PowerTrain(BEV),
            new PowerTrain(RexEV),
            new PowerTrain(FCEV),
        };
    }
}
