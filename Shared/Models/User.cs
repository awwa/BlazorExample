using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Shared.Models;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    private string _password = "";

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password
    {
        get { return _password; }
        set { _password = hash(value); }
    }
    [Required]
    public RoleType Role { get; set; }
    [Required]
    [Column(TypeName = "Timestamp")]
    public DateTime CreatedAt { get; set; }
    [Required]
    [Column(TypeName = "Timestamp")]
    public DateTime UpdatedAt { get; set; }
    // https://blog.beachside.dev/entry/2020/03/30/200000
    [Required]
    public bool IsDel { get; set; } = false;

    public enum RoleType
    {
        Admin,
        User,
        Guest
    }

    public User(int id, string name, string email, RoleType role)
    {
        this.Id = id;
        this.Name = name;
        this.Email = email;
        this.Role = role;
    }

    public static string hash(string plain)
    {
        return BCrypt.Net.BCrypt.HashPassword(plain, workFactor: 5);
    }

}
