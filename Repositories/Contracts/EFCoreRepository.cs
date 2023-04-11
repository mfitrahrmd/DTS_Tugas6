using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories;

public abstract class EFCoreRepository<TPk, T, TContext> : IBaseRepository<TPk, T>
    where T : class
    where TContext : DbContext
{
    private readonly TContext _context;

    protected EFCoreRepository(TContext context)
    {
        _context = context;
    }

    public async Task<T> InsertOne(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<T>> FindAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> FindOneByPk(TPk pk)
    {
        return await _context.Set<T>().FindAsync(pk);
    }

    public async Task<T?> DeleteOneByPk(TPk pk)
    {
        var entity = await _context.Set<T>().FindAsync(pk);

        if (entity is null)
        {
            return entity;
        }

        _context.Set<T>().Remove(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
}