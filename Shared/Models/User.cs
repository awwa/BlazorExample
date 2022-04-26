using Microsoft.AspNetCore.Identity;

namespace HogeBlazor.Shared.Models;

public class User : IdentityUser
{
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }
}