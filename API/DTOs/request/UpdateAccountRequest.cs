using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class UpdateAccountRequest
{
    [MaxLength(255)]
    public string Password { get; set; }
}