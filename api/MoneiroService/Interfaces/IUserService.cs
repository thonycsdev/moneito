using MoneiroService.DTOs;

namespace MoneiroService.Interfaces;

public interface IUserService
{
    Task<UserResponse> CreateNewUser(CreateUserRequest input);
}