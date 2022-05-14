using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using static HogeBlazor.Server.Repositories.CarRepository;

namespace HogeBlazor.Server.Repositories;

public interface ICarRepository
{
    Task<Car?> GetCar(int id);
    Task<List<Car>> GetCars(CarParameters p);

    // Task CreateCar(Car car);
    // Task UpdateCar(Car car);
    // Task DeleteCar(Car car);
}
