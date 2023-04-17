using API.Models;
using API.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace API_Tests;

[TestClass]
public class AccountRepositoryShould : API_Tests
{
    private IAccountRepository _accountRepository;
    private IEmployeeRepository _employeeRepository;

    public AccountRepositoryShould()
    {
        _accountRepository = _service.GetService<IAccountRepository>();
        _employeeRepository = _service.GetService<IEmployeeRepository>();
    }
    
    [TestMethod]
    public async Task Login_Should_Logged_In_User_With_Given_Email_And_Password()
    {
        var registered = await Register_User("10000", "test@gmail.com");
        
        Assert.IsNotNull(registered);
        
        var employee = await _accountRepository.LoginAsync(new TbMEmployee
        {
            Email = registered.Email,
            TbMAccount = new TbMAccount
            {
                Password = registered.TbMAccount.Password
            }
        });
        
        Assert.IsNotNull(employee);
    }

    [TestMethod]
    public async Task Register_Should_Registered_User()
    {
        var registered = await _accountRepository.RegisterAsync(new TbMEmployee
        {
            Nik = "0001",
            FirstName = "Fitrah",
            LastName = "Ramadhan",
            Gender = 0,
            Birthdate = new DateTime(1999, 12, 26),
            Email = "fitrah@gmail.com",
            PhoneNumber = "111",
            HiringDate = DateTime.Now,
            TbMAccount = new TbMAccount
            {
                Password = "secret",
                TbTrAccountRoles = new List<TbTrAccountRole>(new []
                {
                    new TbTrAccountRole
                    {
                        Role = new TbMRole
                        {
                            Name = "Admin"
                        }
                    }
                })
            },
            TbTrProfiling = new TbTrProfiling
            {
                Education = new TbMEducation
                {
                    Major = "Computer Science",
                    Degree = "Bachelor",
                    Gpa = 3.25m,
                    University = new TbMUniversity
                    {
                        Name = "State Polytechnic of Sriwijaya"
                    }
                }
            }
        });
        
        Assert.IsNotNull(registered);
    }

    public async Task<TbMEmployee> Register_User(string nik, string email)
    {
        var registered = await _accountRepository.RegisterAsync(new TbMEmployee
        {
            Nik = nik,
            FirstName = "Fitrah",
            LastName = "Ramadhan",
            Gender = 0,
            Birthdate = new DateTime(1999, 12, 26),
            Email = email,
            PhoneNumber = "111",
            HiringDate = DateTime.Now,
            TbMAccount = new TbMAccount
            {
                Password = "secret",
                TbTrAccountRoles = new List<TbTrAccountRole>(new []
                {
                    new TbTrAccountRole
                    {
                        Role = new TbMRole
                        {
                            Name = "Admin"
                        }
                    }
                })
            },
            TbTrProfiling = new TbTrProfiling
            {
                Education = new TbMEducation
                {
                    Major = "Computer Science",
                    Degree = "Bachelor",
                    Gpa = 3.25m,
                    University = new TbMUniversity
                    {
                        Name = "State Polytechnic of Sriwijaya"
                    }
                }
            }
        });
        
        Assert.IsNotNull(registered);

        return registered;
    }
}