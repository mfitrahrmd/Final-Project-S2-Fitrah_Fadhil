using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs.request;

public class LoginRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }

    public TbMEmployee ToEmployeeEntity()
    {
        return new TbMEmployee
        {
            Email = Email,
            TbMAccount = new TbMAccount
            {
                Password = Password
            }
        };
    }
}