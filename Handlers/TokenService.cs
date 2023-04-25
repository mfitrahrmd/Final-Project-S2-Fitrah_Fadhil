using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DTS_Web_Api.Handlers
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetClaimsPrincipal(string Token);
    }
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        public string GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public ClaimsPrincipal GetClaimsPrincipal(string Token)
        {
            throw new NotImplementedException();
        }
    }
}
