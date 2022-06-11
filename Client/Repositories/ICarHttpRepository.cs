
using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Repositories;

public interface ICarHttpRepository
{
    Task<Car> GetCar(int id);
    Task<List<Car>> GetCars();
}