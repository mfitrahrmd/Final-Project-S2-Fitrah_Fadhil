using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API.Utils;

public class JwtUtil
{
    private readonly IConfiguration _config;

    public JwtUtil(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var key = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"])),
            SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: _config["jwt:Issuer"],
            audience: _config["jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(_config.GetValue<double>("jwt:AccessTokenExpiresInMinute")),
            signingCredentials: key);

        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    public string GenerateToken(params Claim[] claims)
    {
        return GenerateAccessToken(claims.AsEnumerable());
    }

    public string GenerateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}