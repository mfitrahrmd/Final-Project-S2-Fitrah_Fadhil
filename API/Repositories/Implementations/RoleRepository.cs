using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class RoleRepository<TContext> : CoreRepository<int, TbMRole, TContext>, IRoleRepository
    where TContext : DbContext
{
    public RoleRepository(TContext context) : base(context)
    {
    }
}