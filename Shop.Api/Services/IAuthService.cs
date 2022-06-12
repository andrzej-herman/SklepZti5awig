using Shop.Common.Dtos;

namespace Shop.Api.Services;

public interface IAuthService
{
    ResponseDto Register(RegisterRequestDto dto);
    UserDto Login(LoginRequestDto dto);
}