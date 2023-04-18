using API.Models;

namespace API.Repositories.Contracts;

public interface IUniversityRepository : IBaseRepository<int, TbMUniversity>
{
    Task<IEnumerable<TbMUniversity>> FindManyContainsNameAsync(string name);
    Task<TbMUniversity?> FindOneByNameAsync(string name);
}