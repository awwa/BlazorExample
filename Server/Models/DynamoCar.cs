using Amazon.DynamoDBv2.DataModel;

namespace HogeBlazor.Server.Models;

[DynamoDBTable("Cars")]
public class DynamoCar
{
    [DynamoDBHashKey]
    public string Id { get; set; } = string.Empty;
    [DynamoDBRangeKey]
    public string DataType { get; set; } = string.Empty;
    [DynamoDBGlobalSecondaryIndexHashKey]
    public string StringValue { get; set; } = string.Empty;
    public string[] stringSet { get; set; } = Array.Empty<string>();
    [DynamoDBGlobalSecondaryIndexHashKey]
    public long Number { get; set; } = 0;

    public long[] NumberSet { get; set; } = Array.Empty<long>();
}
