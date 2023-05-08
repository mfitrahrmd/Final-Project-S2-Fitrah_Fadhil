using API.Models;

namespace API.Repositories.Contracts;

public interface IRefreshTokenRepository : IBaseRepository<string, UserToken>
{
}