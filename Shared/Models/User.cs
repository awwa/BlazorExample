using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HogeBlazor.Shared.Models;

[Index(nameof(Email), IsUnique = true)]
public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    [Required]
    public string Password { get; set; } = "";
    [Required]
    public string Role { get; set; } = "";
    [Required]
    public DateTime CreatedAt { get; set; } = new DateTime();
    [Required]
    public DateTime UpdatedAt { get; set; } = new DateTime();
    // https://blog.beachside.dev/entry/2020/03/30/200000
    [Required]
    public bool IsDel { get; set; } = false;

}
