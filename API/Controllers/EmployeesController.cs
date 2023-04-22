using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : CoreController<IEmployeeRepository, string, TbMEmployee>
{
    public EmployeesController(IEmployeeRepository repository) : base(repository)
    {
    }
}