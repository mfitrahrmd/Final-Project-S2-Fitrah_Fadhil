using API.Exceptions;
using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class RefreshTokenRepository<TContext> : CoreRepository<int, UserToken, TContext>, IRefreshTokenRepository
where TContext : DbContext
{
    public RefreshTokenRepository(TContext context) : base(context)
    {
    }

    public async Task<UserToken> FindOneByRefreshTokenAsync(string refreshToken)
    {
        var result = await _dbSet.FirstOrDefaultAsync(ut => ut.RefreshToken.Equals(refreshToken));

        if (result is null) throw new RepositoryException(RepositoryErrorType.NotFound, "Refresh token was not found.");

        return result;
    }
}