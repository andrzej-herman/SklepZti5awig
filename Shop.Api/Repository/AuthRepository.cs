using System.Data;
using Shop.Api.Entities;
using Shop.Common.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace Shop.Api.Repository;

public class AuthRepository : IAuthRepository
{
    private readonly SanShopContext _context;

    public AuthRepository(SanShopContext context)
    {
        _context = context;
    }
    
    public bool Register(ShopUser user)
    {
        try
        {
            _context.ShopUsers.Add(user);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            throw new DuplicateUserEmailException("Podany adres email już istnieje");
        }
    }

    public ShopUser Login(string email, string password)
    {
        var user = _context.ShopUsers.SingleOrDefault(x => x.UserEmail == email);
        if (user == null) return null;
        return CheckPassword(password, user.UserPasswordHash, user.UserPasswordSalt) ? user : null;
    }

    private static bool CheckPassword(string plainPassword, byte[] dbPasswordHash, byte[] dbPasswordSalt)
    {
        using var algorithm = new HMACSHA512();
        algorithm.Key = dbPasswordSalt;
        var createdPassword = algorithm.ComputeHash(Encoding.UTF8.GetBytes(plainPassword.Trim()));
        return createdPassword.SequenceEqual(dbPasswordHash);
    }

}