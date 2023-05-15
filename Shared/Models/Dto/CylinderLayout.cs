namespace HogeBlazor.Shared.Models.Dto;

/// <summary>
/// シリンダーレイアウト
/// </summary>
public class CylinderLayout
{
    public static readonly string I = "I";
    public static readonly string V = "V";
    public static readonly string B = "B";
    public static readonly string W = "W";

    public string Value { get; } = default!;
    public string Label { get; } = default!;

    public CylinderLayout(string value)
    {
        Value = value;
        Label = GetLabel(value);
    }

    public static string GetLabel(string? value)
    {
        if (value == I) return "直列";
        if (value == V) return "V型";
        if (value == B) return "水平対向";
        if (value == W) return "W型";
        return "不明";
    }

    public static List<CylinderLayout> CreateItems()
    {
        return new List<CylinderLayout>()
        {
            new CylinderLayout(I),
            new CylinderLayout(V),
            new CylinderLayout(B),
            new CylinderLayout(W),
        };
    }
}
