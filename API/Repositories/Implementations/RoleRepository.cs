using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class RoleRepository<TContext> : CoreRepository<int, Role, TContext>, IRoleRepository
    where TContext : DbContext
{
    public RoleRepository(TContext context) : base(context)
    {
    }

    public async Task<Role> FindOneOrInsertByName(string name)
    {
        var foundRole = await _dbSet.FirstOrDefaultAsync(r => r.Name.Equals(name));

        var insertedRole = new Role
        {
            Name = name
        };

        if (foundRole is null)
        {
            WithTx(() =>
            {
                _dbSet.Add(insertedRole);
            });

            return insertedRole;
        }

        return foundRole;
    }
}