using DTS_Web_Api.Models;

namespace DTS_Web_Api.Repository.Contracts
{
    public interface IUniversityRepository : IGeneralRepository<University, int>
    {
        Task<University?> GetByNameAsync(string name);
        Task<bool> IsNameExistAsync(string name);

    }
}
