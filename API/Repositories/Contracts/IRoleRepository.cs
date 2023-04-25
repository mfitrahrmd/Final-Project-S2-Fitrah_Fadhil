using API.Models;

namespace API.Repositories.Contracts;

public interface IRoleRepository : IBaseRepository<int, Role>
{
    public Task<Role> FindOneOrInsertByName(string name);
}