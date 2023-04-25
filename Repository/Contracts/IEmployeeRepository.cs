using DTS_Web_Api.Models;
using DTS_Web_Api.ViewModels;

namespace DTS_Web_Api.Repository.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, string>
    {
        Task<UserDataVM> GetUserDataByEmailAsync(string email);
    }
}
