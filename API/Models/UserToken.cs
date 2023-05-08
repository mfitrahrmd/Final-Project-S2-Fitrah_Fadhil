using System.ComponentModel.DataAnnotations;
using API.Repositories.Contracts;

namespace API.Models;

public class UserToken : IEntity<string>
{
    [Key]
    public string Pk { get; set; }
    
    public string RefreshToken { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime ExpiryDate { get; init; }
}