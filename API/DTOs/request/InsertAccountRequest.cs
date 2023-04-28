using System.ComponentModel.DataAnnotations;
using API.Annotations;

namespace API.DTOs.request;

public class InsertAccountRequest
{
    [MinLength(1), MaxLength(5)]
    public string EmployeeNik { get; set; }
    
    [MaxLength(255)]
    public string Password { get; set; }
}