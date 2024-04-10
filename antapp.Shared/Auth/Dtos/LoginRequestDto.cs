namespace antapp.Shared.Auth.Dtos;

public class LoginRequestDto
{
    public required string? UserName { get; set; }
    public required string? Password { get; set;}
}
