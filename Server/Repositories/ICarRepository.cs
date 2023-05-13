using HogeBlazor.Shared.Models.Dto;
using static HogeBlazor.Server.Repositories.CarRepository;

namespace HogeBlazor.Server.Repositories;

public interface ICarRepository
{
    Task CreateTableAsync();
    Task DeleteTableAsync();
    Task DescribeTableAsync();
    Task<CarDto> GetAsync(string id);
    Task<Dictionary<string, CarDto>> QueryAsync(CarQuery query);
    Task<HashSet<string>> GetAttributeValuesAsync(string dataType);
    Task PutAsync(CarDto car);
    Task DeleteAsync(string id);
}
