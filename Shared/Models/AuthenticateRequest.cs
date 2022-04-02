namespace HogeBlazor.Shared.Models;
public class AuthenticateRequest
{
    public string Email { get; set; } = string.Empty;
    public string PlainPassword { get; set; } = string.Empty;
}