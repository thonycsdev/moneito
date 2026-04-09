using Microsoft.EntityFrameworkCore;
using MoneiroDomain.Entities;

namespace MoneiroRepository;

public class MoneiroDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public MoneiroDbContext(DbContextOptions<MoneiroDbContext> options) : base(options) { }
}
