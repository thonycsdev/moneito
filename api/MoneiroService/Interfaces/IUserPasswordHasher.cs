namespace MoneiroService.Interfaces;

public interface IUserPasswordHasher
{
    string HashUserPassword(string userPassword);
    bool VerifyUserPasswordMatch(string input, string hashedPassword);
}