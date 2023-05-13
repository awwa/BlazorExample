using HogeBlazor.Shared.Models.Dto;

namespace HogeBlazor.Client.Repositories;

public class CarHttpRepository : ICarHttpRepository
{
    private readonly HttpClient _client;

    public CarHttpRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<IDictionary<string, CarDto>> QueryCarsAsync(CarQuery query)
    {
        var c = new HogeBlazor.Client.Helpers.CarsClient("", _client);
        IDictionary<string, HogeBlazor.Client.Helpers.CarDto> clientDtos = await c.QueryCarsAsync(
            query.MakerNames,
            query.Price.Lower,
            query.Price.Upper,
            query.PowerTrain,
            query.DriveSystem,
            query.BodyType,
            query.BodyLength.Lower,
            query.BodyLength.Upper,
            query.BodyWidth.Lower,
            query.BodyWidth.Upper,
            query.BodyHeight.Lower,
            query.BodyHeight.Upper,
            query.Weight.Lower,
            query.Weight.Upper,
            query.DoorNum.Lower,
            query.DoorNum.Upper,
            query.RidingCap.Lower,
            query.RidingCap.Upper,
            query.FcrWltc.Lower,
            query.FcrWltc.Upper,
            query.FcrJc08.Lower,
            query.FcrJc08.Upper,
            query.MpcWltc.Lower,
            query.MpcWltc.Upper,
            query.EcrWltc.Lower,
            query.EcrWltc.Upper,
            query.EcrJc08.Lower,
            query.EcrJc08.Upper,
            query.MpcJc08.Lower,
            query.MpcJc08.Upper,
            query.FuelType);
        return clientDtos.ToDictionary(x => x.Key, x => convertToCarDto(x.Value));
    }

    public async Task<CarDto> GetCarAsync(string id)
    {
        var c = new HogeBlazor.Client.Helpers.CarsClient("", _client);
        HogeBlazor.Client.Helpers.CarDto clientDto = await c.GetCarAsync(id);
        return convertToCarDto(clientDto);
    }

    public async Task<IEnumerable<string>> GetCarAttributeValuesAsync(string dataType)
    {
        var c = new HogeBlazor.Client.Helpers.CarsClient("", _client);
        return await c.GetCarAttributeValuesAsync(dataType);
    }

