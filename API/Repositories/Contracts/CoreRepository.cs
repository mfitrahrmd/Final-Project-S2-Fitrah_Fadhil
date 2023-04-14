using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Contracts;

public abstract class CoreRepository<TPk, TEntity, TContext> : IBaseRepository<TPk, TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected readonly TContext _context;

    protected CoreRepository(TContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> InsertOne(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        var rowAffected = await _context.SaveChangesAsync();

        return rowAffected < 1 ? null : entity;
    }

    public async Task<IEnumerable<TEntity>> FindAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public async Task<TEntity?> FindOneByPk(TPk pk)
    {
        return await _context.Set<TEntity>().FindAsync(pk);
    }

    private TEntity? FindOneByPkAsNoTracking(TPk pk)
    {
        var foundEntity = _context.Set<TEntity>().Find(pk);
        _context.Entry(foundEntity).State = EntityState.Detached;

        return foundEntity;
    }

    public async Task<TEntity?> DeleteOneByPk(TPk pk)
    {
        var foundEntity = FindOneByPkAsNoTracking(pk);

        if (foundEntity is null)
            return foundEntity;

        _context.Set<TEntity>().Remove(foundEntity);

        var rowAffected = await _context.SaveChangesAsync();

        return rowAffected < 1 ? null : foundEntity;
    }

    public async Task<TEntity?> UpdateOneByPk(TPk pk, TEntity entity)
    {
        var foundEntity = FindOneByPkAsNoTracking(pk);

        if (foundEntity is null)
            return foundEntity;
        
        _context.Set<TEntity>().Update(entity);

        var rowAffected = await _context.SaveChangesAsync();

        return rowAffected < 1 ? null : foundEntity;
    }
}