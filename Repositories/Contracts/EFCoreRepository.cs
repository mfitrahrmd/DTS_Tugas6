using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories;

public abstract class EFCoreRepository<TPk, T, TContext> : IBaseRepository<TPk, T>
    where T : class
    where TContext : DbContext
{
    protected readonly TContext _context;

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

    private async Task<T?> FindOneByPkAsNoTracking(TPk pk)
    {
        var foundEntity = await _context.Set<T>().FindAsync(pk);
        _context.Entry(foundEntity).State = EntityState.Detached;

        return foundEntity;
    }

    public async Task<T?> DeleteOneByPk(TPk pk)
    {
        var foundEntity = await FindOneByPkAsNoTracking(pk);

        if (foundEntity is null)
            return foundEntity;

        _context.Set<T>().Remove(foundEntity);

        await _context.SaveChangesAsync();

        return foundEntity;
    }

    public async Task<T?> UpdateOneByPk(TPk pk, T entity)
    {
        var foundEntity = await FindOneByPkAsNoTracking(pk);

        if (foundEntity is null)
            return foundEntity;
        
        _context.Set<T>().Update(entity);

        await _context.SaveChangesAsync();

        return entity;
    }
}