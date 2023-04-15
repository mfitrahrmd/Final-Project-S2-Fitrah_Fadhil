using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class AccountRepository<TContext> : CoreRepository<string, TbMAccount, TContext>, IAccountRepository
    where TContext : DbContext
{
    public AccountRepository(TContext context) : base(context)
    {
    }
}