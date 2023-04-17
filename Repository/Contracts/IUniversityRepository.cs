using DTS_Web_Api.Models;

namespace DTS_Web_Api.Repository.Contracts
{
    public interface IUniversityRepository : IGeneralRepository<TbMUniversity, int>
    {
        Task<bool> IsNameExist(string name);
    }
}
