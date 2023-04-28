using API.Extras;

namespace API.DTOs;

public class EmployeeDTO
{
    public string Nik { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthdate { get; set; }

    public Gender Gender { get; set; }

    public DateTime HiringDate { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}