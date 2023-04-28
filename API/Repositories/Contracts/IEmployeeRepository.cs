using API.DAOs;
using API.Models;

namespace API.Repositories.Contracts;

public interface IEmployeeRepository : IBaseRepository<string, Employee>
{
    Task<Employee?> FindOneByEmailAsync(string email);
    Task<Employee?> FindOneByPhoneNumberAsync(string phoneNumber);
    Task<IEnumerable<Employee>> FindManyIncludeEducationAndUniversityAsync();
    Task<IEnumerable<Employee>> FindManyByAboveAvgGpaAndHiringYear(int year);
    Task<IEnumerable<EmployeesTotalGroupByMajorAndUniversityNameDAO>> FindTotalGroupByMajorAndUniversityName();
    Task<IEnumerable<Employee>> FindByWorkPeriod();
}