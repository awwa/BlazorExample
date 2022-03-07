// //using Microsoft.EntityFrameworkCore;
// //using Pomelo.EntityFrameworkCore.MySql;

// namespace HogeBlazor.Server.Helpers;
// public class Member
// {
//     public int id {get;set;}
//     public string name{get;set;} = "";
//     public string email {get;set;} = "";
// }

// public class HogeBlazorDbContext : DbContext
// {
//     public DbSet<Member>? Members{get;set;}

//     // public HogeBlazorDbContext(DbContextOptions<HogeBlazorDbContext> options)
//     //     : base(options)
//     // {
//     // }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// {
//     //  #warning To protect potentially sensitive information in your connection string, 
//     //  you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 
//     //  for guidance on storing connection strings.
//         //var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
//         //optionsBuilder.UseMySQL(
//             // @"server=localhost;database=hoge_blazor;userid=root;password=password",
//             // serverVersion);
//     }
// }