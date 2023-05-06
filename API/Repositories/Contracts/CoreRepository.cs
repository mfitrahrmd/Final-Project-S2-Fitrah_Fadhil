using API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Contracts;

public abstract class CoreRepository<TPk, TEntity, TContext> : IBaseRepository<TPk, TEntity>
    where TEntity : class, IEntity<TPk>
    where TContext : DbContext
{
    private readonly TContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected CoreRepository(TContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
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
    
    public async Task<IEnumerable<TEntity>> FindAll(int limit, int offset)
    {
        return _context.Set<TEntity>().Skip(offset).Take(limit).ToList();
    }

    public async Task<TEntity?> FindOneByPk(TPk pk)
    {
        var foundEntity = await _context.Set<TEntity>().FindAsync(pk);
        
        if (foundEntity is null)
            throw new RepositoryException(RepositoryErrorType.NotFound, $"{typeof(TEntity).Name} with pk '{pk}' was not found.");

        return foundEntity;
    }

    public async Task<TEntity?> DeleteOneByPk(TPk pk)
    {
        var foundEntity = FindOneByPkAsNoTracking(pk);

        if (foundEntity is null)
            throw new RepositoryException(RepositoryErrorType.NotFound, $"{typeof(TEntity).Name} with pk '{pk}' was not found.");

        _context.Set<TEntity>().Remove(foundEntity);

        await _context.SaveChangesAsync();

        return foundEntity;
    }

    public async Task<TEntity?> UpdateOneByPk(TPk pk, TEntity entity)
    {
        var foundEntity = FindOneByPkAsNoTracking(pk);

        if (foundEntity is null)
            throw new RepositoryException(RepositoryErrorType.NotFound, $"{typeof(TEntity).Name} with pk '{pk}' was not found.");

        entity.Pk = foundEntity.Pk;
        
        _context.Set<TEntity>().Update(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    private TEntity? FindOneByPkAsNoTracking(TPk pk)
    {
        var foundEntity = _context.Set<TEntity>().Find(pk);
        
        if (foundEntity is null)
            return null;
        
        _context.Entry(foundEntity).State = EntityState.Detached;

        return foundEntity;
    }

    protected void WithTx(Action action)
    {
        var tx = _context.Database.BeginTransaction();

        try
        {
            action();

            _context.SaveChanges();
            
            tx.Commit();
        }
        catch (Exception e)
        {
            tx.Rollback();
            throw;
        }
    }
}