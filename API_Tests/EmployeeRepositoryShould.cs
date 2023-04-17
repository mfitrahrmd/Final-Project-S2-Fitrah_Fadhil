using System.Diagnostics;
using API.Models;
using API.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace API_Tests;

[TestClass]
public class EmployeeRepositoryShould : API_Tests
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeRepositoryShould()
    {
        _employeeRepository = _service.GetService<IEmployeeRepository>();
    }

    [TestMethod]
    public async Task FindOneByEmail_Should_Find_Employee_With_Given_Email()
    {
        var insertedEmployee = await _employeeRepository.InsertOne(new TbMEmployee
        {
            Nik = "00001",
            FirstName = "Fitrah",
            LastName = "Ramadhan",
            Birthdate = new DateTime(1999, 12, 26),
            Email = "fitrah@gmail.com",
            PhoneNumber = "081234567890",
            Gender = 0,
            HiringDate = DateTime.Now
        });
        
        Assert.IsNotNull(insertedEmployee);

        var testCases = new List<TestCase>(new []
        {
            new  TestCase
            {
                Name = "Find employee with existing email",
                EmployeeEmail = insertedEmployee.Email,
                Result = e =>
                {
                    Assert.IsNotNull(e);
                    Assert.AreEqual(insertedEmployee.Nik, e.Nik);
                    Assert.AreEqual(insertedEmployee.Email, e.Email);
                }
            },
            new TestCase
            {
                Name = "Find employee with non existing email",
                EmployeeEmail = "nothing@gmail.com",
                Result = e =>
                {
                    Assert.IsNull(e);
                }
            }
        });
        
        testCases.ForEach(async tc =>
        {
            var foundEmployee = await _employeeRepository.FindOneByEmailAsync(tc.EmployeeEmail);

            tc.Result(foundEmployee);
        });
    }
    
    private struct TestCase
    {
        public string Name { get; set; }
        public string EmployeeEmail { get; set; }
        public Action<TbMEmployee> Result;
    }
}