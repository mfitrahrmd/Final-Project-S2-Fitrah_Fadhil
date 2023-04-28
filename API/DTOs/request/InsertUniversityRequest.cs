using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class InsertUniversityRequest
{
    [MinLength(1), MaxLength(100)]
    public string Name { get; set; }
}