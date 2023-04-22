using API.Models;
using API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : CoreController<IRoleRepository, int, TbMRole>
{
    public RoleController(IRoleRepository repository) : base(repository)
    {
    }
}