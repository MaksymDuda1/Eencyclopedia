namespace Eencyclopedia.Domain.DTOs;

public class RegistrationDto
{
    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}