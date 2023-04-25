using DTS_Web_Api.Models;

namespace DTS_Web_Api.Repository.Contracts
{
    public interface IAccountRoleRepository : IGeneralRepository<AccountRole, int>
    {
        Task<IEnumerable<string>> GetRolesByNikAsync(string nik);
    }
}
