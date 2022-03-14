using Microsoft.EntityFrameworkCore;
using HogeBlazor.Shared.Models;

namespace HogeBlazor.Server.Helpers;

public class HogeBlazorDbContext : DbContext
{
    public DbSet<Member>? Members { get; set; }
    public DbSet<User>? Users { get; set; }

    public HogeBlazorDbContext(DbContextOptions<HogeBlazorDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // レコードのデフォルト値
        modelBuilder.Entity<User>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<User>()
            .Property(b => b.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        // 初期データの投入
        modelBuilder.Entity<User>().HasData(
            new User(
                id: 1,
                name: "管理者",
                email: "admin@hogeblazor",
                role: User.RoleType.Admin
            )
        // new User
        // {
        //     Id = 1,
        //     Name = "管理者",
        //     Email = "admin@hogeblazor",
        //     Password = User.hash("password"),
        //     Role = User.RoleType.Admin,
        // }
        );
    }
}