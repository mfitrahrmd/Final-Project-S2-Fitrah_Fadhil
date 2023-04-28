using System.ComponentModel.DataAnnotations;
using API.Annotations;
using API.Extras;

namespace API.DTOs.request;

public class UpdateEmployeeRequest
{
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

    [MaxLength(50)]
    [EmailAddress]
    public string Email { get; set; }

    [MaxLength(20)]
    [Phone]
    public string? PhoneNumber { get; set; }
}