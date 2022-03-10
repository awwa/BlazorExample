using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Server.Helpers;
public class Member
{
    public int id {get;set;}
    public string name{get;set;} = "";
    public string email {get;set;} = "";
}

public class HogeBlazorDbContext : DbContext
{
    public DbSet<Member>? Members{get;set;}

    public HogeBlazorDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        string conn = configuration.GetConnectionString("HogeBlazorDatabase");
        optionsBuilder.UseMySql(connectionString: conn, 
            new MySqlServerVersion(new Version(8, 0, 27))
            /*mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)*/);
    }
}