using MoneiroDomain.Entities;

namespace MoneiroService.DTOs;

public class CreateUserRequest
{
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    public User ToEntity() => new()
    {
        Id = Guid.NewGuid(),
        FullName = FullName,
        Email = Email,
        PasswordHash = Password,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow,
    };
}
