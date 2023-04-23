using System.ComponentModel.DataAnnotations;

namespace API.DTOs.request;

public class UpdateEducationRequest
{
    [MaxLength(100)]
    public string Major { get; set; }
    
    [MaxLength(10)]
    public string Degree { get; set; }
    
    [Range(0, 4)]
    public decimal Gpa { get; set; }

    public int UniversityId { get; set; }
}