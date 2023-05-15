namespace HogeBlazor.Shared.Models.Dto;

/// <summary>
/// 駆動方式
/// </summary>
public class DriveSystem
{
    private static readonly string FF = "FF";
    public static readonly string FR = "FR";
    public static readonly string RR = "RR";
    public static readonly string MR = "MR";
    public static readonly string AWD = "AWD";

    public string Value { get; } = default!;
    public string Label { get; } = default!;

    public DriveSystem(string value)
    {
        Value = value;
        Label = GetLabel(value);
    }

    public static string GetLabel(string? value)
    {
        if (value == FF) return "FF";
        if (value == FR) return "FR";
        if (value == RR) return "RR";
        if (value == MR) return "MR";
        if (value == AWD) return "AWD";
        return "不明";
    }

    public static List<DriveSystem> CreateItems()
    {
        return new List<DriveSystem>()
        {
            new DriveSystem(FF),
            new DriveSystem(FR),
            new DriveSystem(RR),
            new DriveSystem(MR),
            new DriveSystem(AWD),
        };
    }
}

