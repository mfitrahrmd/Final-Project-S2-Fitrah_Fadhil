namespace API.Repositories.Contracts;

public interface IBaseRepository<TPk, TEntity> where TEntity : IEntity<TPk>
{
    Task<TEntity?> InsertOne(TEntity entity);
    Task<TEntity?> FindOneByPk(TPk pk);
    Task<IEnumerable<TEntity>> FindAll();
    Task<IEnumerable<TEntity>> FindAll(int limit, int offset);
    Task<TEntity?> UpdateOneByPk(TPk pk, TEntity entity);
    Task<TEntity?> DeleteOneByPk(TPk pk);
}