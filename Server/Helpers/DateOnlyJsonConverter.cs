using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// DateOnlyを"YYYY-MM-DD"形式に変換するコンバーター
/// https://kevsoft.net/2021/05/22/formatting-dateonly-types-as-iso-8601-in-asp-net-core-responses.html
/// </summary>
public sealed class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.FromDateTime(reader.GetDateTime());
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        var isoDate = value.ToString("O");
        writer.WriteStringValue(isoDate);
    }
}