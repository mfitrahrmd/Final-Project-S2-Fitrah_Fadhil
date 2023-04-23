namespace API.DTOs.response;

public class EmployeesAboveAvgGpaAndHiringYearResponse : EmployeeDTO
{
    public EducationDTO Education { get; set; }
    public UniversityDTO University { get; set; }
}