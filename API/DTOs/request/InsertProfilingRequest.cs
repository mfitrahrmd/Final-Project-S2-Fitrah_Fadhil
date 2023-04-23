using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class InsertProfilingRequest
{
    [MinLength(1), MaxLength(5)]
    public string EmployeeNik { get; set; }

    public int EducationId { get; set; }
}