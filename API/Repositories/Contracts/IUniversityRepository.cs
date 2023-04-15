using API.Models;

namespace API.Repositories.Contracts;

public interface IUniversityRepository : IBaseRepository<int, TbMUniversity>
{
    Task<IEnumerable<TbMUniversity>> FindManyContainsName(string name);
}