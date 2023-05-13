using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using HogeBlazor.Shared.Models.Dto;
using System.Collections.ObjectModel;
using static HogeBlazor.Shared.Models.Dto.CarQuery;

namespace HogeBlazor.Server.Repositories;

public class CarRepository : ICarRepository
{
    private const string TABLE_NAME = "Cars";
    private const string INDEX_NAME_S = "gsi-s";
    private const string INDEX_NAME_N = "gsi-n";
    private const string ID = "Id";
    private const string DT = "DataType";
    private const string SV = "StringValue";
    private const string NV = "NumValue";
    private const string LV = "ListValue";

    static readonly ReadOnlyCollection<string> PROPS = Array.AsReadOnly<string>(new string[]
    {
        // SV as string
        "MakerName",
        "ModelName",
        "Url",
        "ImageUrl",
        "BodyType",
        "DriveSystem",
        "PowerTrain",
        "ModelCode",
        "GradeName",
        "ModelChange_Full",
        "ModelChange_Last",
        "Steering",
        "Suspension_Front",
        "Suspension_Rear",
        "Break_Front",
        "Break_Rear",
        "Engine_Code",
        "Engine_Type",
        "Engine_CylinderLayout",
        "Engine_ValveSystem",
        "Engine_FuelSystem",
        "Engine_FuelType",
        "Battery_Type",
        "Transmission_Type",
        "MotorX_Code",
        "MotorX_Type",
        "MotorX_Purpose",
        "MotorY_Code",
        "MotorY_Type",
        "MotorY_Purpose",
        // NV as int
        "Price",
        "Engine_CylinderNum",
        "Engine_MaxOutputRpm_Lower",
        "Engine_MaxOutputRpm_Upper",
        "Engine_MaxTorqueRpm_Lower",
        "Engine_MaxTorqueRpm_Upper",
        "Engine_FuelTankCap",
        "Battery_Quantity",
        "Tire_SectionWidth_Front",
        "Tire_SectionWidth_Rear",
        "Tire_AspectRatio_Front",
        "Tire_AspectRatio_Rear",
        "Tire_WheelDiameter_Front",
        "Tire_WheelDiameter_Rear",
        "OuterBody_Length",
        "OuterBody_Width",
        "OuterBody_Height",
        "OuterBody_WheelBase",
        "OuterBody_Tread_Front",
        "OuterBody_Tread_Rear",
        "OuterBody_MinRoadClearance",
        "InteriorBody_Length",
        "InteriorBody_Width",
        "InteriorBody_Height",
        "OtherBody_Weight",
        "OtherBody_DoorNum",
        "OtherBody_LuggageCap",
        "OtherBody_RidingCap",
        "MotorX_MaxOutputRpm_Lower",
        "MotorX_MaxOutputRpm_Upper",
        "MotorX_MaxTorqueRpm_Lower",
        "MotorX_MaxTorqueRpm_Upper",
        "MotorY_MaxOutputRpm_Lower",
        "MotorY_MaxOutputRpm_Upper",
        "MotorY_MaxTorqueRpm_Lower",
        "MotorY_MaxTorqueRpm_Upper",
        // NV as float
        "MinTurningRadius",
        "Fcr_Wltc",
        "Fcr_WltcL",
        "Fcr_WltcM",
        "Fcr_WltcH",
        "Fcr_WltcExH",
        "Fcr_Jc08",
        "Ecr_Wltc",
        "Ecr_WltcL",
        "Ecr_WltcM",
        "Ecr_WltcH",
        "Ecr_WltcExH",
        "Ecr_MpcWltc",
        "Ecr_Jc08",
        "Ecr_MpcJc08",
        "Engine_MaxOutput",
        "Engine_MaxTorque",
        "Engine_Displacement",
        "Engine_Bore",
        "Engine_Stroke",
        "Engine_CompressionRatio",
        "Battery_Voltage",
        "Battery_Capacity",
        "Transmission_GearRatio_Rear",
        "Transmission_ReductionRatio_Front",
        "Transmission_ReductionRatio_Rear",
        "MotorX_RatedOutput",
        "MotorX_MaxOutput",
        "MotorX_MaxTorque",
        "MotorY_RatedOutput",
        "MotorY_MaxOutput",
        "MotorY_MaxTorque",
        // L as StringList
        "FuelEfficiency",
        // L as NumberList
        "Transmission_GearRatio_Front",
    });

