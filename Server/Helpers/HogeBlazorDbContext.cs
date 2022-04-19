// using Microsoft.EntityFrameworkCore;
// using HogeBlazor.Shared.Models;

// namespace HogeBlazor.Server.Helpers;

// public class HogeBlazorDbContext// : DbContext
// {
//     public virtual DbSet<Member> Members { get; set; } = default!;
//     public virtual DbSet<User> Users { get; set; } = default!;

//     public HogeBlazorDbContext()
//         : base()
//     {
//     }
//     // public HogeBlazorDbContext(DbContextOptions<HogeBlazorDbContext> options)
//     //     : base(options)
//     // {
//     // }

//     // protected override void OnModelCreating(ModelBuilder modelBuilder)
//     // {
//     //     base.OnModelCreating(modelBuilder);
//     //     // 論理削除されたレコードを除外する
//     //     modelBuilder.Entity<User>()
//     //         .HasQueryFilter(s => !s.IsDel);
//     //     // レコードのデフォルト値
//     //     modelBuilder.Entity<User>()
//     //         .Property(b => b.CreatedAt)
//     //         .HasDefaultValueSql("CURRENT_TIMESTAMP");
//     //     modelBuilder.Entity<User>()
//     //         .Property(b => b.UpdatedAt)
//     //         .HasDefaultValueSql("CURRENT_TIMESTAMP");
//     //     // 初期データの投入
//     //     modelBuilder.Entity<User>().HasData(
//     //         new User()
//     //         {
//     //             Id = 1,
//     //             Name = "管理者",
//     //             Email = "admin@hogeblazor",
//     //             PlainPassword = "password",
//     //             Role = User.RoleType.Admin
//     //         }
//     //     );
//     //     modelBuilder.Entity<User>().HasData(
//     //         new User()
//     //         {
//     //             Id = 2,
//     //             Name = "削除済みユーザー",
//     //             Email = "deleted@hogeblazor",
//     //             PlainPassword = "password",
//     //             Role = User.RoleType.Admin,
//     //             IsDel = true
//     //         }
//     //     );
//     //     modelBuilder.Entity<User>().HasData(
//     //         new User()
//     //         {
//     //             Id = 3,
//     //             Name = "一般ユーザー",
//     //             Email = "user@hogeblazor",
//     //             PlainPassword = "password",
//     //             Role = User.RoleType.User
//     //         }
//     //     );
//     //     modelBuilder.Entity<User>().HasData(
//     //         new User()
//     //         {
//     //             Id = 4,
//     //             Name = "ゲストユーザー",
//     //             Email = "guest@hogeblazor",
//     //             PlainPassword = "password",
//     //             Role = User.RoleType.Guest
//     //         }
//     //     );
//     // }
// }