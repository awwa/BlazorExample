using System.ComponentModel.DataAnnotations;
using NodaTime;

namespace HogeBlazor.Shared.Models;

public class WeatherForecast
{
    public int Id { get; set; }
    public LocalDate Date { get; set; }
    public LocalTime Time { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
