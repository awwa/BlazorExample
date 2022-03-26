using Microsoft.EntityFrameworkCore;
using HogeBlazor.Shared.Models;

namespace HogeBlazor.Server.Helpers;

public class HogeBlazorDbContext : DbContext
{
    public virtual DbSet<Member> Members { get; set; } = default!;
    public virtual DbSet<User> Users { get; set; } = default!;

    public HogeBlazorDbContext()
        : base()
    {
    }
    public HogeBlazorDbContext(DbContextOptions<HogeBlazorDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // 論理削除されたレコードを除外する
        modelBuilder.Entity<User>()
            .HasQueryFilter(s => !s.IsDel);
        // レコードのデフォルト値
        modelBuilder.Entity<User>()
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<User>()
            .Property(b => b.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        // 初期データの投入
        modelBuilder.Entity<User>().HasData(
            new User(name: "管理者", email: "admin@hogeblazor", plainPassword: "password", role: User.RoleType.Admin)
            {
                Id = 1
            }
        );
        modelBuilder.Entity<User>().HasData(
            new User(
                name: "削除済みユーザー",
                email: "deleted@hogeblazor",
                plainPassword: "password",
                role: User.RoleType.Admin
            )
            {
                Id = 2,
                IsDel = true
            }
        );
        modelBuilder.Entity<User>().HasData(
            new User(
                name: "一般ユーザー",
                email: "user@hogeblazor",
                plainPassword: "password",
                role: User.RoleType.User
            )
            {
                Id = 3
            }
        );
        modelBuilder.Entity<User>().HasData(
            new User(
                name: "ゲストユーザー",
                email: "guest@hogeblazor",
                plainPassword: "password",
                role: User.RoleType.Guest
            )
            {
                Id = 4
            }
        );
    }
}