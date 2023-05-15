namespace HogeBlazor.Shared.Models.Dto;

/// <summary>
/// バルブ構造
/// </summary>
public class ValveSystem
{
    public static readonly string SV = "SV";
    public static readonly string OHV = "OHV";
    public static readonly string SOHC = "SOHC";
    public static readonly string DOHC = "DOHC";

    public string Value { get; } = default!;
    public string Label { get; } = default!;

    public ValveSystem(string value)
    {
        Value = value;
        Label = GetLabel(value);
    }
    public static string GetLabel(string? value)
    {
        if (value == SV) return "SV";
        if (value == OHV) return "OHV";
        if (value == SOHC) return "SOHC";
        if (value == DOHC) return "DOHC";
        return "不明";
    }

    public static List<ValveSystem> CreateItems()
    {
        return new List<ValveSystem>()
        {
            new ValveSystem(SV),
            new ValveSystem(OHV),
            new ValveSystem(SOHC),
            new ValveSystem(DOHC),
        };
    }
}
