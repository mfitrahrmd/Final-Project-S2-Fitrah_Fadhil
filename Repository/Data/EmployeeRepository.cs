using DTS_Web_Api.Contexts;
using DTS_Web_Api.Models;
using DTS_Web_Api.Repository.Contracts;
using DTS_Web_Api.ViewModels;
using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace DTS_Web_Api.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        public EmployeeRepository(MyContext context) : base(context)
        {
        }

        public async Task<UserDataVM> GetUserDataByEmailAsync(string email)
        {
            var employee = await _context.TbMEmployees.FirstOrDefaultAsync(e => e.Email == email);
            return new UserDataVM
            {
                Nik = employee!.Nik,
                Email = employee.Email,
                FullName = string.Concat(employee.FirstName, " ", employee.LastName)
            };
        }
    }
}
