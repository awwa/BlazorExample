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
}