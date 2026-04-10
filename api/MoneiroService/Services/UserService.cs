using MoneiroService.DTOs;
using MoneiroService.Interfaces;

namespace MoneiroService.Services;

public class UserService : IUserService
{
    public Task<UserResponse> CreateNewUser(CreateUserRequest input)
    {
        throw new NotImplementedException();
    }
}