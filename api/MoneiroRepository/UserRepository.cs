using Microsoft.EntityFrameworkCore;
using MoneiroDomain.Entities;
using MoneiroRepository.Interfaces;

namespace MoneiroRepository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(MoneiroDbContext context) : base(context) { }

    public async Task<User?> GetUserByEmail(string email)
        => await _dbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);
}
