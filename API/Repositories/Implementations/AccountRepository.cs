using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class AccountRepository<TContext> : CoreRepository<string, TbMAccount, TContext>, IAccountRepository
    where TContext : DbContext
{
    private IEmployeeRepository _employeeRepository;
    
    public AccountRepository(TContext context, IEmployeeRepository employeeRepository) : base(context)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<TbMEmployee> RegisterAsync(TbMEmployee employee)
    {
        TbMEmployee registeredAccount;
        try
        {
            registeredAccount = await _employeeRepository.InsertOne(employee);
        }
        catch (Exception e)
        {
            throw;
        }

        return registeredAccount;
    }
}