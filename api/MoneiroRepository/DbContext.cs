using Microsoft.EntityFrameworkCore;

namespace MoneiroRepository;

public class MoneiroDbContext : DbContext
{
    public MoneiroDbContext(DbContextOptions<MoneiroDbContext> options) : base(options) { }
}
