using DTS_Tugas6.Models;
using Microsoft.EntityFrameworkCore;

namespace DTS_Tugas6.Repositories;

public abstract class EFCoreRepository<TPk, TEntity, TContext> : IBaseRepository<TPk, TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected readonly TContext _context;

    protected EFCoreRepository(TContext context)
    {
        _context = context;
    }

    public TEntity InsertOne(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();

        return entity;
    }

    public IEnumerable<TEntity> FindAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public TEntity? FindOneByPk(TPk pk)
    {
        return _context.Set<TEntity>().Find(pk);
    }

    private TEntity? FindOneByPkAsNoTracking(TPk pk)
    {
        var foundEntity = _context.Set<TEntity>().Find(pk);
        _context.Entry(foundEntity).State = EntityState.Detached;

        return foundEntity;
    }

    public TEntity? DeleteOneByPk(TPk pk)
    {
        var foundEntity = FindOneByPkAsNoTracking(pk);

        if (foundEntity is null)
            return foundEntity;

        _context.Set<TEntity>().Remove(foundEntity);

        _context.SaveChanges();

        return foundEntity;
    }

    public TEntity? UpdateOneByPk(TPk pk, TEntity entity)
    {
        var foundEntity = FindOneByPkAsNoTracking(pk);

        if (foundEntity is null)
            return foundEntity;
        
        _context.Set<TEntity>().Update(entity);

        _context.SaveChanges();

        return entity;
    }
}