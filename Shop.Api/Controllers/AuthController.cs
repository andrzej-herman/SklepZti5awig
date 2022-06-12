using Microsoft.AspNetCore.Mvc;
using Shop.Api.Services;
using Shop.Common.Dtos;

namespace Shop.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController
{
    private readonly IAuthService _service;
    
    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("/register")]
    public ResponseDto Register(RegisterRequestDto dto)
    {
        return _service.Register(dto);
    }
    
    
    [HttpPost]
    [Route("/login")]
    public LoginResponseDto Register(LoginRequestDto dto)
    {
        var user = _service.Login(dto);
        return user != null
            ? new LoginResponseDto() {User = user}
            : new LoginResponseDto() {Error = "Nieprawiłowy adres email lub hasło"};
    }
        
    
}