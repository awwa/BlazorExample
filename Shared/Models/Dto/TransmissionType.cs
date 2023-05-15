namespace HogeBlazor.Shared.Models.Dto;

/// <summary>
/// トランスミッション種類
/// </summary>
public class TransmissionType
{
    public static readonly string AT = "AT";
    public static readonly string DCT = "DCT";
    public static readonly string AMT = "AMT";
    public static readonly string MT = "MT";
    public static readonly string CVT = "CVT";
    public static readonly string PG = "PG";

    public string Value { get; } = default!;
    public string Label { get; } = default!;

    public TransmissionType(string value)
    {
        Value = value;
        Label = GetLabel(value);
    }

    public static string GetLabel(string? value)
    {
        if (value == AT) return "AT";
        if (value == DCT) return "DCT";
        if (value == AMT) return "AMT";
        if (value == MT) return "MT";
        if (value == CVT) return "CVT";
        if (value == PG) return "電気式無段変速機";
        return "不明";
    }

    public static List<TransmissionType> CreateItems()
    {
        return new List<TransmissionType>()
        {
            new TransmissionType(AT),
            new TransmissionType(DCT),
            new TransmissionType(AMT),
            new TransmissionType(MT),
            new TransmissionType(CVT),
            new TransmissionType(PG),
        };
    }
}