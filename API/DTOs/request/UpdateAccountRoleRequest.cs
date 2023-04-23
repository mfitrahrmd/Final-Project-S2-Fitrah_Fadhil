using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class UpdateAccountRoleRequest
{
    [MinLength(1), MaxLength(5)]
    public string AccountNik { get; set; }

    public int RoleId { get; set; }
}