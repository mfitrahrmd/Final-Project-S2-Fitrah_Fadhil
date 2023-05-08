using API.Models;

namespace API.Repositories.Contracts;

public interface IRefreshTokenRepository : IBaseRepository<int, UserToken>
{
    Task<UserToken> FindOneByRefreshTokenAsync(string refreshToken);
}