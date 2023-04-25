using API.DAOs;
using API.DTOs.response;
using API.Models;
using API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations;

public class EmployeeRepository<TContext> : CoreRepository<string, Employee, TContext>, IEmployeeRepository
    where TContext : DbContext
{
    public EmployeeRepository(TContext context) : base(context)
    {
    }

    public async Task<Employee?> FindOneByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Email.Equals(email));
    }

    public async Task<Employee?> FindOneByPhoneNumberAsync(string phoneNumber)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.PhoneNumber.Equals(phoneNumber));
    }

    public async Task<IEnumerable<Employee>> FindManyIncludeEducationAndUniversityAsync()
    {
        return _dbSet
            .Include(e => e.TbTrProfiling)
            .ThenInclude(p => p.Education)
            .ThenInclude(e => e.University)
            .AsEnumerable();
    }
    
    public async Task<IEnumerable<Employee>> FindManyByAboveAvgGpaAndHiringYear(int year)
    {
        var avgGpa = _dbSet.Select(e => e.TbTrProfiling.Education.Gpa).AsEnumerable().Average();
        
        var employees = _dbSet
            .Include(e => e.TbTrProfiling.Education)
            .Include(e => e.TbTrProfiling.Education.University)
            .Where(e => e.HiringDate.Year.Equals(year))
            .Where(e => e.TbTrProfiling.Education.Gpa > avgGpa)
            .AsEnumerable();

        return employees;
    }

    public async Task<IEnumerable<EmployeesTotalGroupByMajorAndUniversityNameDAO>> FindTotalGroupByMajorAndUniversityName()
    {
        var result = _dbSet.Include(e => e.TbTrProfiling).Include(e => e.TbTrProfiling.Education)
            .GroupBy(e => new {e.TbTrProfiling.Education.Major, e.TbTrProfiling.Education.University.Name})
            .Select(g => new EmployeesTotalGroupByMajorAndUniversityNameDAO
            {
                Total = g.Count(),
                Major = g.Key.Major,
                UniversityName = g.Key.Name
            });

        return result;
    }

    public async Task<IEnumerable<Employee>> FindByWorkPeriod()
    {
        var result = _dbSet.OrderBy(e => e.HiringDate);

        return result;
    }
}