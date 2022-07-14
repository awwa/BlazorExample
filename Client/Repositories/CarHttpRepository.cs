
using HogeBlazor.Client.Helpers;

namespace HogeBlazor.Client.Repositories;

public class CarHttpRepository : ICarHttpRepository
{
    private readonly HttpClient _client;

    public CarHttpRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<Car>> GetCars()
    {
        var c = new CarsClient("", _client);
        var cars = (List<Car>)await c.GetCarsAsync(null, null, null, "", "", "", null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "");
        return cars;
    }

    public async Task<Car> GetCar(int id)
    {
        var c = new CarsClient("", _client);
        var car = await c.GetAsync(id);
        return car;
    }

    // public async Task<List<Car>> GetCars()
    // {
    //     var c = new CarsClient("", _client);
    //     var hoge = await c.GetCarsAsync();
    //     return (List<Car>)await c.GetAsync.GetRange();//.GetAsync();
    // }

    // public async Task<Car> GetCar(int id)
    // {
    //     var c = new CarsClient("", _client);
    //     var car = await c.GetAsync(id);
    //     return car;
    // }
}