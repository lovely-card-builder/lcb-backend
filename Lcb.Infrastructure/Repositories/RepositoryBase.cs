using Microsoft.EntityFrameworkCore;

namespace Lcb.Infrastructure.Repositories;

public class RepositoryBase<T> : IRepository<T>
    where T : class
{
    private readonly LcbContext _context;

    public RepositoryBase(LcbContext context)
    {
        _context = context;
    }

    private  DbSet<T> GetSet()
    {
        return _context.Set<T>();
    }

    

    public IQueryable<T> GetAll()
    {
        return GetSet();
    }

    public async Task Add(IEnumerable<T> entities)
    {
        var dbSet = GetSet();
        
        dbSet.AddRange(entities);

        await _context.SaveChangesAsync();
    }

    public async Task Add(T entity)
    {
        var dbSet = GetSet();
        
        dbSet.Add(entity);

        await _context.SaveChangesAsync();
    }

    public async Task Update(IEnumerable<T> entities)
    {
        var dbSet = GetSet();
        
        dbSet.UpdateRange(entities);

        await _context.SaveChangesAsync();
    }

    public async Task Update(T entity)
    {
        var dbSet = GetSet();
        
        dbSet.Update(entity);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(IEnumerable<T> entities)
    {
        var dbSet = GetSet();
        
        dbSet.RemoveRange(entities);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        var dbSet = GetSet();
        
        dbSet.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task SaveChanges(T entity)
    {
        await _context.SaveChangesAsync();
    }
}