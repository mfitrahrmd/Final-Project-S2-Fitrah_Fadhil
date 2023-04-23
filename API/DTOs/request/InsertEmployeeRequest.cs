using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Annotations;
using API.Extras;
using Microsoft.EntityFrameworkCore;

namespace API.DTOs.request;

public class InsertEmployeeRequest
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

    [DataType(DataType.Date)]
    public DateTime HiringDate { get; set; }

    [UniqueEmail]
    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }

    [UniquePhoneNumber]
    [MaxLength(20)]
    [Phone]
    public string? PhoneNumber { get; set; }
}