using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class RoleRepository<TContext> : CoreRepository<int, TbMRole, TContext>, IRoleRepository
    where TContext : DbContext
{
    public RoleRepository(TContext context) : base(context)
    {
    }

    public async Task<TbMRole> FindOneOrInsertByName(string name)
    {
        var foundRole = await _dbSet.FirstOrDefaultAsync(r => r.Name.Equals(name));

        var insertedRole = new TbMRole
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