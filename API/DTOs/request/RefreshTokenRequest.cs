using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class RefreshTokenRequest
{
    [Required]
    public string RefreshToken { get; set; }
}