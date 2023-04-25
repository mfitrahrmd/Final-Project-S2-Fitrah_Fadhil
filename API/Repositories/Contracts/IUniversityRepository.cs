using API.Models;

namespace API.Repositories.Contracts;

public interface IUniversityRepository : IBaseRepository<int, University>
{
    Task<IEnumerable<University>> FindManyContainsNameAsync(string name);
    Task<University?> FindOneByNameAsync(string name);
    Task<University> FindOneOrInsertByName(string name);
}