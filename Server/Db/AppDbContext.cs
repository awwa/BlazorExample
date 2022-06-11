using HogeBlazor.Server.Db.Configurations;
using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Server.Db;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // 初期値
        modelBuilder.Entity<Car>()
            .Property(r => r.CreatedAt)
            .HasDefaultValueSql("NOW()");
        modelBuilder.Entity<Car>()
            .Property(r => r.UpdatedAt)
            .HasDefaultValueSql("NOW()");
        // 初期データ投入
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new WeatherForecastConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
    }

    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;
    public DbSet<Car> Cars { get; set; } = default!;
}