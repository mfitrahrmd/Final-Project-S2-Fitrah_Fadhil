using API.Models;

namespace API.Repositories.Contracts;

public interface IEmployeeRepository : IBaseRepository<string, TbMEmployee>
{
    Task<TbMEmployee?> FindOneByEmail(string email);
}