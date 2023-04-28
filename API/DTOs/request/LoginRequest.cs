using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs.request;

public class LoginRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }

    public Employee ToEmployeeEntity()
    {
        return new Employee
        {
            Email = Email,
            TbMAccount = new Account
            {
                Password = Password
            }
        };
    }
}