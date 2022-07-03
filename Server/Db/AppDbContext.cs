using HogeBlazor.Server.Db.Configurations;
using HogeBlazor.Shared.Models.Db;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Server.Db;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
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

        // 値コンバーター
        modelBuilder.Entity<Car>()
            .Property(r => r.DeletedAt)
            .HasConversion<DateTime?>(
                v => v!.Value.ToUniversalTime(),
                vo => vo!.Value.ToLocalTime()
            );
        modelBuilder.Entity<Car>()
            .Property(r => r.CreatedAt)
            .HasConversion<DateTime>(
                v => v.ToUniversalTime(),
                vo => vo.ToLocalTime()
            );
        modelBuilder.Entity<Car>()
            .Property(r => r.UpdatedAt)
            .HasConversion<DateTime>(
                v => v.ToUniversalTime(),
                vo => vo.ToLocalTime()
            );

        // 初期データ投入
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
    }

    public DbSet<Car> Cars { get; set; } = default!;
}