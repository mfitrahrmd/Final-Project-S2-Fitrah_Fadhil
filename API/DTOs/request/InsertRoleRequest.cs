using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class InsertRoleRequest
{
    [MinLength(1), MaxLength(50)]
    public string Name { get; set; }
}