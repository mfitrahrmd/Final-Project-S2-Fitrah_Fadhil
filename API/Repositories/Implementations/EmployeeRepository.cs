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
}