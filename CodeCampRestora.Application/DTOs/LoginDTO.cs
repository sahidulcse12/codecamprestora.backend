namespace CodeCampRestora.Application.DTOs;

public class LoginDTO
{
    public required string UserName { get; set; } = default!;
    public required string Password { get; set; } = default!;
}