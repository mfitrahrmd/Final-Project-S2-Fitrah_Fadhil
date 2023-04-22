using System.Security.Claims;
using API.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace API_Tests;

[TestClass]
public class JwtUtilShould : API_Tests
{
    private readonly JwtUtil _jwtUtil;

    public JwtUtilShould(JwtUtil jwtUtil)
    {
        _jwtUtil = _service.GetService<JwtUtil>();
    }
    
    [TestMethod]
    public void GenerateToken_Should_Generate_Jwt_Token_With_Given_Payload()
    {
        var token = _jwtUtil.GenerateToken(new Claim(ClaimTypes.Name, "Test"));
        
        Assert.IsTrue(token.Length > 0);
    }
}