using Microsoft.EntityFrameworkCore;
using HogeBlazor.Shared.Models;

namespace HogeBlazor.Shared.Helpers;

public class HogeBlazorDbContext : DbContext
{
    public DbSet<Member>? Members{get;set;}

    public HogeBlazorDbContext(DbContextOptions<HogeBlazorDbContext> options)
        : base(options)
    {
    }
}