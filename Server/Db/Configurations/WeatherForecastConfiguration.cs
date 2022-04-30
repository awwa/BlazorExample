using HogeBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NodaTime;

namespace HogeBlazor.Server.Db.Configurations;

public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.HasData
        (
            new WeatherForecast
            {
                Id = 1,
                Date = new LocalDate(2022, 5, 18),
                Time = new LocalTime(12, 34, 56),
                TemperatureC = 15,
                Summary = "雨",
            },
            new WeatherForecast
            {
                Id = 2,
                Date = new LocalDate(2022, 5, 18),
                Time = new LocalTime(12, 34, 56),
                TemperatureC = 18,
                Summary = "晴れのち曇",
            },
            new WeatherForecast
            {
                Id = 3,
                Date = new LocalDate(2022, 5, 18),
                Time = new LocalTime(12, 34, 56),
                TemperatureC = 22,
                Summary = "晴",
            },
            new WeatherForecast
            {
                Id = 4,
                Date = new LocalDate(2022, 5, 18),
                Time = new LocalTime(12, 34, 56),
                TemperatureC = 26,
                Summary = "台風",
            },
            new WeatherForecast
            {
                Id = 5,
                Date = new LocalDate(2022, 5, 18),
                Time = new LocalTime(12, 34, 56),
                TemperatureC = 21,
                Summary = "曇",
            }
        );
    }
}