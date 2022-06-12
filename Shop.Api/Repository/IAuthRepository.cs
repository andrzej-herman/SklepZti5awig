using Shop.Api.Entities;

namespace Shop.Api.Repository;

public interface IAuthRepository
{
    bool Register(ShopUser user);
    ShopUser Login(string email, string password);
}