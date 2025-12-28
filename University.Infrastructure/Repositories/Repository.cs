using Microsoft.EntityFrameworkCore;

namespace University.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly UniversityContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(UniversityContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<T?> GetAsync(Guid id)
        => await _dbSet.FindAsync(id);

    public async Task AddAsync(T entity)
        => await _dbSet.AddAsync(entity);

    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task SaveAsync()
        => await _context.SaveChangesAsync();
}
