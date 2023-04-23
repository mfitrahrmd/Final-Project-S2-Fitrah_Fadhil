using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class UpdateUniversityRequest
{
    [MinLength(1), MaxLength(100)]
    public string Name { get; set; }
}