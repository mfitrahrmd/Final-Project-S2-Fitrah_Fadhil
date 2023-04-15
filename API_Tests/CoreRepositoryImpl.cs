using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API_Tests;

public class CoreRepositoryImpl<TPk, TEntity, TContext> : CoreRepository<TPk, TEntity, TContext>
where TEntity : class, IEntity<TPk>
where TContext : DbContext
{
    public CoreRepositoryImpl(TContext context) : base(context)
    {
    }
}