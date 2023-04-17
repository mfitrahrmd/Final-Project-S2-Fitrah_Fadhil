using API.Models;

namespace API.Repositories.Contracts;

public interface IAccountRepository : IBaseRepository<string, TbMAccount>
{
    Task<TbMEmployee?> RegisterAsync(TbMEmployee employee);
    Task<TbMEmployee?> LoginAsync(TbMEmployee employee);
}