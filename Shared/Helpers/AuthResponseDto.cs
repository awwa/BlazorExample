namespace HogeBlazor.Shared.Helpers;

public class AuthResponseDto
{
    public bool IsAuthSuccessful { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}