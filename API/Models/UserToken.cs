using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class UserToken : IEntity<int>
{
    [Key]
    public int Id { get; set; }

    [JsonIgnore]
    [NotMapped]
    public int Pk
    {
        get => Id;
        set => Id = value;
    }
    
    public string UserId { get; set; }
    
    public string RefreshToken { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime ExpiryDate { get; init; }
}