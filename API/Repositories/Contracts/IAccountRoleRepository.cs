using API.Models;

namespace API.Repositories.Contracts;

public interface IAccountRoleRepository : IBaseRepository<int, TbTrAccountRole>
{
    public Task<IEnumerable<TbTrAccountRole>> FindManyByAccountNikIncludeRoleAsync(string accountNik);
}