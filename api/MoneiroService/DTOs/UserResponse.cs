using MoneiroDomain.Entities;

namespace MoneiroService.DTOs;

public class UserResponse
{
    public Guid Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public static UserResponse FromEntity(User user) => new()
    {
        Id = user.Id,
        FullName = user.FullName,
        Email = user.Email,
        CreatedAt = user.CreatedAt,
        UpdatedAt = user.UpdatedAt,
    };
}
