namespace HogeBlazor.Shared.Models.Dto;

/// <summary>
/// 使用燃料種類
/// </summary>
public class FuelType
{
    // [Comment("軽油")]
    public static readonly string DIESEL = "DIESEL";
    // [Comment("無鉛レギュラーガソリン")]
    public static readonly string REGULAR = "REGULAR";
    // [Comment("無鉛プレミアムガソリン")]
    public static readonly string PREMIUM = "PREMIUM";
    // [Comment("LPG")]
    public static readonly string LPG = "LPG";
    // [Comment("バイオ燃料")]
    public static readonly string BIO = "BIO";
    // [Comment("水素")]
    public static readonly string HYDROGEN = "HYDROGEN";

    public string Value { get; } = default!;
    public string Label { get; } = default!;

    public FuelType(string value)
    {
        Value = value;
        Label = GetLabel(value);
    }

    public static string GetLabel(string? value)
    {
        if (value == DIESEL) return "軽油";
        if (value == REGULAR) return "無鉛レギュラーガソリン";
        if (value == PREMIUM) return "無鉛プレミアムガソリン";
        if (value == LPG) return "LPG";
        if (value == BIO) return "バイオ燃料";
        if (value == HYDROGEN) return "水素";
        return "不明";
    }

    public static List<FuelType> CreateItems()
    {
        return new List<FuelType>()
        {
            new FuelType(DIESEL),
            new FuelType(REGULAR),
            new FuelType(PREMIUM),
            new FuelType(LPG),
            new FuelType(BIO),
            new FuelType(HYDROGEN),
        };
    }
}
