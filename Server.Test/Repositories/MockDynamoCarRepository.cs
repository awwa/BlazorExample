
using System.Collections.Generic;
using System.Threading.Tasks;
using HogeBlazor.Server.Repositories;
using HogeBlazor.Shared.Models.Dto;
using static HogeBlazor.Server.Repositories.CarRepository;

namespace HogeBlazor.Server.Test.Repositories;

public class MockDynamoCarRepository : ICarRepository
{
    Task<CarDto> ICarRepository.GetAsync(string id)
    {
        var ret = new CarDto("car_1")
                .Set("MakerName", "マツダ")
                .Set("ModelName", "CX-5")
                .Set("GradeName", "25S Proactive")
                .Set("BodyType", BodyType.SUV)
                .Set("Price", 3140500)
                .Set("Url", "https://www.mazda.co.jp/cars/cx-5/")
                .Set("ImageUrl", "https://upload.wikimedia.org/wikipedia/commons/8/85/2017_Mazda_CX-5_%28KF%29_Maxx_2WD_wagon_%282018-11-02%29_01.jpg");
        return Task.FromResult<CarDto>(ret);
    }

    Task<Dictionary<string, CarDto>> ICarRepository.QueryAsync(CarQuery query)
    {
        var ret = new Dictionary<string, CarDto>();
        ret.Add(
            "car_1",
            new CarDto("car_1")
                .Set("MakerName", "マツダ")
                .Set("ModelName", "CX-5")
                .Set("GradeName", "25S Proactive")
                .Set("BodyType", BodyType.SUV)
                .Set("Price", 3140500)
                .Set("Url", "https://www.mazda.co.jp/cars/cx-5/")
                .Set("ImageUrl", "https://upload.wikimedia.org/wikipedia/commons/8/85/2017_Mazda_CX-5_%28KF%29_Maxx_2WD_wagon_%282018-11-02%29_01.jpg")
        );
        return Task.FromResult<Dictionary<string, CarDto>>(ret);
    }

    Task<HashSet<string>> ICarRepository.GetAttributeValuesAsync(string dataType)
    {
        return Task.FromResult<HashSet<string>>(new HashSet<string>
        {
            "マツダ",
            "トヨタ",
            "日産",
        });
    }

    Task ICarRepository.PutAsync(CarDto car)
    {
        throw new System.NotImplementedException();
    }

    Task ICarRepository.DeleteAsync(string id)
    {
        throw new System.NotImplementedException();
    }

    Task ICarRepository.CreateTableAsync()
    {
        throw new System.NotImplementedException();
    }

    Task ICarRepository.DeleteTableAsync()
    {
        throw new System.NotImplementedException();
    }

    Task ICarRepository.DescribeTableAsync()
    {
        throw new System.NotImplementedException();
    }
}