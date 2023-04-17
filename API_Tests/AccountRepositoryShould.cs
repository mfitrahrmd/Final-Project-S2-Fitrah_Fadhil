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
        var registered = await Register_User("00001", "00001@gmail.com");
        
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
        var registered = await Register_User("00002", "00002@gmail.com");
        
        Assert.IsNotNull(registered);
    }

    public async Task<TbMEmployee> Register_User(string nik, string email)
    {
        var registered = await _accountRepository.RegisterAsync(new TbMEmployee
        {
            Nik = nik,
            FirstName = "test",
            LastName = "test",
            Gender = 0,
            Birthdate = new DateTime(2000, 1, 1),
            Email = email,
            PhoneNumber = "000",
            HiringDate = DateTime.Now,
            TbMAccount = new TbMAccount
            {
                Password = "secret"
            },
            TbTrProfiling = new TbTrProfiling
            {
                Education = new TbMEducation
                {
                    Major = "Computer Science",
                    Degree = "Bachelor",
                    Gpa = 3.5m,
                    University = new TbMUniversity
                    {
                        Name = "University of Test"
                    }
                }
            }
        });
        
        Assert.IsNotNull(registered);

        return registered;
    }
}