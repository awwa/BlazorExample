
using HogeBlazor.Shared.Models.Dto;

namespace HogeBlazor.Client.Repositories;

public interface ICarHttpRepository
{
    Task<IDictionary<string, CarDto>> QueryCarsAsync(CarQuery query);
    Task<CarDto> GetCarAsync(string id);
    Task<IEnumerable<string>> GetCarAttributeValuesAsync(string dataType);
}