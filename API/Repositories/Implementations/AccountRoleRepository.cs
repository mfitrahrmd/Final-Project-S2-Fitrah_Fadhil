using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class AccountRoleRepository<TContext> : CoreRepository<int, AccountRole, TContext>, IAccountRoleRepository
    where TContext : DbContext
{
    public AccountRoleRepository(TContext context) : base(context)
    {
    }

    public async Task<IEnumerable<AccountRole>> FindManyByAccountNikIncludeRoleAsync(string accountNik)
    {
        return _dbSet.Include(ar => ar.Role).Where(ar => ar.AccountNik.Equals(accountNik));
    }
}