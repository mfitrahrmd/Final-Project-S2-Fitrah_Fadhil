using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class InsertAccountRoleRequest
{
    [MinLength(1), MaxLength(5)]
    public string AccountNik { get; set; }

    public int RoleId { get; set; }
}