    private CarDto convertToCarDto(HogeBlazor.Client.Helpers.CarDto clientDto)
    {
        return new CarDto(clientDto.Id)
        {
            MakerName = clientDto.MakerName,
            ModelName = clientDto.ModelName,
            Url = clientDto.Url,
            ImageUrl = clientDto.ImageUrl,
            BodyType = clientDto.BodyType,
            DriveSystem = clientDto.DriveSystem,
            PowerTrain = clientDto.PowerTrain,
            ModelCode = clientDto.ModelCode,
            GradeName = clientDto.GradeName,
            Price = clientDto.Price,
            ModelChange = new ModelChange()
            {
                Full = clientDto.ModelChange.Full,
                Last = clientDto.ModelChange.Last,
            },
            Steering = clientDto.Steering,
            Suspension = new Suspension()
            {
                Front = clientDto.Suspension.Front,
                Rear = clientDto.Suspension.Rear,
            },
            Break = new Break()
            {
                Front = clientDto.Break.Front,
                Rear = clientDto.Break.Rear,
            },
            FuelEfficiency = clientDto.FuelEfficiency.ToArray<string>(),
            MinTurningRadius = clientDto.MinTurningRadius,
            Fcr = new Fcr
            {
                Wltc = clientDto.Fcr.Wltc,
                WltcL = clientDto.Fcr.WltcL,
                WltcM = clientDto.Fcr.WltcM,
                WltcH = clientDto.Fcr.WltcH,
                WltcExH = clientDto.Fcr.WltcExH,
                Jc08 = clientDto.Fcr.Jc08,
            },
            Ecr = new Ecr
            {
                Wltc = clientDto.Ecr.Wltc,
                WltcL = clientDto.Ecr.WltcL,
                WltcM = clientDto.Ecr.WltcM,
                WltcH = clientDto.Ecr.WltcH,
                WltcExH = clientDto.Ecr.WltcExH,
                Jc08 = clientDto.Ecr.Jc08,
                MpcWltc = clientDto.Ecr.MpcWltc,
                MpcJc08 = clientDto.Ecr.MpcJc08,
            },
            Engine = new Engine
            {
                Code = clientDto.Engine.Code,
                Type = clientDto.Engine.Type,
                CylinderNum = clientDto.Engine.CylinderNum,
                CylinderLayout = clientDto.Engine.CylinderLayout,
                ValveSystem = clientDto.Engine.ValveSystem,
                Displacement = clientDto.Engine.Displacement,
                Bore = clientDto.Engine.Bore,
                Stroke = clientDto.Engine.Stroke,
                CompressionRatio = clientDto.Engine.CompressionRatio,
                MaxOutput = clientDto.Engine.MaxOutput,
                MaxOutputRpm = new MaxOutputRpm
                {
                    Lower = clientDto.Engine.MaxOutputRpm.Lower,
                    Upper = clientDto.Engine.MaxOutputRpm.Upper,
                },
                MaxTorque = clientDto.Engine.MaxTorque,
                MaxTorqueRpm = new MaxTorqueRpm
                {
                    Lower = clientDto.Engine.MaxTorqueRpm.Lower,
                    Upper = clientDto.Engine.MaxTorqueRpm.Upper,
                },
                FuelSystem = clientDto.Engine.FuelSystem,
                FuelType = clientDto.Engine.FuelType,
                FuelTankCap = clientDto.Engine.FuelTankCap,
            },
            MotorX = new Motor
            {
                Code = clientDto.MotorX.Code,
                Type = clientDto.MotorX.Type,
                Purpose = clientDto.MotorX.Purpose,
                RatedOutput = clientDto.MotorX.RatedOutput,
                MaxOutput = clientDto.MotorX.MaxOutput,
                MaxOutputRpm = new MaxOutputRpm
                {
                    Lower = clientDto.MotorX.MaxOutputRpm.Lower,
                    Upper = clientDto.MotorX.MaxOutputRpm.Upper,
                },
                MaxTorque = clientDto.MotorX.MaxTorque,
                MaxTorqueRpm = new MaxTorqueRpm
                {
                    Lower = clientDto.MotorX.MaxTorqueRpm.Lower,
                    Upper = clientDto.MotorX.MaxTorqueRpm.Upper,
                },
            },
            MotorY = new Motor
            {
                Code = clientDto.MotorY.Code,
                Type = clientDto.MotorY.Type,
                Purpose = clientDto.MotorY.Purpose,
                RatedOutput = clientDto.MotorY.RatedOutput,
                MaxOutput = clientDto.MotorY.MaxOutput,
                MaxOutputRpm = new MaxOutputRpm
                {
                    Lower = clientDto.MotorY.MaxOutputRpm.Lower,
                    Upper = clientDto.MotorY.MaxOutputRpm.Upper,
                },
                MaxTorque = clientDto.MotorY.MaxTorque,
                MaxTorqueRpm = new MaxTorqueRpm
                {
                    Lower = clientDto.MotorY.MaxTorqueRpm.Lower,
                    Upper = clientDto.MotorY.MaxTorqueRpm.Upper,
                },
            },
            Battery = new Battery
            {
                Type = clientDto.Battery.Type,
                Quantity = clientDto.Battery.Quantity,
                Voltage = clientDto.Battery.Voltage,
                Capacity = clientDto.Battery.Capacity,
            },
            Tire = new Tire
            {
                SectionWidth = new SectionWidth
                {
                    Front = clientDto.Tire.SectionWidth.Front,
                    Rear = clientDto.Tire.SectionWidth.Rear,
                },
                AspectRatio = new AspectRatio
                {
                    Front = clientDto.Tire.AspectRatio.Front,
                    Rear = clientDto.Tire.AspectRatio.Rear,
                },
                WheelDiameter = new WheelDiameter
                {
                    Front = clientDto.Tire.WheelDiameter.Front,
                    Rear = clientDto.Tire.WheelDiameter.Rear,
                },
            },
            Transmission = new Transmission
            {
                Type = clientDto.Transmission.Type,
                GearRatio = new GearRatio
                {
                    Front = clientDto.Transmission.GearRatio.Front.ToArray<float>(),
                    Rear = clientDto.Transmission.GearRatio.Rear,
                },
                ReductionRatio = new ReductionRatio
                {
                    Front = clientDto.Transmission.ReductionRatio.Front,
                    Rear = clientDto.Transmission.ReductionRatio.Rear,
                },
            },
            OuterBody = new OuterBody
            {
                Length = clientDto.OuterBody.Length,
                Width = clientDto.OuterBody.Width,
                Height = clientDto.OuterBody.Height,
                WheelBase = clientDto.OuterBody.WheelBase,
                Tread = new Tread
                {
                    Front = clientDto.OuterBody.Tread.Front,
                    Rear = clientDto.OuterBody.Tread.Rear,
                },
                MinRoadClearance = clientDto.OuterBody.MinRoadClearance,
            },
            InteriorBody = new InteriorBody
            {
                Length = clientDto.InteriorBody.Length,
                Width = clientDto.InteriorBody.Width,
                Height = clientDto.InteriorBody.Height,
            },
            OtherBody = new OtherBody
            {
                Weight = clientDto.OtherBody.Weight,
                DoorNum = clientDto.OtherBody.DoorNum,
                LuggageCap = clientDto.OtherBody.LuggageCap,
                RidingCap = clientDto.OtherBody.RidingCap,
            },
        };
    }
}