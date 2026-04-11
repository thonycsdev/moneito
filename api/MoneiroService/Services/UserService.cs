using MoneiroDomain.Entities;
using MoneiroRepository.Interfaces;
using MoneiroService.DTOs;
using MoneiroService.Interfaces;

namespace MoneiroService.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserPasswordHasher _userPasswordHasher;
    public UserService(IUserRepository userRepository, IUserPasswordHasher userPasswordHasher)
    {
        _userRepository = userRepository;
        _userPasswordHasher = userPasswordHasher;
    }
    public async Task<UserResponse> CreateNewUser(CreateUserRequest input)
    {
        User? existingUser = await _userRepository.GetUserByEmail(input.Email);
        if (existingUser is not null)
            throw new InvalidDataException("Email already present");

        string hashedPassword = _userPasswordHasher.HashUserPassword(input.Password);

        User createdUser = input.ToEntity();
        createdUser.PasswordHash = hashedPassword;

        User userResult = await _userRepository.AddAsync(createdUser);

        return UserResponse.FromEntity(userResult);

    }
}