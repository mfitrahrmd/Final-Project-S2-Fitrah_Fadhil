using API.Models;

namespace API.DTOs.response;

public class EmployeesMasterResponse : EmployeeDTO
{
    public EducationDTO Education { get; set; }
    public UniversityDTO University { get; set; }
}