    // private DynamoDBContext _context;
    private AmazonDynamoDBClient _client;

    public CarRepository()
    {
        var clientConfig = new AmazonDynamoDBConfig
        {
            ServiceURL = "http://localhost:8000",
        };
        _client = new AmazonDynamoDBClient(clientConfig);
        // _context = new DynamoDBContext(_client);
    }

    public async Task CreateTableAsync()
    {
        await _client.CreateTableAsync(new CreateTableRequest
        {
            TableName = TABLE_NAME,
            AttributeDefinitions = new List<AttributeDefinition>()
            {
                new AttributeDefinition
                {
                    AttributeName = ID,
                    AttributeType = ScalarAttributeType.S,
                },
                new AttributeDefinition
                {
                    AttributeName = DT,
                    AttributeType = ScalarAttributeType.S,
                },
                new AttributeDefinition
                {
                    AttributeName = SV,
                    AttributeType = ScalarAttributeType.S,
                },
                new AttributeDefinition
                {
                    AttributeName = NV,
                    AttributeType = ScalarAttributeType.N,
                },
            },
            ProvisionedThroughput = new ProvisionedThroughput
            {
                ReadCapacityUnits = 1,
                WriteCapacityUnits = 1,
            },

            KeySchema = new List<KeySchemaElement>()
            {
                new KeySchemaElement
                {
                    AttributeName = ID,
                    KeyType = KeyType.HASH,
                },
                new KeySchemaElement
                {
                    AttributeName = DT,
                    KeyType = KeyType.RANGE,
                },
            },
            GlobalSecondaryIndexes = new List<GlobalSecondaryIndex>
            {
                new GlobalSecondaryIndex
                {
                    IndexName = INDEX_NAME_S,
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = DT,
                            KeyType = KeyType.HASH,
                        },
                        new KeySchemaElement
                        {
                            AttributeName = SV,
                            KeyType = KeyType.RANGE,
                        },
                    },
                    Projection = new Projection
                    {
                        ProjectionType = ProjectionType.ALL,
                    },
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 1,
                        WriteCapacityUnits = 1,
                    },
                },
                new GlobalSecondaryIndex
                {
                    IndexName = INDEX_NAME_N,
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = DT,
                            KeyType = KeyType.HASH,
                        },
                        new KeySchemaElement
                        {
                            AttributeName = NV,
                            KeyType = KeyType.RANGE,
                        },
                    },
                    Projection = new Projection
                    {
                        ProjectionType = ProjectionType.ALL,
                    },
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 1,
                        WriteCapacityUnits = 1,
                    },
                },
            },
        });
    }

    public async Task DeleteTableAsync()
    {
        await _client.DeleteTableAsync(TABLE_NAME);
    }

    public async Task DescribeTableAsync()
    {
        var request = new DescribeTableRequest
        {
            TableName = TABLE_NAME,
        };
        var response = await _client.DescribeTableAsync(request);
        foreach (var attr in response.Table.AttributeDefinitions)
        {
            Console.WriteLine($"{attr.AttributeName} {attr.AttributeType}");
        }
    }

    public async Task DeleteAsync(string id)
    {
        var transaction = new TransactWriteItemsRequest();
        foreach (var prop in PROPS)
        {
            transaction.TransactItems.Add(new TransactWriteItem()
            {
                Delete = new Delete
                {
                    TableName = TABLE_NAME,
                    Key = new Dictionary<string, AttributeValue>
                    {
                        { ID, new AttributeValue { S = id } },
                        { DT, new AttributeValue { S = prop } },
                    },
                },
            });
        }
        await _client.TransactWriteItemsAsync(transaction);
    }

    public async Task PutAsync(CarDto car)
    {
        var transaction = new TransactWriteItemsRequest();
        foreach (var prop in PROPS)
        {
            object? value = car.Get(prop);
            if (value != null)
            {
                transaction.TransactItems.Add(createTransactItem(car.Id, prop, value));
            }
        }
        var ret = await _client.TransactWriteItemsAsync(transaction);
    }

    private TransactWriteItem createTransactItem(string id, string dataType, object value)
    {
        var item = new TransactWriteItem();
        var put = new Put
        {
            TableName = TABLE_NAME,
        };
        put.Item = new Dictionary<string, AttributeValue>
        {
            { ID, new AttributeValue { S = id } },
            { DT, new AttributeValue { S = dataType } },
        };
        switch (dataType)
        {
            case "MakerName":
            case "ModelName":
            case "Url":
            case "ImageUrl":
            case "BodyType":
            case "DriveSystem":
            case "PowerTrain":
            case "ModelCode":
            case "GradeName":
            case "ModelChange_Full":
            case "ModelChange_Last":
            case "Steering":
            case "Suspension_Front":
            case "Suspension_Rear":
            case "Break_Front":
            case "Break_Rear":
            case "Engine_Code":
            case "Engine_Type":
            case "Engine_CylinderLayout":
            case "Engine_ValveSystem":
            case "Engine_FuelSystem":
            case "Engine_FuelType":
            case "Battery_Type":
            case "Transmission_Type":
            case "MotorX_Code":
            case "MotorX_Type":
            case "MotorX_Purpose":
            case "MotorY_Code":
            case "MotorY_Type":
            case "MotorY_Purpose":
                put.Item.Add(SV, new AttributeValue { S = value as string });
                break;
            case "Price":
            case "Engine_CylinderNum":
            case "Engine_MaxOutputRpm_Lower":
            case "Engine_MaxOutputRpm_Upper":
            case "Engine_MaxTorqueRpm_Lower":
            case "Engine_MaxTorqueRpm_Upper":
            case "Engine_FuelTankCap":
            case "Battery_Quantity":
            case "Tire_SectionWidth_Front":
            case "Tire_SectionWidth_Rear":
            case "Tire_AspectRatio_Front":
            case "Tire_AspectRatio_Rear":
            case "Tire_WheelDiameter_Front":
            case "Tire_WheelDiameter_Rear":
            case "OuterBody_Length":
            case "OuterBody_Width":
            case "OuterBody_Height":
            case "OuterBody_WheelBase":
            case "OuterBody_Tread_Front":
            case "OuterBody_Tread_Rear":
            case "OuterBody_MinRoadClearance":
            case "InteriorBody_Length":
            case "InteriorBody_Width":
            case "InteriorBody_Height":
            case "OtherBody_Weight":
            case "OtherBody_DoorNum":
            case "OtherBody_LuggageCap":
            case "OtherBody_RidingCap":
            case "MotorX_MaxOutputRpm_Lower":
            case "MotorX_MaxOutputRpm_Upper":
            case "MotorX_MaxTorqueRpm_Lower":
            case "MotorX_MaxTorqueRpm_Upper":
            case "MotorY_MaxOutputRpm_Lower":
            case "MotorY_MaxOutputRpm_Upper":
            case "MotorY_MaxTorqueRpm_Lower":
            case "MotorY_MaxTorqueRpm_Upper":
                put.Item.Add(NV, new AttributeValue { N = ((int)value).ToString() });
                break;
            case "MinTurningRadius":
            case "Fcr_Wltc":
            case "Fcr_WltcL":
            case "Fcr_WltcM":
            case "Fcr_WltcH":
            case "Fcr_WltcExH":
            case "Fcr_Jc08":
            case "Ecr_Wltc":
            case "Ecr_WltcL":
            case "Ecr_WltcM":
            case "Ecr_WltcH":
            case "Ecr_WltcExH":
            case "Ecr_MpcWltc":
            case "Ecr_Jc08":
            case "Ecr_MpcJc08":
            case "Engine_MaxOutput":
            case "Engine_MaxTorque":
            case "Engine_Displacement":
            case "Engine_Bore":
            case "Engine_Stroke":
            case "Engine_CompressionRatio":
            case "Battery_Voltage":
            case "Battery_Capacity":
            case "Transmission_GearRatio_Rear":
            case "Transmission_ReductionRatio_Front":
            case "Transmission_ReductionRatio_Rear":
            case "MotorX_RatedOutput":
            case "MotorX_MaxOutput":
            case "MotorX_MaxTorque":
            case "MotorY_RatedOutput":
            case "MotorY_MaxOutput":
            case "MotorY_MaxTorque":
                put.Item.Add(NV, new AttributeValue { N = ((float)value).ToString() });
                break;
            case "FuelEfficiency":
                if (((string[])value).Length == 0) break;
                put.Item.Add(LV, new AttributeValue { L = ((string[])value).Select(v => new AttributeValue { S = v }).ToList<AttributeValue>() });
                break;
            case "Transmission_GearRatio_Front":
                if (((float[])value).Length == 0) break;
                put.Item.Add(LV, new AttributeValue { L = ((float[])value).Select(v => new AttributeValue { N = v.ToString() }).ToList<AttributeValue>() });
                break;
        }
        item.Put = put;
        return item;
    }

    /// <summary>
    /// IDを指定してCarDtoを取得する
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<CarDto> GetAsync(string id)
    {
        var query = new QueryRequest()
        {
            TableName = TABLE_NAME,
            KeyConditionExpression = $"{ID} = :id",
            ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                {":id", new AttributeValue { S = id }},
            },
        };
        var response = await _client.QueryAsync(query);
        if (response.Items.Count == 0) throw new ArgumentException();
        var dto = new CarDto(id);
        foreach (var item in response.Items)
        {
            switch (item[DT].S)
            {
                case "MakerName":
                case "ModelName":
                case "Url":
                case "ImageUrl":
                case "BodyType":
                case "DriveSystem":
                case "PowerTrain":
                case "ModelCode":
                case "GradeName":
                case "ModelChange_Full":
                case "ModelChange_Last":
                case "Steering":
                case "Suspension_Front":
                case "Suspension_Rear":
                case "Break_Front":
                case "Break_Rear":
                case "Engine_Code":
                case "Engine_Type":
                case "Engine_CylinderLayout":
                case "Engine_ValveSystem":
                case "Engine_FuelSystem":
                case "Engine_FuelType":
                case "Battery_Type":
                case "Transmission_Type":
                case "MotorX_Code":
                case "MotorX_Type":
                case "MotorX_Purpose":
                case "MotorY_Code":
                case "MotorY_Type":
                case "MotorY_Purpose":
                    if (item.ContainsKey(SV))
                    {
                        dto = dto.Set(item[DT].S, item[SV].S);
                    }
                    break;
                case "Price":
                case "Engine_CylinderNum":
                case "Engine_MaxOutputRpm_Lower":
                case "Engine_MaxOutputRpm_Upper":
                case "Engine_MaxTorqueRpm_Lower":
                case "Engine_MaxTorqueRpm_Upper":
                case "Engine_FuelTankCap":
                case "Battery_Quantity":
                case "Tire_SectionWidth_Front":
                case "Tire_SectionWidth_Rear":
                case "Tire_AspectRatio_Front":
                case "Tire_AspectRatio_Rear":
                case "Tire_WheelDiameter_Front":
                case "Tire_WheelDiameter_Rear":
                case "OuterBody_Length":
                case "OuterBody_Width":
                case "OuterBody_Height":
                case "OuterBody_WheelBase":
                case "OuterBody_Tread_Front":
                case "OuterBody_Tread_Rear":
                case "OuterBody_MinRoadClearance":
                case "InteriorBody_Length":
                case "InteriorBody_Width":
                case "InteriorBody_Height":
                case "OtherBody_Weight":
                case "OtherBody_DoorNum":
                case "OtherBody_LuggageCap":
                case "OtherBody_RidingCap":
                case "MotorX_MaxOutputRpm_Lower":
                case "MotorX_MaxOutputRpm_Upper":
                case "MotorX_MaxTorqueRpm_Lower":
                case "MotorX_MaxTorqueRpm_Upper":
                case "MotorY_MaxOutputRpm_Lower":
                case "MotorY_MaxOutputRpm_Upper":
                case "MotorY_MaxTorqueRpm_Lower":
                case "MotorY_MaxTorqueRpm_Upper":
                    if (item.ContainsKey(NV))
                    {
                        dto = dto.Set(item[DT].S, int.Parse(item[NV].N));
                    }
                    break;
                case "MinTurningRadius":
                case "Fcr_Wltc":
                case "Fcr_WltcL":
                case "Fcr_WltcM":
                case "Fcr_WltcH":
                case "Fcr_WltcExH":
                case "Fcr_Jc08":
                case "Ecr_Wltc":
                case "Ecr_WltcL":
                case "Ecr_WltcM":
                case "Ecr_WltcH":
                case "Ecr_WltcExH":
                case "Ecr_MpcWltc":
                case "Ecr_Jc08":
                case "Ecr_MpcJc08":
                case "Engine_MaxOutput":
                case "Engine_MaxTorque":
                case "Engine_Displacement":
                case "Engine_Bore":
                case "Engine_Stroke":
                case "Engine_CompressionRatio":
                case "Battery_Voltage":
                case "Battery_Capacity":
                case "Transmission_GearRatio_Rear":
                case "Transmission_ReductionRatio_Front":
                case "Transmission_ReductionRatio_Rear":
                case "MotorX_RatedOutput":
                case "MotorX_MaxOutput":
                case "MotorX_MaxTorque":
                case "MotorY_RatedOutput":
                case "MotorY_MaxOutput":
                case "MotorY_MaxTorque":
                    if (item.ContainsKey(NV))
                    {
                        dto = dto.Set(item[DT].S, float.Parse(item[NV].N));
                    }
                    break;
                case "FuelEfficiency":
                    if (item.ContainsKey(LV))
                    {
                        dto = dto.Set(item[DT].S, item[LV].L.Select(x => x.S).ToArray<string>());
                    }
                    break;
                case "Transmission_GearRatio_Front":
                    if (item.ContainsKey(LV))
                    {
                        dto = dto.Set(item[DT].S, item[LV].L.Select(x => float.Parse(x.N)).ToArray<float>());
                    }
                    break;
            }
        }
        return dto;
    }

    /// <summary>
    /// 条件を指定してCarDtoの連想配列を取得する
    /// </summary>
    /// <param name="query">クエリ</param>
    /// <returns></returns>
    public async Task<Dictionary<string, CarDto>> QueryAsync(CarQuery query)
    {
        IEnumerable<string> ids = new List<string>();
        foreach (var makerName in query.MakerNames)
        {
            ids = ids.Union(await queryByStringAsync("MakerName", makerName));
        }
        if (query.Price.ShouldQuery())
        {
            var idsByPrice = await queryByRangeAsync("Price", query.Price);
            ids = ids.Intersect<string>(idsByPrice);
        }
        if (!string.IsNullOrEmpty(query.PowerTrain))
        {
            var idsByPowerTrain = await queryByStringAsync("PowerTrain", query.PowerTrain);
            ids = ids.Intersect<string>(idsByPowerTrain);
        }
        if (!string.IsNullOrEmpty(query.DriveSystem))
        {
            var idsByDriveSystem = await queryByStringAsync("DriveSystem", query.DriveSystem);
            ids = ids.Intersect<string>(idsByDriveSystem);
        }
        if (!string.IsNullOrEmpty(query.BodyType))
        {
            var idsByBodyType = await queryByStringAsync("BodyType", query.BodyType);
            ids = ids.Intersect<string>(idsByBodyType);
        }
        if (query.BodyLength.ShouldQuery())
        {
            var idsByBodyLength = await queryByRangeAsync("OuterBody_Length", query.BodyLength);
            ids = ids.Intersect<string>(idsByBodyLength);
        }
        if (query.BodyWidth.ShouldQuery())
        {
            var idsByBodyWidth = await queryByRangeAsync("OuterBody_Width", query.BodyWidth);
            ids = ids.Intersect<string>(idsByBodyWidth);
        }
        if (query.BodyHeight.ShouldQuery())
        {
            var idsByBodyHeight = await queryByRangeAsync("OuterBody_Height", query.BodyHeight);
            ids = ids.Intersect<string>(idsByBodyHeight);
        }
        if (query.Weight.ShouldQuery())
        {
            var idsByWeight = await queryByRangeAsync("OtherBody_Weight", query.Weight);
            ids = ids.Intersect<string>(idsByWeight);
        }
        if (query.DoorNum.ShouldQuery())
        {
            var idsByDoorNum = await queryByRangeAsync("OtherBody_DoorNum", query.DoorNum);
            ids = ids.Intersect<string>(idsByDoorNum);
        }
        if (query.RidingCap.ShouldQuery())
        {
            var idsByRidingCap = await queryByRangeAsync("OtherBody_RidingCap", query.RidingCap);
            ids = ids.Intersect<string>(idsByRidingCap);
        }
        if (query.FcrWltc.ShouldQuery())
        {
            var idsByFcrWltc = await queryByRangeAsync("Fcr_Wltc", query.FcrWltc);
            ids = ids.Intersect<string>(idsByFcrWltc);
        }
        if (query.FcrJc08.ShouldQuery())
        {
            var idsByFcrJc08 = await queryByRangeAsync("Fcr_Jc08", query.FcrJc08);
            ids = ids.Intersect<string>(idsByFcrJc08);
        }
        if (query.MpcWltc.ShouldQuery())
        {
            var idsByMpcWltc = await queryByRangeAsync("Ecr_MpcWltc", query.MpcWltc);
            ids = ids.Intersect<string>(idsByMpcWltc);
        }
        if (query.EcrWltc.ShouldQuery())
        {
            var idsByEcrWltc = await queryByRangeAsync("Ecr_Wltc", query.EcrWltc);
            ids = ids.Intersect<string>(idsByEcrWltc);
        }
        if (query.EcrJc08.ShouldQuery())
        {
            var idsByEcrJc08 = await queryByRangeAsync("Ecr_Jc08", query.EcrJc08);
            ids = ids.Intersect<string>(idsByEcrJc08);
        }
        if (query.MpcJc08.ShouldQuery())
        {
            var idsByMpcJc08 = await queryByRangeAsync("Ecr_MpcJc08", query.MpcJc08);
            ids = ids.Intersect<string>(idsByMpcJc08);
        }
        if (!string.IsNullOrEmpty(query.FuelType))
        {
            var idsByFuelType = await queryByStringAsync("Engine_FuelType", query.FuelType);
            ids = ids.Intersect<string>(idsByFuelType);
        }

        var ret = new Dictionary<string, CarDto>();
        foreach (var id in ids)
        {
            ret.Add(id, await GetAsync(id));
        }
        return ret;
    }

    private async Task<List<string>> queryByStringAsync(string dataType, string value)
    {
        var request = new QueryRequest()
        {
            TableName = TABLE_NAME,
            IndexName = INDEX_NAME_S,
        };
        request.KeyConditions.Add(DT, new Condition
        {
            ComparisonOperator = ComparisonOperator.EQ,
            AttributeValueList = new List<AttributeValue>
                {
                    new AttributeValue { S = dataType }
                }
        });
        var c = new Condition
        {
            ComparisonOperator = ComparisonOperator.EQ,
            AttributeValueList = new List<AttributeValue>(),
        };
        c.AttributeValueList.Add(new AttributeValue { S = value });
        request.KeyConditions.Add(SV, c);
        var response = await _client.QueryAsync(request);
        return response.Items.Select(x => x[ID].S).ToList<string>();
    }

    private async Task<List<string>> queryByRangeAsync(string dataType, NumberRange range)
    {
        var request = new QueryRequest()
        {
            TableName = TABLE_NAME,
            IndexName = INDEX_NAME_N,
        };
        request.KeyConditions.Add(DT, new Condition
        {
            ComparisonOperator = ComparisonOperator.EQ,
            AttributeValueList = new List<AttributeValue>
            {
                new AttributeValue { S = dataType }
            }
        });
        if (range.Lower != null && range.Upper != null)
        {
            request.KeyConditions.Add(NV, new Condition
            {
                ComparisonOperator = ComparisonOperator.BETWEEN,
                AttributeValueList = new List<AttributeValue>
                {
                    new AttributeValue { N = range.Lower.ToString() },
                    new AttributeValue { N = range.Upper.ToString() },
                },
            });
        }
        else if (range.Lower != null)
        {
            request.KeyConditions.Add(NV, new Condition
            {
                ComparisonOperator = ComparisonOperator.GE,
                AttributeValueList = new List<AttributeValue>
                {
                    new AttributeValue { N = range.Lower.ToString() },
                },
            });
        }
        else if (range.Upper != null)
        {
            request.KeyConditions.Add(NV, new Condition
            {
                ComparisonOperator = ComparisonOperator.LE,
                AttributeValueList = new List<AttributeValue>
                {
                    new AttributeValue { N = range.Upper.ToString() },
                },
            });
        }
        var response = await _client.QueryAsync(request);
        return response.Items.Select(x => x[ID].S).ToList<string>();
    }

    /// <summary>
    /// 指定した属性値の一覧を取得する
    /// </summary>
    /// <param name="dataType"></param>
    /// <returns></returns>
    public async Task<HashSet<string>> GetAttributeValuesAsync(string dataType)
    {
        var request = new ScanRequest()
        {
            TableName = TABLE_NAME,
            IndexName = INDEX_NAME_S,
            AttributesToGet = new List<string> { SV },
        };
        request.ScanFilter.Add(DT, new Condition
        {
            ComparisonOperator = ComparisonOperator.EQ,
            AttributeValueList = new List<AttributeValue>
            {
                new AttributeValue { S = dataType }
            }
        });
        var response = await _client.ScanAsync(request);
        return response.Items.Select(x => x[SV].S).ToHashSet<string>();
    }
}