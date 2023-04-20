using System.ComponentModel.DataAnnotations;
using API.Repositories.Contracts;

namespace API.Annotations;

public class UniquePhoneNumber : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var employeeRepository = validationContext.GetService<IEmployeeRepository>();

        var foundEmployee = employeeRepository.FindOneByPhoneNumberAsync(value.ToString()).Result;

        if (foundEmployee is not null)
        {
            return new ValidationResult($"Phone Number '{value}' is already taken.");
        }
        
        return ValidationResult.Success;
    }
}