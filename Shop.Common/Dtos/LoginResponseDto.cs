namespace Shop.Common.Dtos;

public class LoginResponseDto
{
    public UserDto User { get; set; }
    public string Error { get; set; }
}