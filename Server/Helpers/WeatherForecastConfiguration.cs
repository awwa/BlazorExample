using HogeBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HogeBlazor.Server.Helpers;

public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.HasData
        (
            new WeatherForecast
            {
                Id = 1,
                Date = DateTime.Parse("2022-05-18"),
                TemperatureC = 15,
                Summary = "雨",
            },
            new WeatherForecast
            {
                Id = 2,
                Date = DateTime.Parse("2022-05-19"),
                TemperatureC = 18,
                Summary = "晴れのち曇",
            },
            new WeatherForecast
            {
                Id = 3,
                Date = DateTime.Parse("2022-05-20"),
                TemperatureC = 22,
                Summary = "晴",
            },
            new WeatherForecast
            {
                Id = 4,
                Date = DateTime.Parse("2022-05-21"),
                TemperatureC = 26,
                Summary = "台風",
            },
            new WeatherForecast
            {
                Id = 5,
                Date = DateTime.Parse("2022-05-22"),
                TemperatureC = 21,
                Summary = "曇",
            }
        );
    }
}