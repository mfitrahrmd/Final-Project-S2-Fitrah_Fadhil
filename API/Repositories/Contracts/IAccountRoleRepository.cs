using API.Models;

namespace API.Repositories.Contracts;

public interface IAccountRoleRepository : IBaseRepository<int, AccountRole>
{
    public Task<IEnumerable<AccountRole>> FindManyByAccountNikIncludeRoleAsync(string accountNik);
}