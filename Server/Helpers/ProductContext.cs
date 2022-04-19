using HogeBlazor.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ProductContext : IdentityDbContext<IdentityUser>
{
  public ProductContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfiguration(new ProductConfiguration());
  }

  public DbSet<Product> Products { get; set; }
}