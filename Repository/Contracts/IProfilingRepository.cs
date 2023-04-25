using DTS_Web_Api.Models;
using DTS_Web_Api.ViewModels;

namespace DTS_Web_Api.Repository.Contracts
{
    public interface IProfilingRepository : IGeneralRepository<Profiling, string>
    {
        Task<IEnumerable<TotalMajorVM>> GetTotalByMajorAsync();
    }
}
