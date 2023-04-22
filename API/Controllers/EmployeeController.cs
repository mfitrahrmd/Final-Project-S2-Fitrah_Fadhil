using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : CoreController<IEmployeeRepository, string, TbMEmployee>
{
    public EmployeeController(IEmployeeRepository repository) : base(repository)
    {
    }
}