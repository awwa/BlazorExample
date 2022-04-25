using System.ComponentModel.DataAnnotations;

namespace HogeBlazor.Shared.DTO;

public class RegistrationResponseDto
{
    public bool IsSuccessfulRegistration { get; set; }
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}