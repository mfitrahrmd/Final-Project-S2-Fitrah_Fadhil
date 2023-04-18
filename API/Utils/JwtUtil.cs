using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace API.Utils;

public record Payload(string FullName, string Email, string Role);

public class JwtUtil
{
    private readonly IConfiguration _config;

    public JwtUtil(IConfiguration config)
    {
        _config = config;
    }
    
    public string GenerateToken(Payload payload)
    {
        var key = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"])),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, payload.FullName),
            new Claim(ClaimTypes.Email, payload.Email),
            new Claim(ClaimTypes.Role, payload.Role)
        };
        var token = new JwtSecurityToken(_config["jwt:Issuer"], _config["jwt:Audience"], claims,
            DateTime.Now.AddMinutes(_config.GetValue<double>("jwt:ExpiresInMinute")), signingCredentials:key);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}