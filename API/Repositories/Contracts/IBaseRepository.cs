namespace API.Repositories.Contracts;

public interface IBaseRepository<TPk, TEntity> where TEntity : class
{
    Task<TEntity?> InsertOne(TEntity entity);
    Task<TEntity?> FindOneByPk(TPk pk);
    Task<IEnumerable<TEntity>> FindAll();
    Task<TEntity?> UpdateOneByPk(TPk pk, TEntity entity);
    Task<TEntity?> DeleteOneByPk(TPk pk);
}