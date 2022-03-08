using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions;
using Pomelo.EntityFrameworkCore.MySql;

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
    // private readonly string _connectionString;

    public HogeBlazorDbContext(DbContextOptions options)
        : base(options)
    {
    }
    // public HogeBlazorDbContext(string connectionString)
    // {
    //     _connectionString = connectionString;
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
//     //  #warning To protect potentially sensitive information in your connection string, 
//     //  you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 
//     //  for guidance on storing connection strings.
        optionsBuilder.UseMySql(connectionString: @"server=localhost;database=hoge_blazor;userid=root;password=password", 
            new MySqlServerVersion(new Version(8, 0, 27))
            /*mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend)*/);
    }
}