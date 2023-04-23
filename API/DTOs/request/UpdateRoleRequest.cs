using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class UpdateRoleRequest
{
    [MinLength(1), MaxLength(50)]
    public string Name { get; set; }
}