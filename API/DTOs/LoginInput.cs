using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs;

public class LoginInput
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