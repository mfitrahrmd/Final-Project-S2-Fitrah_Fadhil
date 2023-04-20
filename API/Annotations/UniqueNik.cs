using System.ComponentModel.DataAnnotations;
using API.Repositories.Contracts;

namespace API.Annotations;

public class UniqueNik : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var employeeRepository = validationContext.GetService<IEmployeeRepository>();

        var foundEmployee = employeeRepository.FindOneByPk(value.ToString()).Result;

        if (foundEmployee is not null)
        {
            return new ValidationResult($"Nik '{value}' is already taken.");
        }
        
        return ValidationResult.Success;
    }
}