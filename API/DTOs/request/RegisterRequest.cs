using System.ComponentModel.DataAnnotations;
using API.Annotations;
using API.Extras;
using API.Models;

namespace API.DTOs.request;

public class RegisterRequest
{
    [UniqueNik]
    [MinLength(1), MaxLength(5)]
    public string Nik { get; set; }
    [MinLength(1), MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string? LastName { get; set; }
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
    [UniqueEmail]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }
    [UniquePhoneNumber]
    [MaxLength(20)]
    [Phone]
    public string? PhoneNumber { get; set; }
    [MaxLength(100)]
    public string Major { get; set; }
    [MaxLength(10)]
    public string Degree { get; set; }
    [Range(0, 4)]
    public decimal Gpa { get; set; }
    [MaxLength(100)]
    public string UniversityName { get; set; }
    [MaxLength(255)]
    public string Password { get; set; }

    public Employee ToEmployeeEntity()
    {
        return new Employee
        {
            Nik = Nik,
            FirstName = FirstName,
            LastName = LastName,
            Gender = Gender,
            Birthdate = Birthdate,
            Email = Email,
            PhoneNumber = PhoneNumber,
            TbMAccount = new Account
            {
                Password = Password
            },
            TbTrProfiling = new Profiling
            {
                Education = new Education
                {
                    Major = Major,
                    Degree = Degree,
                    Gpa = Gpa,
                    University = new University
                    {
                        Name = UniversityName
                    }
                }
            }
        };
    }
}