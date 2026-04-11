using MoneiroDomain.Interfaces;
using MoneiroService.Interfaces;

namespace MoneiroService;

public class UserPasswordHasher : IUserPasswordHasher
{
    private readonly IPasswordHasher _passwordHasher;
    public UserPasswordHasher(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    public string HashUserPassword(string userPassword)
    {
        string hashedPassword = _passwordHasher.Hash(userPassword);
        return hashedPassword;
    }

    public bool VerifyUserPasswordMatch(string input, string hashedPassword)
    {
        bool result = _passwordHasher.Verify(input, hashedPassword);
        return result;
    }
}