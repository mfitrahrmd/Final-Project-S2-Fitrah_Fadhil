using API.Exceptions;
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

    public async Task<TbMEmployee?> RegisterAsync(TbMEmployee employee)
    {
        TbMEmployee? registeredAccount;
        try
        {
            var foundWithNik = await _employeeRepository.FindOneByPk(employee.Nik);
            if (foundWithNik is not null)
                throw new RepositoryException("Nik already exist");

            var foundWithEmail = await _employeeRepository.FindOneByEmailAsync(employee.Email);
            if (foundWithEmail is not null)
                throw new RepositoryException("email already exist");
            
            registeredAccount = await _employeeRepository.InsertOne(employee);
        }
        catch (Exception e)
        {
            throw;
        }

        return registeredAccount;
    }

    public async Task<TbMEmployee?> LoginAsync(TbMEmployee employee)
    {
        var foundEmployee = await _employeeRepository.FindOneByEmailAsync(employee.Email);

        if (foundEmployee is null)
            return null;

        if (!foundEmployee.TbMAccount.Password.Equals(employee.TbMAccount.Password))
            return null;

        return foundEmployee;
    }
}