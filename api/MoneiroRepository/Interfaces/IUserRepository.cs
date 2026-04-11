using MoneiroDomain.Entities;

namespace MoneiroRepository.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User?> GetUserByEmail(string email);

}