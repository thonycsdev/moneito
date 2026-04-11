using Microsoft.EntityFrameworkCore;
using MoneiroRepository.Interfaces;

namespace MoneiroRepository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly MoneiroDbContext _context;
    protected readonly DbSet<T> _dbSet;

    protected RepositoryBase(MoneiroDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id)
        => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.AsNoTracking().ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id)
            ?? throw new KeyNotFoundException($"{typeof(T).Name} with id '{id}' was not found.");

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
