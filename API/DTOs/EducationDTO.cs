namespace API.DTOs;

public class EducationDTO
{
    public int Id { get; set; }

    public string Major { get; set; }

    public string Degree { get; set; }

    public decimal Gpa { get; set; }
    
    public int UniversityId { get; set; }
}