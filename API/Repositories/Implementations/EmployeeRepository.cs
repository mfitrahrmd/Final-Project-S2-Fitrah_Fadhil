using API.DTOs.response;
using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class EmployeeRepository<TContext> : CoreRepository<string, TbMEmployee, TContext>, IEmployeeRepository
    where TContext : DbContext
{
    public EmployeeRepository(TContext context) : base(context)
    {
    }

    public async Task<TbMEmployee?> FindOneByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Email.Equals(email));
    }

    public async Task<TbMEmployee?> FindOneByPhoneNumberAsync(string phoneNumber)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.PhoneNumber.Equals(phoneNumber));
    }

    public async Task<IEnumerable<TbMEmployee>> FindManyIncludeEducationAndUniversityAsync()
    {
        return _dbSet
            .Include(e => e.TbTrProfiling)
            .ThenInclude(p => p.Education)
            .ThenInclude(e => e.University)
            .AsEnumerable();
    }
}