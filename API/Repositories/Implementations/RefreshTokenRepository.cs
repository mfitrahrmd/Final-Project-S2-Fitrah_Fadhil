using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class RefreshTokenRepository<TContext> : CoreRepository<string, UserToken, TContext>, IRefreshTokenRepository
where TContext : DbContext
{
    public RefreshTokenRepository(TContext context) : base(context)
    {
    }
}