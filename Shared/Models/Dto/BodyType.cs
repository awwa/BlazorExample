namespace HogeBlazor.Shared.Models.Dto;

/// <summary>
/// ボディタイプ
/// </summary>
public class BodyType
{
    private static readonly string SEDAN = "SEDAN";
    public static readonly string HATCHBACK = "HATCHBACK";
    public static readonly string CROSS_COUNTRY = "CROSS_COUNTRY";
    public static readonly string K = "K";
    public static readonly string COUPE = "COUPE";
    public static readonly string STATION_WAGON = "STATION_WAGON";
    public static readonly string SUV = "SUV";
    public static readonly string ONEBOX = "ONEBOX";
    public static readonly string K_OPEN = "K_OPEN";
    public static readonly string K_ONEBOX = "K_ONEBOX";
    public static readonly string OPEN = "OPEN";
    public static readonly string PICKUP_TRUCK = "PICKUP_TRUCK";

    public string Value { get; } = default!;
    public string Label { get; } = default!;

    public BodyType(string value)
    {
        Value = value;
        Label = GetLabel(value);
    }

    public static string GetLabel(string? value)
    {
        if (value == SEDAN) return "セダン";
        if (value == HATCHBACK) return "ハッチバック";
        if (value == CROSS_COUNTRY) return "クロスカントリー";
        if (value == K) return "軽自動車";
        if (value == COUPE) return "クーペ";
        if (value == STATION_WAGON) return "ステーションワゴン";
        if (value == SUV) return "SUV";
        if (value == ONEBOX) return "ワンボックス";
        if (value == K_OPEN) return "軽オープン";
        if (value == K_ONEBOX) return "軽ワンボックス";
        if (value == OPEN) return "オープン";
        if (value == PICKUP_TRUCK) return "ピックアップトラック";
        return "不明";
    }

    public static List<BodyType> CreateItems()
    {
        return new List<BodyType>()
        {
            new BodyType(SEDAN),
            new BodyType(HATCHBACK),
            new BodyType(CROSS_COUNTRY),
            new BodyType(K),
            new BodyType(COUPE),
            new BodyType(STATION_WAGON),
            new BodyType(SUV),
            new BodyType(ONEBOX),
            new BodyType(K_OPEN),
            new BodyType(K_ONEBOX),
            new BodyType(OPEN),
            new BodyType(PICKUP_TRUCK),
        };
    }
}
