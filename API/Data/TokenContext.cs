using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class TokenContext : DbContext
{
    private readonly IConfiguration _config; 
    
    public TokenContext(IConfiguration config)
    {
        _config = config;
    }
    
    public TokenContext(DbContextOptions<TokenContext> options, IConfiguration config) : base(options)
    {
        _config = config;
    }

    public virtual DbSet<UserToken> UserTokens { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Name=ConnectionStrings:TokenDB");
    }
}