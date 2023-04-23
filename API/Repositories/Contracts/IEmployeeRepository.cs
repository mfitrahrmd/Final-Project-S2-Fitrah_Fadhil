using API.Models;

namespace API.Repositories.Contracts;

public interface IEmployeeRepository : IBaseRepository<string, TbMEmployee>
{
    Task<TbMEmployee?> FindOneByEmailAsync(string email);
    Task<TbMEmployee?> FindOneByPhoneNumberAsync(string phoneNumber);
    Task<IEnumerable<TbMEmployee>> FindManyIncludeEducationAndUniversityAsync();
    Task<IEnumerable<TbMEmployee>> FindManyByAboveAvgGpaAndHiringYear(int year);
}