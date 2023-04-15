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

    public async Task<TbMEmployee?> FindOneByEmail(string email)
    {
        return await _context.Set<TbMEmployee>().FirstOrDefaultAsync(e => e.Email.Equals(email));
    }
}