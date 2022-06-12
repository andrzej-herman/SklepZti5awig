using Shop.Api.Entities;
using Shop.Api.Repository;
using Shop.Common.Dtos;
using System.Security.Cryptography;
using System.Text;

namespace Shop.Api.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _repo;
        
    public AuthService(IAuthRepository repo)
    {
        _repo = repo;
    }
    
    
    public ResponseDto Register(RegisterRequestDto dto)
    {
        try
        {
            CreateHashAndSalt(dto.Password, out var hash, out var salt);
            var user = new ShopUser()
            {
                UserFirstName = dto.FirstName,
                UserLastName = dto.LastName,
                UserEmail = dto.Email,
                UserId = Guid.NewGuid().ToString(),
                UserPasswordSalt = salt,
                UserPasswordHash = hash
            };
            var result = _repo.Register(user);
            return new ResponseDto() {Result = true, Description = "Rejestracja przebiegła pomyślnie"};
        }
        catch (Exception ex)
        {
            return new ResponseDto() {Result = false, Description = ex.Message};
        }
        
    }

    public UserDto Login(LoginRequestDto dto)
    {
        var user = _repo.Login(dto.Email, dto.Password);
        if (user == null) return null;
        return new UserDto()
        {
            UserId = user.UserId,
            Name = $"{user.UserFirstName} {user.UserLastName}",
            Initials = $"{user.UserFirstName[..1].ToUpper()}{user.UserLastName[..1].ToUpper()}"
        };
    }

    private static void CreateHashAndSalt(string plainPassword, out byte[] hash, out byte[] salt)
    {
        using var algorithm = new HMACSHA512();
        salt = algorithm.Key;
        hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plainPassword.Trim()));
    }
}